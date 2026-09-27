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
		// simulated keys: "key:<KeyCode>@<from>-<to>" holds the key between the two times (stage 3)
		static readonly List<KeyValuePair<float, KeyValuePair<KeyCode, bool>>> s_Keys = new List<KeyValuePair<float, KeyValuePair<KeyCode, bool>>>();
		// autopilot: "auto@<from>-<to>" holds W and steers the player's kart toward the waypoint ahead (stage 3 tests)
		static readonly List<Vector2> s_AutoRanges = new List<Vector2>();
		static bool s_AutoOn;
		// kart trace: "trace@<from>-<to>" logs the player's position, speed and the sweep hits of CarCollider.DoMovement every 0.05 s (stage 4.10)
		static readonly List<Vector2> s_TraceRanges = new List<Vector2>();
		static float s_NextTrace;
		// rival trace: "aitrace@<from>-<to>" logs every AI kart (position, speed, jump effect, air state) every 0.1 s
		static readonly List<Vector2> s_AiTraceRanges = new List<Vector2>();
		static float s_NextAiTrace;
		static string s_LastButtons = "";
		// average frame rate between screenshots (stage 4.1)
		static int s_FpsFrame = -1;
		static float s_FpsTime;
		// scene loads: "load:<scene name>@t" loads a scene directly (e.g. a track, whose DebugTrackStrapper then sets up a race)
		static readonly List<KeyValuePair<float, string>> s_Loads = new List<KeyValuePair<float, string>>();

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
			s_ShotTimes.Clear(); s_Clicks.Clear(); s_ObjClicks.Clear(); s_Keys.Clear(); s_AutoRanges.Clear(); s_AutoOn = false; s_TraceRanges.Clear(); s_NextTrace = 0f; s_Spawned.Clear(); s_AiTraceRanges.Clear(); s_NextAiTrace = 0f; s_Loads.Clear(); s_FpsFrame = -1; s_LastButtons = "";
			foreach (var p in SessionState.GetString(K + "shots", "").Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
				s_ShotTimes.Add(float.Parse(p, System.Globalization.CultureInfo.InvariantCulture));
			foreach (var c in SessionState.GetString(K + "clicks", "").Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries))
			{
				var at = c.Split('@'); if (at.Length != 2) continue;
				if (at[0].StartsWith("hidetype:"))
				{
					s_Loads.Add(new KeyValuePair<float, string>(float.Parse(at[1], System.Globalization.CultureInfo.InvariantCulture), "#hide#" + at[0].Substring(9)));
					continue;
				}
				if (at[0].StartsWith("quality:"))
				{
					s_Loads.Add(new KeyValuePair<float, string>(float.Parse(at[1], System.Globalization.CultureInfo.InvariantCulture), "#quality#" + at[0].Substring(8)));
					continue;
				}
				if (at[0] == "spawnanims")
				{
					s_Loads.Add(new KeyValuePair<float, string>(float.Parse(at[1], System.Globalization.CultureInfo.InvariantCulture), "#spawnanims#"));
					continue;
				}
				if (at[0] == "spawnai")
				{
					s_Loads.Add(new KeyValuePair<float, string>(float.Parse(at[1], System.Globalization.CultureInfo.InvariantCulture), "#spawnai#"));
					continue;
				}
				if (at[0] == "closeups")
				{
					s_Loads.Add(new KeyValuePair<float, string>(float.Parse(at[1], System.Globalization.CultureInfo.InvariantCulture), "#close#"));
					continue;
				}
				if (at[0].StartsWith("load:"))
				{
					s_Loads.Add(new KeyValuePair<float, string>(float.Parse(at[1], System.Globalization.CultureInfo.InvariantCulture), at[0].Substring(5)));
					continue;
				}
				if (at[0] == "aitrace")
				{
					var ar = at[1].Split('-');
					s_AiTraceRanges.Add(new Vector2(float.Parse(ar[0], System.Globalization.CultureInfo.InvariantCulture), float.Parse(ar[1], System.Globalization.CultureInfo.InvariantCulture)));
					continue;
				}
				if (at[0] == "trace")
				{
					var tr = at[1].Split('-');
					s_TraceRanges.Add(new Vector2(float.Parse(tr[0], System.Globalization.CultureInfo.InvariantCulture), float.Parse(tr[1], System.Globalization.CultureInfo.InvariantCulture)));
					continue;
				}
				if (at[0] == "auto")
				{
					var ft = at[1].Split('-');
					s_AutoRanges.Add(new Vector2(float.Parse(ft[0], System.Globalization.CultureInfo.InvariantCulture), float.Parse(ft[1], System.Globalization.CultureInfo.InvariantCulture)));
					continue;
				}
				if (at[0].StartsWith("key:"))
				{
					var k = (KeyCode)Enum.Parse(typeof(KeyCode), at[0].Substring(4));
					var ft = at[1].Split('-');
					s_Keys.Add(new KeyValuePair<float, KeyValuePair<KeyCode, bool>>(float.Parse(ft[0], System.Globalization.CultureInfo.InvariantCulture), new KeyValuePair<KeyCode, bool>(k, true)));
					s_Keys.Add(new KeyValuePair<float, KeyValuePair<KeyCode, bool>>(float.Parse(ft[1], System.Globalization.CultureInfo.InvariantCulture), new KeyValuePair<KeyCode, bool>(k, false)));
					continue;
				}
				if (at[0].StartsWith("obj:")) { s_ObjClicks.Add(new KeyValuePair<float, string>(float.Parse(at[1], System.Globalization.CultureInfo.InvariantCulture), at[0].Substring(4))); continue; }
				var xy = at[0].Split(','); if (xy.Length != 2) continue;
				s_Clicks.Add(new KeyValuePair<float, Vector2>(float.Parse(at[1], System.Globalization.CultureInfo.InvariantCulture),
					new Vector2(float.Parse(xy[0], System.Globalization.CultureInfo.InvariantCulture), float.Parse(xy[1], System.Globalization.CultureInfo.InvariantCulture))));
			}
			s_Keys.Sort((a, b) => a.Key.CompareTo(b.Key));
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
			while (s_Keys.Count > 0 && t >= s_Keys[0].Key)
			{
				var kv = s_Keys[0].Value; s_Keys.RemoveAt(0);
				RecoveryTestInput.SetKey(kv.Key, kv.Value);
				Log.AppendLine(string.Format("[{0:0.00}] [key] {1} {2}", t, kv.Key, kv.Value ? "down" : "up"));
			}
			while (s_Loads.Count > 0 && t >= s_Loads[0].Key)
			{
				string what = s_Loads[0].Value;
				if (what == "#close#") { CloseUps(t); s_Loads.RemoveAt(0); continue; }
				if (what.StartsWith("#quality#"))
				{
					QualitySettings.SetQualityLevel(int.Parse(what.Substring(9)), true);
					Log.AppendLine(string.Format("[{0:0.00}] [quality] {1} ({2}) skinWeights {3}", t, QualitySettings.GetQualityLevel(), QualitySettings.names[QualitySettings.GetQualityLevel()], QualitySettings.skinWeights));
					s_Loads.RemoveAt(0); continue;
				}
				if (what == "#spawnai#") { SpawnAllAi(t); s_Loads.RemoveAt(0); continue; }
				if (what == "#spawnanims#") { SpawnAllAi(t, true); s_Loads.RemoveAt(0); continue; }
				if (what.StartsWith("#hide#"))
				{
					// test-only: hides every active instance of a component type (e.g. an overlay covering the screenshots)
					var type = AppDomain.CurrentDomain.GetAssemblies().Select(a => a.GetType(what.Substring(6))).FirstOrDefault(x => x != null);
					int n = 0;
					if (type != null) foreach (var o in UnityEngine.Object.FindObjectsByType(type, FindObjectsSortMode.None)) { ((Component)o).gameObject.SetActive(false); n++; }
					Log.AppendLine(string.Format("[{0:0.00}] [hide] {1} x{2}", t, what.Substring(6), n));
				}
				else
				{
					Log.AppendLine(string.Format("[{0:0.00}] [load] {1}", t, what));
					SceneManager.LoadScene(what);
				}
				s_Loads.RemoveAt(0);
			}
			AutoPilot(t);
			Trace(t);
			AiTrace(t);
			while (s_ShotTimes.Count > 0 && t >= s_ShotTimes[0])
			{
				Shot(t); s_ShotTimes.RemoveAt(0);
			}
			if (t >= SessionState.GetFloat(K + "seconds", 10f)) Finish();
		}

		static void AiTrace(float t)
		{
			if (t < s_NextAiTrace || !s_AiTraceRanges.Any(r => t >= r.x && t < r.y)) return;
			s_NextAiTrace = t + 0.1f;
			foreach (var ai in UnityEngine.Object.FindObjectsByType<GimpedCarAI>(FindObjectsSortMode.None))
			{
				var cc = ai.GetComponent<CarCollider>();
				bool jump = cc != null && cc.EffectMgr != null && cc.EffectMgr.HasEffect(typeof(GuidedJumpEffect));
				string fx = cc != null && cc.EffectMgr != null ? string.Join("+", new[] { typeof(GuidedJumpEffect), typeof(FlipEffect), typeof(WipeoutEffect), typeof(TeleportEffect) }.Where(ty => cc.EffectMgr.HasEffect(ty)).Select(ty => ty.Name.Replace("Effect", "")).ToArray()) : "";
				Log.AppendLine(string.Format("[{0:0.00}] [ai] {1} pos {2} v {3:0.0} air {4} fx {5} lap {6}", t, ai.name, ai.transform.position.ToString("F1"), ai.LinearVelocity, ai.IsInAir ? 1 : 0, fx, RaceManager.GetCarLap(ai.gameObject)));
			}
		}

		static void Trace(float t)
		{
			if (t < s_NextTrace || !s_TraceRanges.Any(r => t >= r.x && t < r.y)) return;
			s_NextTrace = t + 0.05f;
			var player = GameObject.FindGameObjectWithTag("Player");
			if (player == null) return;
			var cc = player.GetComponent<CarCollider>(); var col = player.GetComponent<Collider>();
			if (cc == null || col == null) return;
			Vector3 v = cc.GetVelocity();
			var hits = Physics.SphereCastAll(player.transform.position, col.bounds.size.x, v.normalized, v.magnitude * Time.fixedDeltaTime, 1536, QueryTriggerInteraction.Ignore)
				.Where(h => h.transform.gameObject != player)
				.Select(h => PathOf(h.collider.transform) + "[" + h.collider.GetType().Name + " L" + h.collider.gameObject.layer + (h.collider.isTrigger ? " trigger" : "") + "]"
					+ (h.distance == 0f && h.point == Vector3.zero ? "(overlap)" : string.Format("(d {0:0.00} p {1} n {2})", h.distance, h.point, h.normal)));
			// DoRoadBoundaries margin (>= 0 means the waypoint wall is pushing the kart), ground contact and heading
			var bf = System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance;
			var wp = WaypointLogic.FindClosestWaypoint(player.transform.position, false);
			bool grounded = (typeof(CarCollider).GetField("lastRoadContact", bf).GetValue(cc) as GameObject) != null;
			string wall = "-";
			if (wp != null)
			{
				Vector3 pos = player.transform.position;
				Vector3 d = wp.GetTrackPoint(pos) + wp.GetWallOffsetForPoint(pos) - pos; d.y = 0f;
				wall = string.Format("{0:0.00}{1}", d.magnitude + col.bounds.size.x - wp.GetWallDistanceAtPoint(pos), wp.projectsWalls ? "" : "(off)") + " wp " + wp.name;
			}
			Log.AppendLine(string.Format("[{0:0.00}] [trace] pos {1} speed {2:0.0} vy {3:0.0} r {5:0.00} {6} fwd {7} ground {8} wall {9} hits {4}", t, player.transform.position, v.magnitude, v.y, string.Join(", ", hits.ToArray()), col.bounds.size.x, col.GetType().Name,
				player.transform.forward.ToString("F2"), grounded ? 1 : 0, wall));
		}

		static string PathOf(Transform x)
		{
			string s = x.name;
			for (var p = x.parent; p != null; p = p.parent) s = p.name + "/" + s;
			return s;
		}

		static void AutoPilot(float t)
		{
			bool on = s_AutoRanges.Any(r => t >= r.x && t < r.y);
			if (on != s_AutoOn)
			{
				s_AutoOn = on;
				RecoveryTestInput.SetKey(KeyCode.W, on);
				if (!on) { RecoveryTestInput.SetKey(KeyCode.A, false); RecoveryTestInput.SetKey(KeyCode.D, false); }
				Log.AppendLine(string.Format("[{0:0.00}] [auto] {1}", t, on ? "on" : "off"));
			}
			if (!on) return;
			var player = GameObject.FindGameObjectWithTag("Player");
			if (player == null) return;
			Vector3 pos = player.transform.position;
			WaypointLogic next = WaypointLogic.FindNextWaypoint(pos);
			if (next == null) return;
			Vector3 target = next.transform.position;
			if (next.forwardPoint != null && (target - pos).magnitude < 12f) target = next.forwardPoint.transform.position;
			Vector3 to = target - pos; to.y = 0f;
			Vector3 fwd = player.transform.forward; fwd.y = 0f;
			float angle = Vector3.SignedAngle(fwd, to, Vector3.up);
			RecoveryTestInput.SetKey(KeyCode.D, angle > 4f);
			RecoveryTestInput.SetKey(KeyCode.A, angle < -4f);
		}

		static void LogButtons(float t)
		{
			var names = UnityEngine.Object.FindObjectsByType<UghButton>(FindObjectsSortMode.None).Where(b => b.gameObject.activeInHierarchy).Select(b => b.name).OrderBy(n => n).ToArray();
			string joined = string.Join(", ", names);
			if (joined == s_LastButtons) return;
			s_LastButtons = joined;
			Log.AppendLine(string.Format("[{0:0.00}] [buttons] {1}", t, joined));
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
				// same aspect as the real screen (the Ugh UI is laid out for Screen.width/height); 2x for detail
				int w = Screen.width * 2, h = Screen.height * 2;
				var rt = new RenderTexture(w, h, 24);
				foreach (var c in cams) { var o = c.targetTexture; c.targetTexture = rt; c.Render(); c.targetTexture = o; }
				RenderTexture.active = rt;
				var tex = new Texture2D(w, h, TextureFormat.RGB24, false); tex.ReadPixels(new Rect(0, 0, w, h), 0, 0); tex.Apply();
				RenderTexture.active = null;
				string dir = Path.Combine(LogDir, "screens"); Directory.CreateDirectory(dir);
				string f = Path.Combine(dir, string.Format("playrun_{0}_{1:00.0}s.png", SessionState.GetString(K + "name", "run"), t));
				File.WriteAllBytes(f, tex.EncodeToPNG());
				UnityEngine.Object.DestroyImmediate(tex); rt.Release();
				Log.AppendLine(string.Format("[{0:0.00}] [shot] {1} ({2} cameras: {3})", t, Path.GetFileName(f), cams.Count, string.Join(", ", cams.Select(c => c.name).ToArray())));
				var player = GameObject.FindGameObjectWithTag("Player");
				if (player != null) try { Log.AppendLine(string.Format("[{0:0.00}] [player] {1} pos {2} fwd {3} lap {4} place {5}", t, player.name, player.transform.position, player.transform.forward, RaceManager.GetCarLap(player), RaceManager.GetCarPosition(player))); } catch (Exception) { Log.AppendLine("[player] " + player.name + " pos " + player.transform.position); }
				LogButtons(t);
				if (s_FpsFrame >= 0 && t > s_FpsTime) Log.AppendLine(string.Format("[{0:0.00}] [fps] {1:0.0} (target {2}, vSync {3})", t, (Time.frameCount - s_FpsFrame) / (t - s_FpsTime), Application.targetFrameRate, QualitySettings.vSyncCount));
				s_FpsFrame = Time.frameCount; s_FpsTime = t;
			}
			catch (Exception e) { Log.AppendLine("[shot failed] " + e.Message); }
		}

		// "spawnai@t": every rival prefab (Resources/cart assets/ai carts) is placed in a row 30 units above the player,
		// without its driving scripts, playing its driving animation; the next "closeups" photographs them too
		static readonly List<Transform> s_Spawned = new List<Transform>();
		static void SpawnAllAi(float t, bool everyClip = false)
		{
			var player = GameObject.FindGameObjectWithTag("Player");
			if (player == null) return;
			string[] clipKinds = everyClip ? new[] { "driving", "turnLeft", "turnRight", "cheering", "handsUp", "fist", "wave", "idle", "sitting", "DefaultTake", "blendL1", "blendR05", "blendR1" } : new[] { "driving" };
			int row = 0;
			foreach (var prefab in Resources.LoadAll<GameObject>("cart assets/ai carts").Concat(everyClip ? Resources.LoadAll<GameObject>("cart assets/characters") : new GameObject[0]))
			{
				for (int col = 0; col < clipKinds.Length; col++)
				{
					var go = UnityEngine.Object.Instantiate(prefab, player.transform.position + Vector3.up * (30f + 10f * col) + player.transform.right * (10f * row - 60f), player.transform.rotation);
					go.name = "spawn_" + prefab.name + (everyClip ? "_" + clipKinds[col] : "");
					foreach (var mb in go.GetComponentsInChildren<MonoBehaviour>(true)) if (mb.GetType().Assembly.GetName().Name == "Assembly-CSharp") mb.enabled = false;
					foreach (var a in go.GetComponentsInChildren<Animation>(true))
					{
						var names = a.Cast<AnimationState>().Select(s => s.name).ToList();
						string kind = clipKinds[col];
						System.Func<string, string> find = k => names.FirstOrDefault(n => n.EndsWith("_" + k, StringComparison.OrdinalIgnoreCase));
						string clip = null;
						if (kind == "DefaultTake") { clip = names.FirstOrDefault(n => n == "Default Take"); if (clip != null) { a[clip].wrapMode = WrapMode.Loop; a.Play(clip); } }
						else if (kind.StartsWith("blend"))
						{
							// as AnimationDriver in a race: "driving" looping plus a turn clip blended in (ClampForever)
							clip = find("driving"); string turn = find(kind[5] == 'L' ? "turnLeft" : "turnRight");
							if (clip != null) { a[clip].wrapMode = WrapMode.Loop; a.Play(clip); }
							if (turn != null) { a[turn].wrapMode = WrapMode.ClampForever; a.Blend(turn, kind.EndsWith("05") ? 0.5f : 1f); }
						}
						else { clip = find(kind); if (clip != null) { a[clip].wrapMode = WrapMode.Loop; a.Play(clip); } }
						if (!everyClip) Log.AppendLine(string.Format("[{0:0.00}] [spawn] {1} anim {2} clips {3}", t, go.name, clip ?? "-", string.Join(",", a.Cast<AnimationState>().Select(s => s.name).ToArray())));
					}
					s_Spawned.Add(go.transform);
				}
				row++;
			}
		}

		// "closeups@t": a front and a side close-up of every kart (and its driver) with a temporary camera that copies
		// the race camera's culling mask, plus the skinned meshes of each kart (to spot broken characters)
		static void CloseUps(float t)
		{
			var main = UnityEngine.Object.FindObjectsByType<Camera>(FindObjectsSortMode.None).Where(c => c.enabled && c.gameObject.activeInHierarchy && !c.name.Contains("UghCamera")).OrderByDescending(c => c.depth).FirstOrDefault();
			string dir = Path.Combine(LogDir, "screens"); Directory.CreateDirectory(dir);
			var karts = UnityEngine.Object.FindObjectsByType<CarCollider>(FindObjectsSortMode.None).Select(c => c.transform).Where(x => !s_Spawned.Contains(x)).Concat(s_Spawned.Where(x => x != null)).ToList();
			foreach (var kart in karts)
			{
				foreach (var smr in kart.GetComponentsInChildren<SkinnedMeshRenderer>(true))
				{
					var m = smr.sharedMesh;
					Log.AppendLine(string.Format("[{0:0.00}] [skin] {1} / {2}: mesh {3} verts {4} bones {5}/{6} bindposes {7} weights {8} bounds {9} mats {10}", t, kart.name, smr.name,
						m != null ? m.name : "null", m != null ? m.vertexCount : 0, smr.bones.Count(b => b != null), smr.bones.Length, m != null ? m.bindposes.Length : 0,
						m != null ? m.boneWeights.Length : 0, smr.bounds.size.ToString("F2"), string.Join("+", smr.sharedMaterials.Select(x => x == null ? "null" : x.name + "(" + x.shader.name + ")").ToArray())));
				}
				for (int side = 0; side < 2; side++)
				{
					var go = new GameObject("closeup cam");
					var cam = go.AddComponent<Camera>();
					if (main != null) { cam.cullingMask = main.cullingMask; cam.clearFlags = main.clearFlags; cam.backgroundColor = main.backgroundColor; }
					cam.fieldOfView = 40f; cam.nearClipPlane = 0.1f;
					Vector3 dirv = side == 0 ? kart.forward : kart.right;
					go.transform.position = kart.position + dirv * 4.5f + kart.up * 1.8f;
					go.transform.LookAt(kart.position + kart.up * 1.0f);
					var rt = new RenderTexture(640, 480, 24); cam.targetTexture = rt; cam.Render();
					RenderTexture.active = rt;
					var tex = new Texture2D(640, 480, TextureFormat.RGB24, false); tex.ReadPixels(new Rect(0, 0, 640, 480), 0, 0); tex.Apply();
					RenderTexture.active = null;
					string f = Path.Combine(dir, string.Format("playrun_{0}_close_{1}_{2}.png", SessionState.GetString(K + "name", "run"), kart.name.Replace(" ", "_"), side == 0 ? "front" : "side"));
					File.WriteAllBytes(f, tex.EncodeToPNG());
					UnityEngine.Object.DestroyImmediate(tex); rt.Release(); UnityEngine.Object.DestroyImmediate(go);
				}
				Log.AppendLine(string.Format("[{0:0.00}] [closeup] {1}", t, kart.name));
			}
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
				if (tn == "texts")
				{
					// every visible TextMesh: text, world position and scale (to find stray / oversized labels)
					foreach (var tm in UnityEngine.Object.FindObjectsByType<TextMesh>(FindObjectsSortMode.None).Where(t => t.gameObject.activeInHierarchy))
					{
						var r = tm.GetComponent<Renderer>();
						Log.AppendLine(string.Format("[dump] text '{0}' on '{1}' pos {2} lossyScale {3} charSize {4} size {5} renderer {6}",
							(tm.text ?? "").Replace("\n", "\\n"), tm.transform.parent != null ? tm.transform.parent.name + "/" + tm.name : tm.name,
							tm.transform.position, tm.transform.lossyScale, tm.characterSize, r != null ? r.bounds.size.ToString() : "-", r != null && r.enabled));
					}
					continue;
				}
				if (tn == "lm")
				{
					// lightmaps in use and a sample of lightmapped renderers per shader
					var lms = LightmapSettings.lightmaps;
					Log.AppendLine(string.Format("[dump] lm mode {0} count {1} first {2}", LightmapSettings.lightmapsMode, lms.Length, lms.Length > 0 && lms[0].lightmapColor != null ? lms[0].lightmapColor.name + " " + lms[0].lightmapColor.format : "-"));
					foreach (var g in UnityEngine.Object.FindObjectsByType<Renderer>(FindObjectsSortMode.None).Where(r => r.sharedMaterial != null).GroupBy(r => r.sharedMaterial.shader.name))
					{
						var list = g.ToList();
						Log.AppendLine(string.Format("[dump] lm shader '{0}': {1} renderers, {2} lightmapped (index {3}), keywords {4}", g.Key, list.Count, list.Count(r => r.lightmapIndex >= 0 && r.lightmapIndex < 65534),
							string.Join("/", list.Select(r => r.lightmapIndex).Distinct().Take(5).Select(x => x.ToString()).ToArray()), string.Join(" ", list[0].sharedMaterial.shaderKeywords)));
					}
					continue;
				}
				if (tn.StartsWith("wp:"))
				{
					// closest waypoint to x_y_z and the DoRoadBoundaries test there (kart width 2.4): margin >= 0 pushes the kart
					var xyz = tn.Substring(3).Split('_').Select(s => float.Parse(s, System.Globalization.CultureInfo.InvariantCulture)).ToArray();
					var pos = new Vector3(xyz[0], xyz[1], xyz[2]);
					var wp = WaypointLogic.FindClosestWaypoint(pos, false);
					if (wp == null) { Log.AppendLine("[dump] wp " + pos + ": none"); continue; }
					Vector3 tp = wp.GetTrackPoint(pos), wo = wp.GetWallOffsetForPoint(pos);
					Vector3 d = tp + wo - pos; d.y = 0f;
					float wd = wp.GetWallDistanceAtPoint(pos);
					Log.AppendLine(string.Format("[dump] wp {0}: closest '{1}' at {2} walls {3} trackPoint {4} wallOffset {5} wallDist {6:0.00} dist {7:0.00} margin {8:0.00} -> pushed to {9}",
						pos, wp.name, wp.transform.position.ToString("F1"), wp.projectsWalls, tp.ToString("F1"), wo.ToString("F2"), wd, d.magnitude, d.magnitude + 2.4f - wd,
						(tp + wo - d.normalized * (wd - 2.4f)).ToString("F1")));
					continue;
				}
				if (tn.StartsWith("raydown:"))
				{
					// every hit of a downward ray (layers Ground | Collide, as ShadowBlob) from x_y_z, triggers included
					var xyz = tn.Substring(8).Split('_').Select(s => float.Parse(s, System.Globalization.CultureInfo.InvariantCulture)).ToArray();
					var from = new Vector3(xyz[0], xyz[1], xyz[2]);
					foreach (var h in Physics.RaycastAll(from, Vector3.down, 200f, 1280, QueryTriggerInteraction.Collide).OrderBy(h => h.distance))
						Log.AppendLine(string.Format("[dump] raydown {0}: '{1}' {2} layer {3}{4} point {5} normal {6}", from, PathOf(h.collider.transform), h.collider.GetType().Name,
							h.collider.gameObject.layer, h.collider.isTrigger ? " trigger" : "", h.point.ToString("F2"), h.normal.ToString("F2")));
					continue;
				}
				if (tn.StartsWith("cols:"))
				{
					// colliders whose hierarchy path contains the text (or whose GameObject has a component of that type): layer, trigger, world bounds
					string key = tn.Substring(5);
					foreach (var c in UnityEngine.Object.FindObjectsByType<Collider>(FindObjectsSortMode.None))
					{
						string path = PathOf(c.transform);
						if (!path.Contains(key) && c.GetComponent(key) == null) continue;
						Log.AppendLine(string.Format("[dump] col '{0}' {1} layer {2}{3} bounds min {4} max {5}", path, c.GetType().Name, c.gameObject.layer,
							c.isTrigger ? " trigger" : "", c.bounds.min, c.bounds.max));
					}
					continue;
				}
				if (tn == "badmat")
				{
					// renderers that would draw magenta: no material, or a shader that is missing / unsupported
					foreach (var r in UnityEngine.Object.FindObjectsByType<Renderer>(FindObjectsInactive.Include, FindObjectsSortMode.None))
					{
						foreach (var m in r.sharedMaterials)
						{
							bool bad = m == null || m.shader == null || !m.shader.isSupported || m.shader.name == "Hidden/InternalErrorShader";
							if (!bad) continue;
							var p = r.transform; string path = p.name;
							while (p.parent != null) { p = p.parent; path = p.name + "/" + path; }
							Log.AppendLine(string.Format("[dump] badmat {0} '{1}' active {2} material {3} shader {4}", r.GetType().Name, path, r.gameObject.activeInHierarchy,
								m == null ? "null" : m.name, m == null || m.shader == null ? "null" : m.shader.name));
						}
					}
					continue;
				}
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
