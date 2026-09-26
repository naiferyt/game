using UnityEngine;

// A paint scheme for one slot: swatch for the menus plus the layered texture composed onto the part.
// Source listing: recovery/aot_listings/Assembly-CSharp/PaintJob.txt
public class PaintJob : MonoBehaviour
{
	public CartSlot.Slots slot;

	public Texture2D swatch;

	public int cost;

	public StreamedMultilayerTexture multilayerTexture;

	// RECUPERADO-AOT PaintJob::GetTexture token 0x06000240 @0x000e4db4
	public Texture2D GetTexture()
	{
		multilayerTexture.RequestAssets();
		MultilayerTexture multilayer = multilayerTexture.PrepareMultilayerTexture();
		if (multilayer == null)
		{
			return null;
		}
		return multilayer.ComposeTexture();
	}
}
