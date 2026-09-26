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
			s_ShotTimes.Clear(); s_Clicks.Clear();
			foreach (var p in SessionState.GetString(K + "shots", "").Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
				s_ShotTimes.Add(float.Parse(p, System.Globalization.CultureInfo.InvariantCulture));
			foreach (var c in SessionState.GetString(K + "clicks", "").Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries))
			{
				var at = c.Split('@'); if (at.Length != 2) continue;
				var xy = at[0].Split(','); if (xy.Length != 2) continue;
				s_Clicks.Add(new KeyValuePair<float, Vector2>(float.Parse(at[1], System.Globalization.CultureInfo.InvariantCulture),
					new Vector2(float.Parse(xy[0], System.Globalization.CultureInfo.InvariantCulture), float.Parse(xy[1], System.Globalization.CultureInfo.InvariantCulture))));
			}
			Application.logMessageReceived -= OnLog; Application.logMessageReceived += OnLog;
			SceneManager.activeSceneChanged -= OnScene; SceneManager.activeSceneChanged += OnScene;
			EditorApplication.update -= Tick; EditorApplication.update += Tick;
			Log.AppendLine("[run] start scene " + SceneManager.GetActiveScene().path);
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
			while (s_ShotTimes.Count > 0 && t >= s_ShotTimes[0])
			{
				Shot(t); s_ShotTimes.RemoveAt(0);
			}
			if (t >= SessionState.GetFloat(K + "seconds", 10f)) Finish();
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

		static string LogDir { get { return Path.GetFullPath(Path.Combine(Application.dataPath, "..", "..", "logs")); } }

		static void Finish()
		{
			EditorApplication.update -= Tick;
			Application.logMessageReceived -= OnLog;
			SceneManager.activeSceneChanged -= OnScene;
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
