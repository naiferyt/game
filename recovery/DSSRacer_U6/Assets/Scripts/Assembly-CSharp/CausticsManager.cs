using System.Collections;
using System.Diagnostics;
using UnityEngine;

// Animated caustics on the Fish Hooks tracks: scrolls the global _CausticVector read by the
// "Mobile/Unlit Under The Sea" shader. The oldest iOS devices get the plain lightmapped shader instead.
// Source listing: recovery/aot_listings/Assembly-CSharp/CausticsManager.txt
[ExecuteInEditMode]
public class CausticsManager : MonoBehaviour
{
	// RECUPERADO-AOT CausticsManager::.ctor token 0x06000403 @0x000fb5a0 (field initializer)
	public Vector4 causticsVector = new Vector4(3f, -0.3f, -0.9f, 1.5f);

	// RECUPERADO-AOT CausticsManager::Start token 0x06000404 @0x000fb6ac
	// ADAPTADO-U6: iPhone.generation -> iOS.Device.generation (same values: 3 iPhone 3GS, 6 iPod touch 3G,
	//     7 iPad 1); FindObjectsOfType -> U4Compat. On PC the animated branch is always taken.
	private void Start()
	{
		if (Application.platform == RuntimePlatform.IPhonePlayer && (UnityEngine.iOS.Device.generation == (UnityEngine.iOS.DeviceGeneration)3 || UnityEngine.iOS.Device.generation == (UnityEngine.iOS.DeviceGeneration)7 || UnityEngine.iOS.Device.generation == (UnityEngine.iOS.DeviceGeneration)6))
		{
			Shader shader = Shader.Find("Mobile/Unlit (Supports Lightmap)");
			Object[] array = U4Compat.FindObjectsOfType(typeof(Renderer));
			for (int i = 0; i < array.Length; i++)
			{
				Renderer renderer = (Renderer)array[i];
				Material[] materials = renderer.materials;
				foreach (Material material in materials)
				{
					if (material.shader.name.Contains("Mobile/Unlit Under The Sea"))
					{
						material.shader = shader;
						UnityEngine.Debug.Log(renderer.gameObject.name);
					}
				}
			}
		}
		else
		{
			StartCoroutine(UpdateCausticsCoroutine());
		}
	}

	// RECUPERADO-AOT CausticsManager::UpdateCausticsCoroutine token 0x06000405 @0x000fb8dc
	// (iterator <UpdateCausticsCoroutine>c__Iterator28 MoveNext token 0x060008c0 @0x00148be4)
	[DebuggerHidden]
	private IEnumerator UpdateCausticsCoroutine()
	{
		Shader.SetGlobalVector("_CausticVector", Vector4.zero);
		while (true)
		{
			Shader.SetGlobalVector("_CausticVector", causticsVector * Time.realtimeSinceStartup);
			yield return new WaitForSeconds(1f / 30f);
		}
	}
}
