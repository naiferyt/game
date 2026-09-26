// Stage 1+ test harness (RECONSTRUIDO: tooling). Runs a scene in Play Mode unattended, then writes
//   recovery/logs/playrun_<name>.log  : RecoveryPending hits (in order), errors/exceptions, scene transitions
//   recovery/logs/screens/playrun_<name>_<t>.png : captures of what the game renders
// Usage (batch, WITH graphics, WITHOUT -quit):
//   Unity -batchmode -projectPath <p> -executeMethod DSSRecovery.PlayModeRunner.Run -runScene "Assets/Scenes/CloudStrap.unity" -runSeconds 12 -runName boot [-runClicks "x,y@t;..."]
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace DSSRecovery
{
	[InitializeOnLoad]
	public static class PlayModeRunner
	{
		const string K = "DSSRecovery.PlayModeRunner.";
		static readonly StringBuilder Log = new StringBuilder();
		static double s_Start;
		static readonly List<float> s_ShotTimes = new List<float>();
		static readonly List<KeyValuePair<float, Vector2>> s_Clicks = new List<KeyValuePair<float, Vector2>>();
		static readonly List<KeyValuePair<float, string>> s_ObjClicks = new List<KeyValuePair<float, string>>();

		static PlayModeRunner()
		{
			if (!SessionState.GetBool(K + "active", false)) return;
			EditorApplication.playModeStateChanged += OnState;
			if (EditorApplication.isPlaying) Begin();
		}

		static string Arg(string name, string def)
		{
			var a = Environment.GetCommandLineArgs();
			int i = Array.IndexOf(a, name);
			if (i < 0 || i + 1 >= a.Length || a[i + 1].StartsWith("-")) return def;   // Windows drops empty args
			return a[i + 1];
		}

		public static void Run()
		{
			string scene = Arg("-runScene", "Assets/Scenes/CloudStrap.unity");
			SessionState.SetBool(K + "active", true);
			SessionState.SetString(K + "name", Arg("-runName", "run"));
			SessionState.SetFloat(K + "seconds", float.Parse(Arg("-runSeconds", "10"), System.Globalization.CultureInfo.InvariantCulture));
			SessionState.SetString(K + "shots", Arg("-runShots", "2,5,9"));
			SessionState.SetString(K + "clicks", Arg("-runClicks", ""));
			SessionState.SetString(K + "dump", Arg("-runDump", ""));
			EditorSceneManager.OpenScene(scene, OpenSceneMode.Single);
			EditorApplication.playModeStateChanged += OnState;
			EditorApplication.isPlaying = true;
		}

		static void OnState(PlayModeStateChange s)
		{
			if (s == PlayModeStateChange.EnteredPlayMode) Begin();
		}

		static void Begin()
		{
			Log.Length = 0;
			s_Start = EditorApplication.timeSinceStartup;
			EditorApplication.update -= Tick; EditorApplication.update += Tick;
			s_ShotTimes.Clear(); s_Clicks.Clear(); s_ObjClicks.Clear();
			foreach (var p in SessionState.GetString(K + "shots", "").Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
				s_ShotTimes.Add(float.Parse(p, System.Globalization.CultureInfo.InvariantCulture));
			foreach (var c in SessionState.GetString(K + "clicks", "").Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries))
			{
				var at = c.Split('@'); if (at.Length != 2) continue;
				if (at[0].StartsWith("obj:")) { s_ObjClicks.Add(new KeyValuePair<float, string>(float.Parse(at[1], System.Globalization.CultureInfo.InvariantCulture), at[0].Substring(4))); continue; }
				var xy = at[0].Split(','); if (xy.Length != 2) continue;
				s_Clicks.Add(new KeyValuePair<float, Vector2>(float.Parse(at[1], System.Globalization.CultureInfo.InvariantCulture),
					new Vector2(float.Parse(xy[0], System.Globalization.CultureInfo.InvariantCulture), float.Parse(xy[1], System.Globalization.CultureInfo.InvariantCulture))));
			}
			Application.logMessageReceived -= OnLog; Application.logMessageReceived += OnLog;
			SceneManager.activeSceneChanged -= OnScene; SceneManager.activeSceneChanged += OnScene;
			EditorApplication.update -= Tick; EditorApplication.update += Tick;
			Log.AppendLine("[run] start scene " + SceneManager.GetActiveScene().path + " screen " + Screen.width + "x" + Screen.height);
		}

		static void OnScene(Scene a, Scene b) { Log.AppendLine(string.Format("[{0:0.00}] [scene] -> {1}", T, b.path)); }
		static float T { get { return (float)(EditorApplication.timeSinceStartup - s_Start); } }

		static void OnLog(string msg, string stack, LogType type)
		{
			if (type == LogType.Log && !msg.StartsWith("[")) { Log.AppendLine(string.Format("[{0:0.00}] [log] {1}", T, msg)); return; }
			string st = (type == LogType.Exception || type == LogType.Error || type == LogType.Assert) ? "\n      " + stack.Replace("\n", "\n      ").Trim() : "";
			Log.AppendLine(string.Format("[{0:0.00}] [{1}] {2}{3}", T, type, msg, st));
		}

		static void Tick()
		{
			float t = T;
			if (t > SessionState.GetFloat(K + "seconds", 10f) + 30f) { Log.AppendLine("[run] watchdog exit"); Finish(); return; }
			while (s_Clicks.Count > 0 && t >= s_Clicks[0].Key)
			{
				Log.AppendLine(string.Format("[{0:0.00}] [click] {1}", t, s_Clicks[0].Value));
				RecoveryTestInput.Click(s_Clicks[0].Value);
				s_Clicks.RemoveAt(0);
			}
			while (s_ObjClicks.Count > 0 && t >= s_ObjClicks[0].Key)
			{
				string name = s_ObjClicks[0].Value; s_ObjClicks.RemoveAt(0);
				Vector2 n; string how;
				if (ScreenPosOf(name, out n, out how)) { Log.AppendLine(string.Format("[{0:0.00}] [click] obj '{1}' -> {2} ({3})", t, name, n, how)); RecoveryTestInput.Click(n); }
				else Log.AppendLine(string.Format("[{0:0.00}] [click] obj '{1}' NOT FOUND (active)", t, name));
			}
			while (s_ShotTimes.Count > 0 && t >= s_ShotTimes[0])
			{
				Shot(t); s_ShotTimes.RemoveAt(0);
			}
			if (t >= SessionState.GetFloat(K + "seconds", 10f)) Finish();
		}

		// normalized screen position of an active object's visual center, seen by the camera that renders its layer
		static bool ScreenPosOf(string name, out Vector2 n, out string how)
		{
			n = Vector2.zero; how = "";
			var go = UnityEngine.Object.FindObjectsByType<Transform>(FindObjectsSortMode.None).Select(x => x.gameObject).FirstOrDefault(g => g.name == name && g.activeInHierarchy);
			if (go == null) return false;
			Bounds b; var r = go.GetComponentInChildren<Renderer>(); var col = go.GetComponent<Collider>();
			if (col != null) b = col.bounds; else if (r != null) b = r.bounds; else b = new Bounds(go.transform.position, Vector3.zero);
			var cam = UnityEngine.Object.FindObjectsByType<Camera>(FindObjectsSortMode.None).Where(c => c.enabled && (c.cullingMask & (1 << go.layer)) != 0).OrderByDescending(c => c.depth).FirstOrDefault();
			if (cam == null) return false;
			Vector3 sp = cam.WorldToScreenPoint(b.center);
			n = new Vector2(sp.x / Screen.width, sp.y / Screen.height); how = "camera " + cam.name + ", px " + (Vector2)sp;
			return true;
		}

		static void Shot(float t)
		{
			try
			{
				var cams = UnityEngine.Object.FindObjectsByType<Camera>(FindObjectsSortMode.None).Where(c => c.enabled && c.gameObject.activeInHierarchy).OrderBy(c => c.depth).ToList();
				var rt = new RenderTexture(1280, 720, 24);
				foreach (var c in cams) { var o = c.targetTexture; c.targetTexture = rt; c.Render(); c.targetTexture = o; }
				RenderTexture.active = rt;
				var tex = new Texture2D(1280, 720, TextureFormat.RGB24, false); tex.ReadPixels(new Rect(0, 0, 1280, 720), 0, 0); tex.Apply();
				RenderTexture.active = null;
				string dir = Path.Combine(LogDir, "screens"); Directory.CreateDirectory(dir);
				string f = Path.Combine(dir, string.Format("playrun_{0}_{1:00.0}s.png", SessionState.GetString(K + "name", "run"), t));
				File.WriteAllBytes(f, tex.EncodeToPNG());
				UnityEngine.Object.DestroyImmediate(tex); rt.Release();
				Log.AppendLine(string.Format("[{0:0.00}] [shot] {1} ({2} cameras: {3})", t, Path.GetFileName(f), cams.Count, string.Join(", ", cams.Select(c => c.name).ToArray())));
			}
			catch (Exception e) { Log.AppendLine("[shot failed] " + e.Message); }
		}

		// state dump at the end: active root objects + all fields of the first instance of each requested component type
		static void Dump()
		{
			var roots = SceneManager.GetActiveScene().GetRootGameObjects().Where(g => g.activeInHierarchy).Select(g => g.name).ToList();
			var ddol = UnityEngine.Object.FindObjectsByType<Transform>(FindObjectsSortMode.None).Where(x => x.parent == null && x.gameObject.scene.name == "DontDestroyOnLoad").Select(x => x.name);
			Log.AppendLine("[dump] active roots: " + string.Join(", ", roots.ToArray()));
			Log.AppendLine("[dump] DontDestroyOnLoad roots: " + string.Join(", ", ddol.ToArray()));
			foreach (var tn in SessionState.GetString(K + "dump", "").Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
			{
				if (tn.StartsWith("obj:"))
				{
					var root = UnityEngine.Object.FindObjectsByType<Transform>(FindObjectsInactive.Include, FindObjectsSortMode.None).FirstOrDefault(x => x.name == tn.Substring(4));
					if (root == null) { Log.AppendLine("[dump] object not found " + tn); continue; }
					Log.AppendLine("[dump] object " + tn.Substring(4) + " pos " + root.position + " scale " + root.lossyScale + " layer " + root.gameObject.layer);
					foreach (var rr in root.GetComponentsInChildren<Renderer>(true).Take(25))
					{
						var m = rr.sharedMaterial; string col = "";
						if (m != null && m.HasProperty("_Color")) col = " color " + m.color;
						var cams = UnityEngine.Object.FindObjectsByType<Camera>(FindObjectsSortMode.None).Where(c => (c.cullingMask & (1 << rr.gameObject.layer)) != 0).Select(c => c.name + (GeometryUtility.TestPlanesAABB(GeometryUtility.CalculateFrustumPlanes(c), rr.bounds) ? "(in view)" : "(out)"));
						var mf = rr.GetComponent<MeshFilter>();
						Log.AppendLine(string.Format("     {0} active={1} enabled={2} layer={3} center={4} size={5} mesh={6} mat={7}{8} shader={9} cams={10}",
							rr.name, rr.gameObject.activeInHierarchy, rr.enabled, rr.gameObject.layer, rr.bounds.center, rr.bounds.size,
							mf != null && mf.sharedMesh != null ? mf.sharedMesh.vertexCount + "v" : "none", m != null ? m.name : "null", col, m != null ? m.shader.name : "-", string.Join("/", cams.ToArray())));
					}
					continue;
				}
				var type = AppDomain.CurrentDomain.GetAssemblies().Select(a => a.GetType(tn)).FirstOrDefault(x => x != null);
				if (type == null) { Log.AppendLine("[dump] type not found " + tn); continue; }
				var inst = UnityEngine.Object.FindObjectsByType(type, FindObjectsInactive.Include, FindObjectsSortMode.None).FirstOrDefault();
				if (inst == null) { Log.AppendLine("[dump] no instance of " + tn); continue; }
				Log.AppendLine("[dump] " + tn + " on '" + inst.name + "':");
				foreach (var f in type.GetFields(System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.NonPublic))
				{
					object v; try { v = f.GetValue(inst); } catch (Exception e) { v = "<" + e.GetType().Name + ">"; }
					string s = v == null ? "null" : (v is UnityEngine.Object uo ? (uo == null ? "null(destroyed)" : "'" + uo.name + "'") : v.ToString());
					Log.AppendLine("     " + f.Name + " = " + s);
				}
			}
		}

		static string LogDir { get { return Path.GetFullPath(Path.Combine(Application.dataPath, "..", "..", "logs")); } }

		static void Finish()
		{
			EditorApplication.update -= Tick;
			Application.logMessageReceived -= OnLog;
			SceneManager.activeSceneChanged -= OnScene;
			Dump();
			var pending = RecoveryPending.Seen.ToList();
			Log.AppendLine("[run] end. active scene: " + SceneManager.GetActiveScene().path);
			Log.AppendLine("[run] distinct RecoveryPending members hit: " + pending.Count);
			foreach (var p in pending) Log.AppendLine("   PENDING " + p);
			Directory.CreateDirectory(LogDir);
			File.WriteAllText(Path.Combine(LogDir, "playrun_" + SessionState.GetString(K + "name", "run") + ".log"), Log.ToString());
			SessionState.SetBool(K + "active", false);
			EditorApplication.Exit(0);
		}
	}
}
