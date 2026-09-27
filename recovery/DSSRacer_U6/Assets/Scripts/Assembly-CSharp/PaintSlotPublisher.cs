using UnityEngine;

// One paint swatch of the customizer's paint menu: shows the paint (its swatch texture or its base colour)
// and a lock (not unlockable yet) or price tag (for sale).
// Source listing: recovery/aot_listings/Assembly-CSharp/PaintSlotPublisher.txt
public class PaintSlotPublisher : UghPublisher
{
	private enum States
	{
		locked = 0,
		forSale = 1,
		open = 2
	}

	private States state;

	private int viewingIndex;

	private Texture2D texture;

	private CartCustomizerPublisher publisher;

	// RECUPERADO-AOT PaintSlotPublisher::PressedPaintButton token 0x060006aa @0x0012e8bc
	private void PressedPaintButton()
	{
		if (!PreviewCart.IsLoading)
		{
			SoundLibrary.ButtonClickPlay("menuButton1");
			CartCustomizerPublisher.SetViewingPaintIndex(viewingIndex);
			if (state == States.forSale)
			{
				publisher.OpenBuyPaint();
			}
			else if (state == States.locked)
			{
				publisher.OpenPaintIsLocked();
			}
		}
	}

	// RECUPERADO-AOT PaintSlotPublisher::Start token 0x060006ab @0x0012e94c
	// ADAPTADO-U6: FindObjectOfType -> U4Compat.
	private void Start()
	{
		publisher = U4Compat.FindObjectOfType(typeof(CartCustomizerPublisher)) as CartCustomizerPublisher;
	}

	// RECUPERADO-AOT PaintSlotPublisher::SetPaint token 0x060006ac @0x0012e9d8
	// ADAPTADO-U6: Component.renderer -> GetComponent<Renderer>().
	public void SetPaint(PaintJob paint, int index)
	{
		viewingIndex = index;
		base.transforms["Swatch"].GetComponent<Renderer>().material = new Material(Shader.Find("iPhone/Transparent And Color Unlit"));
		if (paint.swatch != null)
		{
			base.transforms["Swatch"].GetComponent<Renderer>().material.mainTexture = paint.swatch;
		}
		else if (paint.multilayerTexture.layers.Length > 0)
		{
			texture = new Texture2D(2, 2, TextureFormat.ARGB32, false);
			Color32[] array = new Color32[4];
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = paint.multilayerTexture.layers[0].color;
				array[i].a = byte.MaxValue;
			}
			texture.SetPixels32(array);
			texture.Apply();
			base.transforms["Swatch"].GetComponent<Renderer>().material.mainTexture = texture;
		}
		if (DataUtility.Instance.IsUnlocked(paint.name) || paint.cost == 0)
		{
			base.transforms["lock"].gameObject.SetActive(false);
			base.transforms["dollar"].gameObject.SetActive(false);
			state = States.open;
		}
		else if (paint.cost == -1)
		{
			base.transforms["lock"].gameObject.SetActive(true);
			base.transforms["dollar"].gameObject.SetActive(false);
			state = States.locked;
		}
		else if (paint.cost > 0)
		{
			base.transforms["dollar"].gameObject.SetActive(true);
			base.transforms["lock"].gameObject.SetActive(false);
			state = States.forSale;
		}
	}

	// RECUPERADO-AOT PaintSlotPublisher::OnDestroy token 0x060006ad @0x0012ee54
	private void OnDestroy()
	{
		if (texture != null)
		{
			Object.Destroy(texture);
		}
	}
}
