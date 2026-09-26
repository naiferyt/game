// ADAPTADO-U6 (compatibility layer, not game logic).
// Unity 4 scenes stored their baked (Beast, mobile dLDR) lightmaps as a list in LightmapSettings plus a
// lightmap index / scale-offset on every renderer. Unity 5+ only restores lightmaps from a LightingDataAsset,
// so the original data is re-applied here at load time. Data is filled by DSSRecovery.LightmapInstaller
// from Assets/_Recovery/Data/lightmaps.json (extracted from the original scene YAML).
using UnityEngine;

[ExecuteAlways]
[DefaultExecutionOrder(-10000)]
public class LegacyLightmapRestorer : MonoBehaviour
{
	public Texture2D[] lightmaps = new Texture2D[0];
	public Renderer[] renderers = new Renderer[0];
	public int[] lightmapIndices = new int[0];
	public Vector4[] scaleOffsets = new Vector4[0];

	void Awake()
	{
		Apply();
	}

	void OnEnable()
	{
		Apply();
	}

	public void Apply()
	{
		var data = new LightmapData[lightmaps.Length];
		for (int i = 0; i < lightmaps.Length; i++)
		{
			data[i] = new LightmapData();
			data[i].lightmapColor = lightmaps[i];
		}
		LightmapSettings.lightmapsMode = LightmapsMode.NonDirectional;
		LightmapSettings.lightmaps = data;
		for (int i = 0; i < renderers.Length; i++)
		{
			Renderer r = renderers[i];
			if (r == null) continue;
			r.lightmapIndex = lightmapIndices[i];
			r.lightmapScaleOffset = scaleOffsets[i];
		}
	}
}
