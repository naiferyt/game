// Stage 4.0: Unity 4 light probes (RECUPERADO data, ADAPTADO-U6 sampling).
// In the original, RaceManager.Init destroys every Light of the track and moving objects (karts, drivers,
// pickups, rockets...) were lit only by the light probes baked with those lights. Unity 6 does not load the
// Unity 4 LightProbes assets, so those renderers fell back to the flat ambient colour and looked black.
// The baked probes of each scene were exported by forensics/scripts/lightprobes_export.py to
// Resources/LegacyLightProbes/<scene>.bytes (positions, 27 SH coefficients, tetrahedralization). This
// component interpolates them like Unity 4 did (barycentric weights inside the probe tetrahedra; outside the
// hull, the nearest hull face) and feeds the result to every renderer that uses light probes and has no
// lightmap (LightProbeUsage.BlendProbes -> CustomProvided with the SH set through a MaterialPropertyBlock).
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

public class LegacyLightProbes : MonoBehaviour
{
	private const float RefreshInterval = 0.5f;

	private Vector3[] positions;

	private float[] coefficients;

	private int[] tetIndices;

	private int[] tetNeighbors;

	private float[] tetMatrices;

	private int tetCount;

	private readonly List<Renderer> targets = new List<Renderer>();

	private readonly Dictionary<Renderer, int> lastTet = new Dictionary<Renderer, int>();

	private readonly List<SphericalHarmonicsL2> shList = new List<SphericalHarmonicsL2> { default(SphericalHarmonicsL2) };

	private MaterialPropertyBlock block;

	private float nextRefresh;

	private string sceneName;

