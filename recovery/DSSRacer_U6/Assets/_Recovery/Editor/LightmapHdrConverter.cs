using System.IO;
using UnityEditor;
using UnityEngine;

namespace DSSRecovery
{
	// ADAPTADO-U6 (tooling, 2026-09-27): the Unity 4 lightmaps (LightmapFar-*.png, original dLDR texels: light = 2 x texel)
	// are rewritten as HDR EXR so that Unity 6's lightmap import + DecodeLightmap give back exactly 2 x texel on PC.
	// Measured with LightmapProbe: a "Lightmap" texture decodes, in this Gamma project, to source^(1/2.2); the EXR therefore
	// stores (2 x texel)^2.2. Writes <logs>/lm_exr/<asset path>.exr; forensics/scripts/lightmaps_to_exr.sh swaps them in
	// (the .png.meta becomes the .exr.meta, so every scene keeps its GUID reference).
	// Run with -executeMethod DSSRecovery.LightmapHdrConverter.Run
	public static class LightmapHdrConverter
	{
		public static void Run()
		{
			int n = 0;
			foreach (var guid in AssetDatabase.FindAssets("LightmapFar t:Texture2D"))
			{
				string path = AssetDatabase.GUIDToAssetPath(guid);
				if (!path.EndsWith(".png")) continue;
				var src = new Texture2D(2, 2, TextureFormat.RGBA32, false, true);
				src.LoadImage(File.ReadAllBytes(path));
				var px = src.GetPixels();
				for (int i = 0; i < px.Length; i++)
				{
					px[i] = new Color(Mathf.Pow(2f * px[i].r, 2.2f), Mathf.Pow(2f * px[i].g, 2.2f), Mathf.Pow(2f * px[i].b, 2.2f), 1f);
				}
				var hdr = new Texture2D(src.width, src.height, TextureFormat.RGBAFloat, false, true);
				hdr.SetPixels(px); hdr.Apply();
				string outPath = Path.Combine("../logs/lm_exr", path.Substring(0, path.Length - 4) + ".exr");
				Directory.CreateDirectory(Path.GetDirectoryName(outPath));
				File.WriteAllBytes(outPath, hdr.EncodeToEXR(Texture2D.EXRFlags.CompressZIP));
				Object.DestroyImmediate(src); Object.DestroyImmediate(hdr);
				n++;
			}
			Debug.Log("[LightmapHdrConverter] " + n + " lightmaps written");
			File.WriteAllText("../logs/lm_exr/done.txt", n.ToString());
		}
	}
}
