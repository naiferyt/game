// Stage 4 test harness for the built player (RECONSTRUIDO: tooling). Inactive unless the player is started with
// -recoveryTest. Mirrors the editor PlayModeRunner specs so the same scripts run in the .exe at any resolution:
//   DSSRacer.exe -recoveryTest -rtName ui1080 -rtSeconds 60 -rtShots "5,20" -rtClicks "0.50,0.18@8;obj:Go Button@32;auto@40-60;key:W@1-2"
//                -screen-width 1920 -screen-height 1080 -screen-fullscreen 0
// Output: <build>/recovery_tests/<name>.log and <name>_<t>.png (next to the executable).
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RecoveryPlayerTest : MonoBehaviour
{
	private readonly StringBuilder log = new StringBuilder();

	private readonly List<KeyValuePair<float, string>> events = new List<KeyValuePair<float, string>>();

	private readonly List<Vector2> autoRanges = new List<Vector2>();

	private string testName;

	private string outDir;

	private float seconds;

	private float start;

	private bool autoOn;

	private int fpsFrame = -1;

	private float fpsTime;

	private static string Arg(string name, string def)
	{
		string[] a = Environment.GetCommandLineArgs();
		int i = Array.IndexOf(a, name);
		if (i < 0 || i + 1 >= a.Length || a[i + 1].StartsWith("-"))
		{
			return def;
		}
		return a[i + 1];
	}

	private static float F(string s)
	{
		return float.Parse(s, CultureInfo.InvariantCulture);
	}

	[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
	private static void Install()
	{
		if (Application.isEditor || !Environment.GetCommandLineArgs().Contains("-recoveryTest"))
		{
			return;
		}
		RecoveryTestInput.PlayerTestEnabled = true;
		GameObject go = new GameObject("+RecoveryPlayerTest");
		DontDestroyOnLoad(go);
		go.AddComponent<RecoveryPlayerTest>();
	}

	private void Awake()
	{
		testName = Arg("-rtName", "run");
		seconds = F(Arg("-rtSeconds", "30"));
		outDir = Path.Combine(Path.GetDirectoryName(Application.dataPath), "recovery_tests");
		Directory.CreateDirectory(outDir);
		foreach (string p in Arg("-rtShots", "").Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
		{
			events.Add(new KeyValuePair<float, string>(F(p), "shot"));
		}
		foreach (string c in Arg("-rtClicks", "").Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries))
		{
			string[] at = c.Split('@');
			if (at.Length != 2)
			{
				continue;
			}
			if (at[0] == "auto")
			{
				string[] ft = at[1].Split('-');
				autoRanges.Add(new Vector2(F(ft[0]), F(ft[1])));
			}
			else if (at[0].StartsWith("res:") || at[0] == "barrel" || at[0] == "wipeout")
			{
				events.Add(new KeyValuePair<float, string>(F(at[1]), at[0]));
			}
			else if (at[0].StartsWith("key:"))
			{
				string[] ft = at[1].Split('-');
				events.Add(new KeyValuePair<float, string>(F(ft[0]), "keydown:" + at[0].Substring(4)));
				events.Add(new KeyValuePair<float, string>(F(ft[1]), "keyup:" + at[0].Substring(4)));
			}
			else
			{
				events.Add(new KeyValuePair<float, string>(F(at[1]), "click:" + at[0]));
			}
		}
		events.Sort((a, b) => a.Key.CompareTo(b.Key));
		start = Time.realtimeSinceStartup;
		SceneManager.activeSceneChanged += (a, b) => Line("[scene] -> " + b.name);
		Application.logMessageReceived += OnLog;
		Line("[run] player " + Screen.width + "x" + Screen.height + " fullscreen " + Screen.fullScreen + " target fps " + Application.targetFrameRate);
	}

	private float T
	{
		get { return Time.realtimeSinceStartup - start; }
	}

	private void Line(string s)
	{
		log.AppendLine(string.Format(CultureInfo.InvariantCulture, "[{0:0.00}] {1}", T, s));
	}

	private void OnLog(string msg, string stack, LogType type)
	{
		if (type == LogType.Exception || type == LogType.Error || type == LogType.Assert)
		{
			Line("[" + type + "] " + msg + "\n      " + stack.Replace("\n", "\n      ").Trim());
		}
	}

	private void Update()
	{
		float t = T;
		while (events.Count > 0 && t >= events[0].Key)
		{
			string e = events[0].Value;
			events.RemoveAt(0);
			if (e == "shot")
			{
				Shot(t);
			}
			else if (e.StartsWith("res:"))
			{
				string[] wh = e.Substring(4).Split('x');
				Screen.SetResolution(int.Parse(wh[0]), int.Parse(wh[1]), false);
				Line("[res] " + e.Substring(4));
			}
			else if (e == "barrel" || e == "wipeout")
			{
				HitPlayer(e, t);
			}
			else if (e.StartsWith("keydown:"))
			{
				RecoveryTestInput.SetKey((KeyCode)Enum.Parse(typeof(KeyCode), e.Substring(8)), true);
			}
			else if (e.StartsWith("keyup:"))
			{
				RecoveryTestInput.SetKey((KeyCode)Enum.Parse(typeof(KeyCode), e.Substring(6)), false);
			}
			else
			{
				Click(e.Substring(6));
			}
		}
		AutoPilot(t);
		NanWatch(t);
		if (t >= seconds)
		{
			Line("[run] end");
			File.WriteAllText(Path.Combine(outDir, testName + ".log"), log.ToString());
			Application.Quit();
			enabled = false;
		}
	}

	// test-only: an exploding barrel dropped 6 units in front of the player, or a wipeout applied directly
	private void HitPlayer(string what, float t)
	{
		GameObject player = GameObject.FindGameObjectWithTag("Player");
		if (player == null)
		{
			return;
		}
		CarCollider cc = player.GetComponent<CarCollider>();
		bool jump = cc != null && cc.EffectMgr != null && cc.EffectMgr.HasEffect(typeof(GuidedJumpEffect));
		if (what == "wipeout" && cc != null && cc.EffectMgr != null)
		{
			WipeoutEffect w = new WipeoutEffect(player);
			w.power = 50;
			w.time = 1.5f;
			cc.EffectMgr.AddEffect(w);
		}
		if (what == "barrel")
		{
			BarrelSpawner spawner = UnityEngine.Object.FindAnyObjectByType<BarrelSpawner>();
			BarrelLauncher launcher = UnityEngine.Object.FindAnyObjectByType<BarrelLauncher>();
			GameObject prefab = spawner != null ? spawner.barrelPrefab : (launcher != null ? launcher.barrelPrefab : null);
			if (prefab != null)
			{
				UnityEngine.Object.Instantiate(prefab, player.transform.position + player.transform.forward * 6f + Vector3.up, prefab.transform.rotation);
			}
		}
		Line("[" + what + "] player at " + player.transform.position + " inJump " + jump);
	}

	// every frame: the first non-finite kart / camera value is logged and written to disk at once (a crash loses the rest)
	private readonly HashSet<string> nanReported = new HashSet<string>();

	private static bool Bad(float f)
	{
		return float.IsNaN(f) || float.IsInfinity(f);
	}

	private static bool Bad(Vector3 v)
	{
		return Bad(v.x) || Bad(v.y) || Bad(v.z);
	}

	private static bool Bad(Quaternion q)
	{
		return Bad(q.x) || Bad(q.y) || Bad(q.z) || Bad(q.w);
	}

	private void NanWatch(float t)
	{
		foreach (CarCollider cc in UnityEngine.Object.FindObjectsByType<CarCollider>(FindObjectsSortMode.None))
		{
			GimpedCarAI ai = cc.GetComponent<GimpedCarAI>();
			string bad = Bad(cc.transform.position) ? "position" : Bad(cc.transform.rotation) ? "rotation" : Bad(cc.GetVelocity()) ? "velocity" : (ai != null && ai.enabled && Bad(ai.LinearVelocity)) ? "aiSpeed" : null;
			if (bad != null && nanReported.Add(cc.name + bad))
			{
				string fx = cc.EffectMgr != null ? string.Join("+", new[] { typeof(GuidedJumpEffect), typeof(FlipEffect), typeof(WipeoutEffect), typeof(TeleportEffect), typeof(BoosterEffect), typeof(SkidEffect), typeof(SlowdownEffect), typeof(ShockedEffect) }.Where(ty => cc.EffectMgr.HasEffect(ty)).Select(ty => ty.Name).ToArray()) : "";
				Line("[NAN] " + cc.name + " bad " + bad + " pos " + cc.transform.position + " rot " + cc.transform.rotation + " vel " + cc.GetVelocity() + " aiSpeed " + (ai != null ? ai.LinearVelocity.ToString(CultureInfo.InvariantCulture) : "-") + " fx " + fx + " air " + cc.isInAir);
				File.WriteAllText(Path.Combine(outDir, testName + ".log"), log.ToString());
			}
		}
		foreach (Camera cam in Camera.allCameras)
		{
			if ((Bad(cam.transform.position) || Bad(cam.transform.rotation)) && nanReported.Add("cam " + cam.name))
			{
				Line("[NAN] camera " + cam.name + " pos " + cam.transform.position + " rot " + cam.transform.rotation);
				File.WriteAllText(Path.Combine(outDir, testName + ".log"), log.ToString());
			}
		}
	}

	private void Click(string what)
	{
		if (what.StartsWith("obj:"))
		{
			string name = what.Substring(4);
			GameObject go = FindObjectsByType<Transform>(FindObjectsSortMode.None).Select(x => x.gameObject).FirstOrDefault(g => g.name == name && g.activeInHierarchy);
			if (go == null)
			{
				Line("[click] obj '" + name + "' NOT FOUND");
				return;
			}
			Collider col = go.GetComponent<Collider>();
			Renderer r = go.GetComponentInChildren<Renderer>();
			Vector3 c = (col != null) ? col.bounds.center : ((r != null) ? r.bounds.center : go.transform.position);
			Camera cam = FindObjectsByType<Camera>(FindObjectsSortMode.None).Where(k => k.enabled && (k.cullingMask & (1 << go.layer)) != 0).OrderByDescending(k => k.depth).FirstOrDefault();
			if (cam == null)
			{
				Line("[click] obj '" + name + "' has no camera");
				return;
			}
			Vector3 sp = cam.WorldToScreenPoint(c);
			Vector2 n = new Vector2(sp.x / Screen.width, sp.y / Screen.height);
			Line("[click] obj '" + name + "' -> " + n);
			RecoveryTestInput.Click(n);
		}
		else
		{
			string[] xy = what.Split(',');
			Vector2 n = new Vector2(F(xy[0]), F(xy[1]));
			Line("[click] " + n);
			RecoveryTestInput.Click(n);
		}
	}

	private void Shot(float t)
	{
		string file = Path.Combine(outDir, string.Format(CultureInfo.InvariantCulture, "{0}_{1:00.0}s.png", testName, t));
		ScreenCapture.CaptureScreenshot(file);
		string extra = "";
		if (fpsFrame >= 0 && t > fpsTime)
		{
			extra = string.Format(CultureInfo.InvariantCulture, " fps {0:0.0}", (Time.frameCount - fpsFrame) / (t - fpsTime));
		}
		fpsFrame = Time.frameCount;
		fpsTime = t;
		GameObject player = GameObject.FindGameObjectWithTag("Player");
		AudioSource[] sources = FindObjectsByType<AudioSource>(FindObjectsSortMode.None);
		string playing = string.Join(", ", sources.Where(a => a.isPlaying && a.clip != null).Select(a => a.clip.name).Distinct().Take(12).ToArray());
		Line("[audio] " + sources.Count(a => a.isPlaying) + " playing: " + playing);
		Line("[shot] " + Path.GetFileName(file) + " " + Screen.width + "x" + Screen.height + extra + (player != null ? " player " + player.transform.position : ""));
	}

	private void AutoPilot(float t)
	{
		bool on = autoRanges.Any(r => t >= r.x && t < r.y);
		if (on != autoOn)
		{
			autoOn = on;
			RecoveryTestInput.SetKey(KeyCode.W, on);
			if (!on)
			{
				RecoveryTestInput.SetKey(KeyCode.A, false);
				RecoveryTestInput.SetKey(KeyCode.D, false);
			}
		}
		if (!on)
		{
			return;
		}
		GameObject player = GameObject.FindGameObjectWithTag("Player");
		if (player == null)
		{
			return;
		}
		Vector3 pos = player.transform.position;
		WaypointLogic next = WaypointLogic.FindNextWaypoint(pos);
		if (next == null)
		{
			return;
		}
		Vector3 target = next.transform.position;
		if (next.forwardPoint != null && (target - pos).magnitude < 12f)
		{
			target = next.forwardPoint.transform.position;
		}
		Vector3 to = target - pos;
		to.y = 0f;
		Vector3 fwd = player.transform.forward;
		fwd.y = 0f;
		float angle = Vector3.SignedAngle(fwd, to, Vector3.up);
		RecoveryTestInput.SetKey(KeyCode.D, angle > 4f);
		RecoveryTestInput.SetKey(KeyCode.A, angle < -4f);
	}
}
