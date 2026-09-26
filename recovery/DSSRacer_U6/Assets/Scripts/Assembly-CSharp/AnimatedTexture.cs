using System.Collections;
using System.Diagnostics;
using UnityEngine;

// Scrolls the material's main texture offset at (uOffset, vOffset) per second, pausing with the race.
// Source listing: recovery/aot_listings/Assembly-CSharp/AnimatedTexture.txt
public class AnimatedTexture : MonoBehaviour
{
	// RECUPERADO-AOT AnimatedTexture::.ctor token 0x06000192 @0x000d51a4 (field initializers)
	public float uOffset = 1f;

	public float vOffset = 1f;

	public float uTile = 1f;

	public float vTile = 1f;

	private Material mat;

	// RECUPERADO-AOT AnimatedTexture::Start token 0x06000193 @0x000d5238
	private void Start()
	{
		Renderer component = base.gameObject.GetComponent<Renderer>();
		if (component == null)
		{
			component = base.gameObject.GetComponentInChildren<Renderer>();
		}
		if (component != null)
		{
			mat = component.material;
		}
		else
		{
			UnityEngine.Debug.LogWarning("AnimatedTexture cant find a Renderer.material to animate");
		}
		if (mat != null)
		{
			mat.mainTextureScale = new Vector2(uTile, vTile);
		}
		StartCoroutine(UpdateTexture());
	}

	// RECUPERADO-AOT AnimatedTexture::Update token 0x06000194 @0x000d53b0 (empty in the original)
	private void Update()
	{
	}

	// RECUPERADO-AOT AnimatedTexture::UpdateTexture token 0x06000195 @0x000d53dc
	// (iterator <UpdateTexture>c__Iterator1A MoveNext token 0x0600086c @0x00144c14)
	[DebuggerHidden]
	private IEnumerator UpdateTexture()
	{
		while (mat != null)
		{
			while (RaceManager.isPaused)
			{
				yield return 0;
			}
			Vector2 offset = new Vector2(mat.mainTextureOffset.x + uOffset * Time.deltaTime, mat.mainTextureOffset.y + vOffset * Time.deltaTime);
			mat.mainTextureOffset = offset;
			yield return new WaitForSeconds(0.01f);
		}
		yield return 0;
	}
}
