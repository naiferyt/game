// Stage 0 editor tools (RECONSTRUIDO/ADAPTADO-U6 tooling — not game logic). Batch entry points:
//   Unity -batchmode -projectPath <p> -executeMethod DSSRecovery.Stage0.<Method> -quit
// ApplyProjectSettings, RemapShaders, ConvertLegacyParticles, InstallLightmaps, Validate, RunAll
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using UnityEditor;
using UnityEditor.Build;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace DSSRecovery
{
	public static class Stage0
	{
		const string DataDir = "Assets/_Recovery/Data/";
		static string LogDir { get { return Path.GetFullPath(Path.Combine(Application.dataPath, "..", "..", "logs")); } }
		static readonly StringBuilder Log = new StringBuilder();

		static void L(string s) { Log.AppendLine(s); Debug.Log("[Stage0] " + s); }

		static void Flush(string name)
		{
			Directory.CreateDirectory(LogDir);
			File.WriteAllText(Path.Combine(LogDir, name), Log.ToString());
			Log.Length = 0;
		}

		[MenuItem("DSS Recovery/Stage 0/Run All")]
		public static void RunAll()
		{
			ApplyProjectSettings();
			RemapShaders();
			ConvertLegacyParticles();
			InstallLightmaps();
			Validate();
		}

		// ------------------------------------------------------------------ project settings
		[MenuItem("DSS Recovery/Stage 0/Apply Project Settings")]
		public static void ApplyProjectSettings()
		{
			PlayerSettings.colorSpace = ColorSpace.Gamma;   // original: m_ActiveColorSpace 0
			PlayerSettings.SetScriptingBackend(NamedBuildTarget.Standalone, ScriptingImplementation.Mono2x);
			var ps = AssetDatabase.LoadAllAssetsAtPath("ProjectSettings/ProjectSettings.asset").FirstOrDefault();
			if (ps != null)
			{
				var so = new SerializedObject(ps);
				var ih = so.FindProperty("activeInputHandler");
				if (ih != null) { ih.intValue = 0; L("activeInputHandler = 0 (Input Manager, as the original)"); }
				so.ApplyModifiedPropertiesWithoutUndo();
			}
			// Lightmaps baked by Unity 4 for iOS are dLDR -> decode them the same way on PC (Low quality encoding)
			bool set = false;
			foreach (var m in typeof(PlayerSettings).GetMethods(BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.Public))
			{
				if (!m.Name.StartsWith("SetLightmapEncodingQuality")) continue;
				var p = m.GetParameters();
				try
				{
					if (p.Length == 2 && p[0].ParameterType == typeof(BuildTargetGroup))
					{ m.Invoke(null, new object[] { BuildTargetGroup.Standalone, Enum.ToObject(p[1].ParameterType, 0) }); set = true; }
					else if (p.Length == 2 && p[0].ParameterType == typeof(BuildTarget))
					{ m.Invoke(null, new object[] { BuildTarget.StandaloneWindows64, Enum.ToObject(p[1].ParameterType, 0) }); set = true; }
					else if (p.Length == 2 && p[0].ParameterType == typeof(NamedBuildTarget))
					{ m.Invoke(null, new object[] { NamedBuildTarget.Standalone, Enum.ToObject(p[1].ParameterType, 0) }); set = true; }
				}
				catch (Exception e) { L("lightmap encoding via " + m.Name + " failed: " + e.Message); }
				if (set) { L("lightmap encoding (Standalone) = Low/dLDR via " + m.Name); break; }
			}
			if (!set) L("WARNING: could not set lightmap encoding quality (no suitable API found)");
			AssetDatabase.SaveAssets();
			L("colorSpace=" + PlayerSettings.colorSpace + " backend=" + PlayerSettings.GetScriptingBackend(NamedBuildTarget.Standalone));
			Flush("stage0_project_settings.log");
		}

		// ------------------------------------------------------------------ shaders
		[MenuItem("DSS Recovery/Stage 0/Remap Built-in Shaders")]
		public static void RemapShaders()
		{
			var file = JsonUtility.FromJson<ShaderRemapFile>(File.ReadAllText(DataDir + "shader_remap.json"));
			var map = file.entries.ToDictionary(e => e.guid, e => e);
			// 1) delete the AssetRipper dummy copies (they shadow the real built-ins by name)
			foreach (var e in file.entries)
				if (AssetDatabase.LoadAssetAtPath<Shader>(e.path) != null) { AssetDatabase.DeleteAsset(e.path); L("deleted dummy " + e.path); }
			AssetDatabase.Refresh();
			// 2) re-point materials using the shader GUID still written in their YAML
			int changed = 0, missing = 0;
			foreach (var g in AssetDatabase.FindAssets("t:Material", new[] { "Assets" }))
			{
				string path = AssetDatabase.GUIDToAssetPath(g);
				string text = File.ReadAllText(path);
				var m = Regex.Match(text, @"m_Shader: \{fileID: -?\d+, guid: (\w+)");
				if (!m.Success || !map.ContainsKey(m.Groups[1].Value)) continue;
				var entry = map[m.Groups[1].Value];
				var sh = Shader.Find(entry.unity6Name);
				if (sh == null) { missing++; L("MISSING built-in shader '" + entry.unity6Name + "' for " + path); continue; }
				var mat = AssetDatabase.LoadAssetAtPath<Material>(path);
				mat.shader = sh; EditorUtility.SetDirty(mat); changed++;
			}
			AssetDatabase.SaveAssets();
			L("materials re-pointed to Unity 6 built-in shaders: " + changed + ", missing shaders: " + missing);
			Flush("stage0_shaders.log");
		}

		// ------------------------------------------------------------------ legacy particles
		[MenuItem("DSS Recovery/Stage 0/Convert Legacy Particles")]
		public static void ConvertLegacyParticles()
		{
			var file = JsonUtility.FromJson<LegacyParticleFile>(File.ReadAllText(DataDir + "legacy_particles_u6.json"));
			int ok = 0, fail = 0;
			foreach (var group in file.systems.GroupBy(s => s.file))
			{
				string path = group.Key;
				if (path.EndsWith(".unity"))
				{
					var scene = EditorSceneManager.OpenScene(path, OpenSceneMode.Single);
					var byId = SceneObjectsById(scene);
					foreach (var s in group)
					{
						GameObject go;
						if (byId.TryGetValue(s.goFileID, out go)) { Build(go, s); ok++; }
						else { fail++; L("NOT FOUND " + path + " go " + s.goFileID); }
					}
					EditorSceneManager.MarkSceneDirty(scene); EditorSceneManager.SaveScene(scene);
				}
				else
				{
					var assetGos = AssetDatabase.LoadAllAssetsAtPath(path).OfType<GameObject>().ToList();
					var root = PrefabUtility.LoadPrefabContents(path);
					foreach (var s in group)
					{
						var src = assetGos.FirstOrDefault(g => LocalId(g) == s.goFileID);
						var dst = src != null ? FindByPath(root, HierarchyPath(src)) : null;
						if (dst != null) { Build(dst, s); ok++; }
						else { fail++; L("NOT FOUND " + path + " go " + s.goFileID); }
					}
					PrefabUtility.SaveAsPrefabAsset(root, path);
					PrefabUtility.UnloadPrefabContents(root);
				}
			}
			L("legacy particle systems converted: " + ok + ", not found: " + fail);
			Flush("stage0_particles.log");
		}

		static long LocalId(UnityEngine.Object o)
		{
			string guid; long id;
			return AssetDatabase.TryGetGUIDAndLocalFileIdentifier(o, out guid, out id) ? id : 0;
		}

		static string HierarchyPath(GameObject g)
		{
			var parts = new List<string>();
			for (var t = g.transform; t.parent != null; t = t.parent) parts.Insert(0, t.GetSiblingIndex().ToString());
			return string.Join("/", parts.ToArray());
		}

		static GameObject FindByPath(GameObject root, string path)
		{
			var t = root.transform;
			if (path.Length > 0)
				foreach (var p in path.Split('/')) { int i = int.Parse(p); if (i >= t.childCount) return null; t = t.GetChild(i); }
			return t.gameObject;
		}

		static Dictionary<long, GameObject> SceneObjectsById(Scene scene)
		{
			var d = new Dictionary<long, GameObject>();
			foreach (var root in scene.GetRootGameObjects())
				foreach (var t in root.GetComponentsInChildren<Transform>(true))
				{
					var id = GlobalObjectId.GetGlobalObjectIdSlow(t.gameObject);
					d[(long)id.targetObjectId] = t.gameObject;
				}
			return d;
		}

		static Color32 Rgba(long v)
		{
			uint u = (uint)v;
			return new Color32((byte)(u & 0xff), (byte)((u >> 8) & 0xff), (byte)((u >> 16) & 0xff), (byte)(u >> 24));
		}

		// Mapping legacy (Ellipsoid emitter + ParticleAnimator + ParticleRenderer) -> Shuriken. ADAPTADO-U6.
		static void Build(GameObject go, LegacyParticle s)
		{
			var existing = go.GetComponent<ParticleSystem>();
			if (existing != null) UnityEngine.Object.DestroyImmediate(existing, true);
			var ps = go.AddComponent<ParticleSystem>();
			var main = ps.main;
			float avgLife = (s.minEnergy + s.maxEnergy) * 0.5f;
			bool burstOnce = s.oneShot == 1 && s.autodestruct == 1;
			main.loop = !burstOnce;
			main.duration = burstOnce ? Mathf.Max(0.05f, s.maxEnergy) : Mathf.Max(1f, s.maxEnergy);
			main.playOnAwake = s.emit == 1 && s.enabled == 1;
			main.startLifetime = new ParticleSystem.MinMaxCurve(s.minEnergy, s.maxEnergy);
			main.startSize = new ParticleSystem.MinMaxCurve(s.minSize, s.maxSize);
			main.startSpeed = 0f;
			main.startColor = Color.white;
			main.simulationSpace = s.worldSpace == 1 ? ParticleSystemSimulationSpace.World : ParticleSystemSimulationSpace.Local;
			main.scalingMode = ParticleSystemScalingMode.Shape;
			main.startRotation = s.rndRotation == 1 ? new ParticleSystem.MinMaxCurve(0f, Mathf.PI * 2f) : new ParticleSystem.MinMaxCurve(0f);
			main.maxParticles = Mathf.Clamp(Mathf.CeilToInt(s.maxEmission * Mathf.Max(s.maxEnergy, 0.01f) * 1.5f) + (s.oneShot == 1 ? Mathf.CeilToInt(s.maxEmission) : 0), 1, 5000);
			if (s.autodestruct == 1) main.stopAction = ParticleSystemStopAction.Destroy;

			var em = ps.emission;
			if (s.oneShot == 1)
			{
				em.rateOverTime = 0f;
				var burst = new ParticleSystem.Burst(0f, new ParticleSystem.MinMaxCurve(s.minEmission, s.maxEmission));
				if (!burstOnce) { burst.cycleCount = 0; burst.repeatInterval = Mathf.Max(0.01f, s.maxEnergy); }
				em.SetBursts(new[] { burst });
			}
			else em.rateOverTime = new ParticleSystem.MinMaxCurve(s.minEmission, s.maxEmission);

			var shape = ps.shape;
			Vector3 ell = s.ellipsoid.V;
			if (ell.sqrMagnitude > 0f)
			{
				shape.enabled = true; shape.shapeType = ParticleSystemShapeType.Sphere; shape.radius = 1f; shape.scale = ell;
				shape.radiusThickness = Mathf.Clamp01(1f - s.minEmitterRange);
			}
			else shape.enabled = false;

			Vector3 lv = s.localVelocity.V, wv = s.worldVelocity.V, rv = s.rndVelocity.V;
			if (lv.sqrMagnitude > 0f || wv.sqrMagnitude > 0f || rv.sqrMagnitude > 0f)
			{
				var vol = ps.velocityOverLifetime; vol.enabled = true;
				bool local = lv.sqrMagnitude > 0f || wv.sqrMagnitude == 0f;
				vol.space = local ? ParticleSystemSimulationSpace.Local : ParticleSystemSimulationSpace.World;
				Vector3 v = local ? lv + wv : wv;
				vol.x = new ParticleSystem.MinMaxCurve(v.x - rv.x * 0.5f, v.x + rv.x * 0.5f);
				vol.y = new ParticleSystem.MinMaxCurve(v.y - rv.y * 0.5f, v.y + rv.y * 0.5f);
				vol.z = new ParticleSystem.MinMaxCurve(v.z - rv.z * 0.5f, v.z + rv.z * 0.5f);
			}
			if (s.emitterVelocityScale != 0f && s.worldSpace == 1)
			{
				var inh = ps.inheritVelocity; inh.enabled = true; inh.mode = ParticleSystemInheritVelocityMode.Initial;
				inh.curve = new ParticleSystem.MinMaxCurve(s.emitterVelocityScale);
			}
			if (s.angularVelocity != 0f || s.rndAngularVelocity != 0f)
			{
				var rol = ps.rotationOverLifetime; rol.enabled = true;
				rol.z = new ParticleSystem.MinMaxCurve((s.angularVelocity - s.rndAngularVelocity) * Mathf.Deg2Rad, (s.angularVelocity + s.rndAngularVelocity) * Mathf.Deg2Rad);
			}
			if (s.animateColor == 1 && s.colors != null && s.colors.Length == 5)
			{
				var col = ps.colorOverLifetime; col.enabled = true;
				var ck = new GradientColorKey[5]; var ak = new GradientAlphaKey[5];
				for (int i = 0; i < 5; i++) { Color c = Rgba(s.colors[i]); ck[i] = new GradientColorKey(c, i / 4f); ak[i] = new GradientAlphaKey(c.a, i / 4f); }
				var gr = new Gradient(); gr.SetKeys(ck, ak); col.color = new ParticleSystem.MinMaxGradient(gr);
			}
			if (s.sizeGrow != 0f)
			{
				float end = Mathf.Max(0f, 1f + s.sizeGrow * avgLife), mul = Mathf.Max(1f, end);
				var sol = ps.sizeOverLifetime; sol.enabled = true;
				sol.size = new ParticleSystem.MinMaxCurve(mul, new AnimationCurve(new Keyframe(0f, 1f / mul), new Keyframe(1f, end / mul)));
			}
			Vector3 f = s.force.V, rf = s.rndForce.V;
			if (f.sqrMagnitude > 0f || rf.sqrMagnitude > 0f)
			{
				var fol = ps.forceOverLifetime; fol.enabled = true; fol.space = ParticleSystemSimulationSpace.World;
				fol.x = new ParticleSystem.MinMaxCurve(f.x - rf.x * 0.5f, f.x + rf.x * 0.5f);
				fol.y = new ParticleSystem.MinMaxCurve(f.y - rf.y * 0.5f, f.y + rf.y * 0.5f);
				fol.z = new ParticleSystem.MinMaxCurve(f.z - rf.z * 0.5f, f.z + rf.z * 0.5f);
				fol.randomized = rf.sqrMagnitude > 0f;
			}
			if (s.damping > 0f && s.damping < 1f)
			{
				var lim = ps.limitVelocityOverLifetime; lim.enabled = true;
				lim.limit = new ParticleSystem.MinMaxCurve(10000f);
				lim.drag = new ParticleSystem.MinMaxCurve(-30f * Mathf.Log(s.damping));   // original ran at 30 fps on iOS
				lim.multiplyDragByParticleSize = false; lim.multiplyDragByParticleVelocity = false;
			}
			if (s.uvTilesX * s.uvTilesY > 1)
			{
				var tsa = ps.textureSheetAnimation; tsa.enabled = true; tsa.numTilesX = s.uvTilesX; tsa.numTilesY = s.uvTilesY;
				tsa.cycleCount = Mathf.Max(1, Mathf.RoundToInt(s.uvCycles));
			}
			var r = go.GetComponent<ParticleSystemRenderer>();
			if (!string.IsNullOrEmpty(s.materialGuid))
			{
				var mat = AssetDatabase.LoadAssetAtPath<Material>(AssetDatabase.GUIDToAssetPath(s.materialGuid));
				if (mat != null) r.sharedMaterial = mat; else L("material not found " + s.materialGuid + " on " + go.name);
			}
			switch (s.renderMode)
			{
				case 3: r.renderMode = ParticleSystemRenderMode.Stretch; r.lengthScale = s.lengthScale; r.velocityScale = s.velocityScale; r.cameraVelocityScale = s.cameraVelocityScale; break;
				case 4: r.renderMode = ParticleSystemRenderMode.HorizontalBillboard; break;
				case 5: r.renderMode = ParticleSystemRenderMode.VerticalBillboard; break;
				case 2: r.renderMode = ParticleSystemRenderMode.Billboard; r.sortMode = ParticleSystemSortMode.Distance; break;
				default: r.renderMode = ParticleSystemRenderMode.Billboard; break;
			}
			r.maxParticleSize = s.maxParticleSize;
			r.shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.Off;
			r.receiveShadows = false;
			if (s.enabled == 0) r.enabled = false;
			if (s.tangentVelocity.V.sqrMagnitude > 0f || s.worldRotationAxis.V.sqrMagnitude > 0f || s.localRotationAxis.V.sqrMagnitude > 0f)
				L("note: " + go.name + " uses tangentVelocity/rotationAxis (not mapped)");
		}

		// ------------------------------------------------------------------ lightmaps
		[MenuItem("DSS Recovery/Stage 0/Install Legacy Lightmaps")]
		public static void InstallLightmaps()
		{
			var file = JsonUtility.FromJson<LightmapFile>(File.ReadAllText(DataDir + "lightmaps_u6.json"));
			foreach (var sc in file.scenes)
			{
				var tex = new List<Texture2D>();
				foreach (var g in sc.lightmapGuids)
				{
					string p = AssetDatabase.GUIDToAssetPath(g);
					var imp = AssetImporter.GetAtPath(p) as TextureImporter;
					if (imp != null && imp.textureType != TextureImporterType.Lightmap) { imp.textureType = TextureImporterType.Lightmap; imp.SaveAndReimport(); }
					tex.Add(AssetDatabase.LoadAssetAtPath<Texture2D>(p));
				}
				var scene = EditorSceneManager.OpenScene(sc.scene, OpenSceneMode.Single);
				var byId = new Dictionary<long, Renderer>();
				foreach (var root in scene.GetRootGameObjects())
					foreach (var r in root.GetComponentsInChildren<Renderer>(true))
						byId[(long)GlobalObjectId.GetGlobalObjectIdSlow(r).targetObjectId] = r;
				var old = scene.GetRootGameObjects().Where(g => g.name == "__LegacyLightmapRestorer").ToArray();
				foreach (var o in old) UnityEngine.Object.DestroyImmediate(o);
				var go = new GameObject("__LegacyLightmapRestorer");
				var comp = go.AddComponent<LegacyLightmapRestorer>();
				var rs = new List<Renderer>(); var idx = new List<int>(); var so = new List<Vector4>(); int miss = 0;
				foreach (var lr in sc.renderers)
				{
					Renderer r;
					if (!byId.TryGetValue(lr.fileID, out r)) { miss++; continue; }
					rs.Add(r); idx.Add(lr.index); so.Add(lr.so.V);
				}
				comp.lightmaps = tex.ToArray(); comp.renderers = rs.ToArray(); comp.lightmapIndices = idx.ToArray(); comp.scaleOffsets = so.ToArray();
				EditorSceneManager.MarkSceneDirty(scene); EditorSceneManager.SaveScene(scene);
				L(sc.scene + ": lightmaps " + tex.Count(t => t != null) + "/" + tex.Count + ", renderers " + rs.Count + " (not found " + miss + ")");
			}
			Flush("stage0_lightmaps.log");
		}

		// ------------------------------------------------------------------ validation
		[MenuItem("DSS Recovery/Stage 0/Validate")]
		public static void Validate()
		{
			int missingScripts = 0, badMaterials = 0, emptyMeshes = 0, badColliders = 0, badSkins = 0;
			var details = new List<string>();
			foreach (var g in AssetDatabase.FindAssets("t:Prefab", new[] { "Assets" }))
			{
				string p = AssetDatabase.GUIDToAssetPath(g);
				var root = AssetDatabase.LoadAssetAtPath<GameObject>(p);
				if (root == null) continue;
				foreach (var t in root.GetComponentsInChildren<Transform>(true))
				{
					int n = GameObjectUtility.GetMonoBehavioursWithMissingScriptCount(t.gameObject);
					if (n > 0) { missingScripts += n; details.Add("missing script: " + p + " :: " + t.name); }
				}
				CheckGeometry(root, p, details, ref emptyMeshes, ref badColliders, ref badSkins);
			}
			foreach (var g in AssetDatabase.FindAssets("t:Material", new[] { "Assets" }))
			{
				string p = AssetDatabase.GUIDToAssetPath(g);
				var m = AssetDatabase.LoadAssetAtPath<Material>(p);
				if (m == null || m.shader == null || m.shader.name == "Hidden/InternalErrorShader" || !m.shader.isSupported)
				{ badMaterials++; details.Add("bad material: " + p + " shader=" + (m != null && m.shader != null ? m.shader.name : "null")); }
			}
			var groundReport = new List<string>();
			int groundChecks = 0, groundMiss = 0;
			foreach (var sceneRef in EditorBuildSettings.scenes)
			{
				var scene = EditorSceneManager.OpenScene(sceneRef.path, OpenSceneMode.Single);
				foreach (var root in scene.GetRootGameObjects())
				{
					foreach (var t in root.GetComponentsInChildren<Transform>(true))
					{
						int n = GameObjectUtility.GetMonoBehavioursWithMissingScriptCount(t.gameObject);
						if (n > 0) { missingScripts += n; details.Add("missing script: " + sceneRef.path + " :: " + t.name); }
					}
					CheckGeometry(root, sceneRef.path, details, ref emptyMeshes, ref badColliders, ref badSkins);
				}
				if (!sceneRef.path.Contains("/Tracks/") && !sceneRef.path.Contains("Pranksgiving")) continue;
				Physics.SyncTransforms();
				var probes = new List<Transform>();
				foreach (var root in scene.GetRootGameObjects())
					foreach (var t in root.GetComponentsInChildren<Transform>(true))
						if (t.GetComponent<WaypointLogic>() != null || t.name.StartsWith("Pole Position ")) probes.Add(t);
				int miss = 0;
				foreach (var t in probes)
				{
					groundChecks++;
					RaycastHit hit;
					if (!Physics.Raycast(t.position + Vector3.up * 3f, Vector3.down, out hit, 60f, 1 << 8, QueryTriggerInteraction.Ignore))
					{ miss++; groundMiss++; if (miss <= 5) details.Add("no Ground under " + sceneRef.path + " :: " + t.name + " @" + t.position); }
				}
				groundReport.Add(Path.GetFileNameWithoutExtension(sceneRef.path) + ": " + (probes.Count - miss) + "/" + probes.Count + " waypoints/pole positions have Ground (layer 8) below");
			}
			L("missing scripts: " + missingScripts);
			L("materials with missing/unsupported shader: " + badMaterials);
			L("renderers with empty/missing mesh: " + emptyMeshes);
			L("mesh colliders without triangles: " + badColliders);
			L("skinned meshes with bad bone weights: " + badSkins);
			L("ground probes: " + (groundChecks - groundMiss) + "/" + groundChecks);
			foreach (var s in groundReport) L("  " + s);
			L("--- details (first 200)");
			foreach (var d in details.Take(200)) L("  " + d);
			Flush("stage0_validation.log");
		}

		static void CheckGeometry(GameObject root, string where, List<string> details, ref int emptyMeshes, ref int badColliders, ref int badSkins)
		{
			foreach (var mf in root.GetComponentsInChildren<MeshFilter>(true))
			{
				if (mf.GetComponent<MeshRenderer>() == null || !mf.GetComponent<MeshRenderer>().enabled) continue;
				if (mf.sharedMesh == null) { emptyMeshes++; details.Add("no mesh: " + where + " :: " + mf.name); }
				else if (mf.sharedMesh.vertexCount == 0 && !mf.sharedMesh.name.StartsWith("Down_Ramp") && !mf.sharedMesh.name.StartsWith("Half_Circle") && !mf.sharedMesh.name.StartsWith("Hiway_Curve"))
				{ emptyMeshes++; details.Add("empty mesh: " + where + " :: " + mf.name + " (" + mf.sharedMesh.name + ")"); }
			}
			foreach (var mc in root.GetComponentsInChildren<MeshCollider>(true))
			{
				if (mc.sharedMesh == null || mc.sharedMesh.triangles.Length == 0)
				{
					string mn = mc.sharedMesh != null ? mc.sharedMesh.name : "null";
					if (mn.StartsWith("Down_Ramp") || mn.StartsWith("Half_Circle") || mn.StartsWith("Hiway_Curve")) continue;
					badColliders++; details.Add("collider without triangles: " + where + " :: " + mc.name + " (" + mn + ")");
				}
			}
			foreach (var sk in root.GetComponentsInChildren<SkinnedMeshRenderer>(true))
			{
				var m = sk.sharedMesh;
				if (m == null || m.vertexCount == 0 || (m.bindposes.Length > 0 && m.boneWeights.Length != m.vertexCount))
				{ badSkins++; details.Add("bad skinned mesh: " + where + " :: " + sk.name + " (" + (m != null ? m.name : "null") + ")"); }
			}
		}
	}
}
