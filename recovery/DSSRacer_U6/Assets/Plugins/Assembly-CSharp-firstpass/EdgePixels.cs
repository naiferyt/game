using System;

// Four edge widths (top, bottom, right, left) used for nine-slice insets and crops.
// Source listing: recovery/aot_listings/Assembly-CSharp-firstpass/EdgePixels.txt
[Serializable]
public class EdgePixels
{
	public float top;

	public float bottom;

	public float right;

	public float left;

	public float xSum
	{
		// RECUPERADO-AOT EdgePixels.get_xSum token 0x0600046b @0x0004a3c4
		get
		{
			return right + left;
		}
	}

	public float ySum
	{
		// RECUPERADO-AOT EdgePixels.get_ySum token 0x0600046c @0x0004a410
		get
		{
			return top + bottom;
		}
	}

	// RECUPERADO-AOT EdgePixels.DeepCopy token 0x0600046d @0x0004a45c
	public EdgePixels DeepCopy()
	{
		return (EdgePixels)MemberwiseClone();
	}
}