	[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterSceneLoad)]
	private static void Install()
	{
		SceneManager.sceneLoaded -= OnSceneLoaded;
		SceneManager.sceneLoaded += OnSceneLoaded;
		OnSceneLoaded(SceneManager.GetActiveScene(), LoadSceneMode.Single);
	}

	private static void OnSceneLoaded(Scene scene, LoadSceneMode mode)
	{
		TextAsset data = Resources.Load<TextAsset>("LegacyLightProbes/" + scene.name);
		if (data == null)
		{
			return;
		}
		GameObject go = new GameObject("__LegacyLightProbes");
		SceneManager.MoveGameObjectToScene(go, scene);
		LegacyLightProbes probes = go.AddComponent<LegacyLightProbes>();
		probes.sceneName = scene.name;
		probes.Load(data.bytes);
	}

	private void Load(byte[] bytes)
	{
		int o = 4;
		int probeCount = System.BitConverter.ToInt32(bytes, o);
		o += 4;
		tetCount = System.BitConverter.ToInt32(bytes, o);
		o += 4;
		positions = new Vector3[probeCount];
		for (int i = 0; i < probeCount; i++)
		{
			positions[i] = new Vector3(System.BitConverter.ToSingle(bytes, o), System.BitConverter.ToSingle(bytes, o + 4), System.BitConverter.ToSingle(bytes, o + 8));
			o += 12;
		}
		coefficients = new float[probeCount * 27];
		for (int i = 0; i < coefficients.Length; i++)
		{
			coefficients[i] = System.BitConverter.ToSingle(bytes, o);
			o += 4;
		}
		tetIndices = new int[tetCount * 4];
		tetNeighbors = new int[tetCount * 4];
		tetMatrices = new float[tetCount * 12];
		for (int t = 0; t < tetCount; t++)
		{
			for (int k = 0; k < 4; k++)
			{
				tetIndices[t * 4 + k] = System.BitConverter.ToInt32(bytes, o);
				o += 4;
			}
			for (int k = 0; k < 4; k++)
			{
				tetNeighbors[t * 4 + k] = System.BitConverter.ToInt32(bytes, o);
				o += 4;
			}
			for (int k = 0; k < 12; k++)
			{
				tetMatrices[t * 12 + k] = System.BitConverter.ToSingle(bytes, o);
				o += 4;
			}
		}
		block = new MaterialPropertyBlock();
		Debug.Log("[LegacyLightProbes] " + sceneName + ": " + probeCount + " probes, " + tetCount + " tetrahedra");
	}

	private void LateUpdate()
	{
		if (positions == null)
		{
			return;
		}
		if (Time.unscaledTime >= nextRefresh)
		{
			nextRefresh = Time.unscaledTime + RefreshInterval;
			RefreshTargets();
		}
		for (int i = targets.Count - 1; i >= 0; i--)
		{
			Renderer r = targets[i];
			if (r == null)
			{
				targets.RemoveAt(i);
				continue;
			}
			if (!r.enabled || !r.gameObject.activeInHierarchy)
			{
				continue;
			}
			Vector3 p = (r.probeAnchor != null) ? r.probeAnchor.position : r.bounds.center;
			int tet;
			lastTet.TryGetValue(r, out tet);
			SphericalHarmonicsL2 sh = Sample(p, ref tet);
			lastTet[r] = tet;
			shList[0] = sh;
			r.GetPropertyBlock(block);
			block.CopySHCoefficientArraysFrom(shList);
			r.SetPropertyBlock(block);
		}
	}

	private void RefreshTargets()
	{
		Renderer[] all = Object.FindObjectsByType<Renderer>(FindObjectsSortMode.None);
		for (int i = 0; i < all.Length; i++)
		{
			Renderer r = all[i];
			if (r.lightProbeUsage != LightProbeUsage.BlendProbes)
			{
				continue;
			}
			if (r.lightmapIndex >= 0 && r.lightmapIndex < 65534)
			{
				continue;
			}
			if (r.gameObject.scene.name != sceneName && r.gameObject.scene.name != "DontDestroyOnLoad")
			{
				continue;
			}
			r.lightProbeUsage = LightProbeUsage.CustomProvided;
			targets.Add(r);
		}
	}

	// Barycentric weights of p in inner tetrahedron t (idx[3] >= 0).
	private void Barycentric(int t, Vector3 p, out float b0, out float b1, out float b2, out float b3)
	{
		Vector3 d = p - positions[tetIndices[t * 4 + 3]];
		int m = t * 12;
		b0 = tetMatrices[m] * d.x + tetMatrices[m + 1] * d.y + tetMatrices[m + 2] * d.z + tetMatrices[m + 3];
		b1 = tetMatrices[m + 4] * d.x + tetMatrices[m + 5] * d.y + tetMatrices[m + 6] * d.z + tetMatrices[m + 7];
		b2 = tetMatrices[m + 8] * d.x + tetMatrices[m + 9] * d.y + tetMatrices[m + 10] * d.z + tetMatrices[m + 11];
		b3 = 1f - b0 - b1 - b2;
	}

	private SphericalHarmonicsL2 Sample(Vector3 p, ref int tet)
	{
		if (tet < 0 || tet >= tetCount || tetIndices[tet * 4 + 3] < 0)
		{
			tet = FirstInner();
		}
		// Walk towards p through the neighbour opposite the most negative weight.
		for (int step = 0; step < 64; step++)
		{
			float b0, b1, b2, b3;
			Barycentric(tet, p, out b0, out b1, out b2, out b3);
			float min = b0;
			int face = 0;
			if (b1 < min) { min = b1; face = 1; }
			if (b2 < min) { min = b2; face = 2; }
			if (b3 < min) { min = b3; face = 3; }
			if (min >= -1e-4f)
			{
				return Blend4(tet, b0, b1, b2, b3);
			}
			int next = tetNeighbors[tet * 4 + face];
			if (next < 0 || next >= tetCount)
			{
				break;
			}
			if (tetIndices[next * 4 + 3] < 0)
			{
				// Left the probe hull: light from the hull face (outer cell) the walk exited through.
				return FaceSample(next, p);
			}
			tet = next;
		}
		// Rare: walk did not converge. Brute force over the inner tetrahedra, then the nearest hull face.
		int best = -1;
		float bestMin = float.NegativeInfinity;
		for (int t = 0; t < tetCount; t++)
		{
			if (tetIndices[t * 4 + 3] < 0)
			{
				continue;
			}
			float b0, b1, b2, b3;
			Barycentric(t, p, out b0, out b1, out b2, out b3);
			float min = Mathf.Min(Mathf.Min(b0, b1), Mathf.Min(b2, b3));
			if (min > bestMin)
			{
				bestMin = min;
				best = t;
			}
		}
		if (best >= 0 && bestMin >= -1e-4f)
		{
			tet = best;
			float b0, b1, b2, b3;
			Barycentric(best, p, out b0, out b1, out b2, out b3);
			return Blend4(best, b0, b1, b2, b3);
		}
		int face2 = NearestOuter(p);
		return FaceSample(face2, p);
	}

	private int FirstInner()
	{
		for (int t = 0; t < tetCount; t++)
		{
			if (tetIndices[t * 4 + 3] >= 0)
			{
				return t;
			}
		}
		return 0;
	}

	private int NearestOuter(Vector3 p)
	{
		int best = 0;
		float bestD = float.PositiveInfinity;
		for (int t = 0; t < tetCount; t++)
		{
			if (tetIndices[t * 4 + 3] >= 0)
			{
				continue;
			}
			Vector3 c = (positions[tetIndices[t * 4]] + positions[tetIndices[t * 4 + 1]] + positions[tetIndices[t * 4 + 2]]) / 3f;
			float d = (c - p).sqrMagnitude;
			if (d < bestD)
			{
				bestD = d;
				best = t;
			}
		}
		return best;
	}

	// Projects p onto the hull triangle of outer cell t and blends its three probes (clamped barycentric).
	private SphericalHarmonicsL2 FaceSample(int t, Vector3 p)
	{
		int i0 = tetIndices[t * 4];
		int i1 = tetIndices[t * 4 + 1];
		int i2 = tetIndices[t * 4 + 2];
		Vector3 a = positions[i0];
		Vector3 ab = positions[i1] - a;
		Vector3 ac = positions[i2] - a;
		Vector3 ap = p - a;
		float d00 = Vector3.Dot(ab, ab);
		float d01 = Vector3.Dot(ab, ac);
		float d11 = Vector3.Dot(ac, ac);
		float d20 = Vector3.Dot(ap, ab);
		float d21 = Vector3.Dot(ap, ac);
		float den = d00 * d11 - d01 * d01;
		float v = 0f;
		float w = 0f;
		if (Mathf.Abs(den) > 1e-8f)
		{
			v = (d11 * d20 - d01 * d21) / den;
			w = (d00 * d21 - d01 * d20) / den;
		}
		float u = 1f - v - w;
		u = Mathf.Max(u, 0f);
		v = Mathf.Max(v, 0f);
		w = Mathf.Max(w, 0f);
		float s = u + v + w;
		if (s <= 0f)
		{
			u = 1f;
			s = 1f;
		}
		SphericalHarmonicsL2 sh = default(SphericalHarmonicsL2);
		Accumulate(ref sh, i0, u / s);
		Accumulate(ref sh, i1, v / s);
		Accumulate(ref sh, i2, w / s);
		return sh;
	}

	private SphericalHarmonicsL2 Blend4(int t, float b0, float b1, float b2, float b3)
	{
		SphericalHarmonicsL2 sh = default(SphericalHarmonicsL2);
		Accumulate(ref sh, tetIndices[t * 4], Mathf.Max(b0, 0f));
		Accumulate(ref sh, tetIndices[t * 4 + 1], Mathf.Max(b1, 0f));
		Accumulate(ref sh, tetIndices[t * 4 + 2], Mathf.Max(b2, 0f));
		Accumulate(ref sh, tetIndices[t * 4 + 3], Mathf.Max(b3, 0f));
		return sh;
	}

	// Unity 4 stores the 27 floats per probe interleaved: coefficient k, channel c -> [3k + c].
	private void Accumulate(ref SphericalHarmonicsL2 sh, int probe, float weight)
	{
		if (weight <= 0f)
		{
			return;
		}
		int o = probe * 27;
		for (int k = 0; k < 9; k++)
		{
			sh[0, k] += coefficients[o + k * 3] * weight;
			sh[1, k] += coefficients[o + k * 3 + 1] * weight;
			sh[2, k] += coefficients[o + k * 3 + 2] * weight;
		}
	}
}
