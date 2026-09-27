using System.Text;
using UnityEditor;
using UnityEngine;

namespace DSSRecovery
{
	// Stage 4.10 tooling: reports how Unity 6 lays out a TextMesh with the original bitmap font, to compare with the
	// Unity 4 glyph data (CharacterInfo.vert measured from the line top). Run with -executeMethod DSSRecovery.FontProbe.Run
	public static class FontProbe
	{
		public static void Run()
		{
			var sb = new StringBuilder();
			var font = AssetDatabase.LoadAssetAtPath<Font>("Assets/Font/CCUpUpAndAway.asset");
			sb.AppendLine(string.Format("font {0} ascent {1} lineHeight {2} fontSize {3} dynamic {4}", font.name, font.ascent, font.lineHeight, font.fontSize, font.dynamic));
			foreach (char ch in "!Agy ")
			{
				CharacterInfo ci;
				if (font.GetCharacterInfo(ch, out ci))
					sb.AppendLine(string.Format("char '{0}' minX {1} maxX {2} minY {3} maxY {4} advance {5} bearing {6} glyphH {7}", ch, ci.minX, ci.maxX, ci.minY, ci.maxY, ci.advance, ci.bearing, ci.glyphHeight));
			}
			foreach (var anchor in new[] { TextAnchor.UpperLeft, TextAnchor.MiddleLeft, TextAnchor.LowerLeft })
			{
				foreach (var text in new[] { "!", "A", "Ag\nAg" })
				{
					var go = new GameObject("probe");
					var tm = go.AddComponent<TextMesh>();
					go.GetComponent<MeshRenderer>().sharedMaterial = font.material;
					tm.font = font; tm.anchor = anchor; tm.characterSize = 1f; tm.fontSize = 0; tm.text = text;
					var mf = go.GetComponent<MeshFilter>();
					var mesh = mf != null ? mf.sharedMesh : null;
					string b = "no mesh";
					if (mesh == null)
					{
						// TextMesh keeps its mesh internally; the renderer bounds give the same extents
						var r = go.GetComponent<Renderer>();
						b = "bounds min " + r.bounds.min.ToString("F3") + " max " + r.bounds.max.ToString("F3");
					}
					else b = "mesh min " + mesh.bounds.min.ToString("F3") + " max " + mesh.bounds.max.ToString("F3");
					sb.AppendLine(string.Format("anchor {0} text '{1}': {2}", anchor, text.Replace("\n", "\\n"), b));
					Object.DestroyImmediate(go);
				}
			}
			// render "!" (UpperLeft anchor at the origin) with an orthographic camera covering y -20..+20, x -20..+20,
			// and report the world y range of the drawn pixels. Unity 4 drew it between y -0.275 and -4.975.
			foreach (var text in new[] { "!", "A", "g" })
			{
				var go = new GameObject("probe");
				var tm = go.AddComponent<TextMesh>();
				go.GetComponent<MeshRenderer>().sharedMaterial = font.material;
				tm.font = font; tm.anchor = TextAnchor.UpperLeft; tm.characterSize = 1f; tm.fontSize = 0; tm.text = text; tm.color = Color.white;
				var camGo = new GameObject("cam");
				var cam = camGo.AddComponent<Camera>();
				cam.orthographic = true; cam.orthographicSize = 20f; cam.transform.position = new Vector3(0, 0, -10);
				cam.clearFlags = CameraClearFlags.SolidColor; cam.backgroundColor = new Color(0, 0, 0, 0);
				var rt = new RenderTexture(400, 400, 24); cam.targetTexture = rt; cam.aspect = 1f;
				cam.Render();
				RenderTexture.active = rt;
				var tex = new Texture2D(400, 400, TextureFormat.RGBA32, false);
				tex.ReadPixels(new Rect(0, 0, 400, 400), 0, 0); tex.Apply();
				RenderTexture.active = null;
				int top = -1, bottom = -1, left = -1, right = -1;
				for (int y = 0; y < 400; y++)
					for (int x = 0; x < 400; x++)
					{
						var c = tex.GetPixel(x, y);
						if (c.a > 0.3f || c.r > 0.3f)
						{
							if (bottom < 0) bottom = y;
							top = y;
							if (left < 0 || x < left) left = x;
							if (x > right) right = x;
						}
					}
				// pixel -> world: 400 px cover 40 units, pixel 0 = -20
				System.Func<int, float> w = p => p * 0.1f - 20f;
				sb.AppendLine(top < 0 ? "render '" + text + "': nothing drawn" : string.Format("render '{0}': y {1:0.00} .. {2:0.00}  x {3:0.00} .. {4:0.00}", text, w(bottom), w(top + 1), w(left), w(right + 1)));
				Object.DestroyImmediate(go); Object.DestroyImmediate(camGo); rt.Release();
			}
			System.IO.File.WriteAllText("../logs/fontprobe.txt", sb.ToString());
			Debug.Log(sb.ToString());
		}
	}
}
