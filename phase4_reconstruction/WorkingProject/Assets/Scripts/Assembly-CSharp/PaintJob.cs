using UnityEngine;

public class PaintJob : MonoBehaviour
{
	public CartSlot.Slots slot;

	public Texture2D swatch;

	public int cost;

	public StreamedMultilayerTexture multilayerTexture;

	public Texture2D GetTexture()
	{
		return default(Texture2D);
	}
}
