using System.Collections.Generic;
using System.Text;
using UnityEngine;

// Localized TextMesh label with optional word wrap (by measuring the rendered bounds) and drop shadow child.
// Source listing: recovery/aot_listings/Assembly-CSharp-firstpass/UghText.txt
[RequireComponent(typeof(TextMesh), typeof(MeshRenderer))]
public class UghText : MonoBehaviour
{
	private const int allocSize = 100;

	public LocalizedString text;

	public bool wordWrap;

	// RECUPERADO-AOT UghText..ctor token 0x0600047c @0x0004b7c0 (field initializers)
	public float maxWidth = 1f;

	public bool useMaxHeight;

	public float maxHeight;

	public bool logStyleClipping;

	public Material dropShadowMaterial;

	public Vector3 dropShadowLocalOffset = new Vector3(0.02f, -0.02f, 0.0001f);

	private MeshRenderer meshRenderer;

	private TextMesh textMesh;

	private bool hasTriedInherited;

	public string Text
	{
		// RECUPERADO-AOT UghText.get_Text token 0x0600047d @0x0004b8b4
		get
		{
			return text.Text;
		}
		// RECUPERADO-AOT UghText.set_Text token 0x0600047e @0x0004b8f8
		set
		{
			text.baseText = value;
			ForceUpdate();
		}
	}

	// RECUPERADO-AOT UghText.Start token 0x0600047f @0x0004b93c
	private void Start()
	{
		ForceUpdate();
	}

	// RECUPERADO-AOT UghText.AutoInheritText token 0x06000480 @0x0004b970 (empty in the original)
	private void AutoInheritText()
	{
	}

	// RECUPERADO-AOT UghText.OnDrawGizmos token 0x06000481 @0x0004b99c
	private void OnDrawGizmos()
	{
		if (!Application.isPlaying)
		{
			ForceUpdate();
		}
	}

	// RECUPERADO-AOT UghText.ForceUpdate token 0x06000482 @0x0004b9dc
	public void ForceUpdate()
	{
		if (!hasTriedInherited)
		{
			hasTriedInherited = true;
		}
		SetTextMeshAndWordWrap(text.Text, maxWidth, useMaxHeight, maxHeight);
		UpdateDropShadow();
	}

	// RECUPERADO-AOT UghText.UpdateDropShadow token 0x06000483 @0x0004ba6c
	private void UpdateDropShadow()
	{
		if (dropShadowMaterial != null)
		{
			// ADAPTADO-U6: Transform.FindChild -> Transform.Find
			Transform shadow = transform.Find("__Shadow");
			if (shadow == null)
			{
				shadow = Object.Instantiate(transform, transform.position, transform.rotation) as Transform;
				shadow.parent = transform;
				shadow.localScale = Vector3.one;
				shadow.gameObject.name = "__Shadow";
				Object.DestroyImmediate(shadow.GetComponent<UghText>());
				Vector3 inverseScale = shadow.lossyScale;
				inverseScale.x = 1f / inverseScale.x;
				inverseScale.y = 1f / inverseScale.y;
				inverseScale.z = 1f;
				dropShadowLocalOffset.Scale(inverseScale);
			}
			shadow.GetComponent<TextMesh>().text = GetComponent<TextMesh>().text;
			shadow.localPosition = dropShadowLocalOffset;
			// ADAPTADO-U6: Component.renderer -> GetComponent<Renderer>()
			shadow.GetComponent<Renderer>().material = dropShadowMaterial;
		}
		else if (transform.childCount > 0)
		{
			Transform oldShadow = transform.Find("__Shadow");
			if ((bool)oldShadow)
			{
				Object.DestroyImmediate(oldShadow.gameObject);
			}
		}
	}

	// RECUPERADO-AOT UghText.SetTextMeshAndWordWrap token 0x06000484 @0x0004bdf4
	// Splits the text into alternating word / whitespace runs and adds them one by one, breaking the line when the
	// rendered width passes maxWidth and stopping (or scrolling, logStyleClipping) when the height passes maxHeight.
	private void SetTextMeshAndWordWrap(string s, float maxWidth, bool useMaxHeight, float maxHeight)
	{
		Vector3 size = Vector3.zero;
		gameObject.layer = UghCamera.Instance.guiLayer;
		if (s == null)
		{
			s = text.Text;
		}
		if (!textMesh)
		{
			textMesh = GetComponent<TextMesh>();
		}
		if (!wordWrap)
		{
			textMesh.text = s;
			return;
		}
		if (!meshRenderer)
		{
			meshRenderer = GetComponent<MeshRenderer>();
		}
		if (s.Length < 1)
		{
			textMesh.text = string.Empty;
			return;
		}
		StringBuilder word = new StringBuilder(100);
		StringBuilder space = new StringBuilder(100);
		List<string> words = new List<string>(100);
		List<string> spaces = new List<string>(100);
		int length = s.Length;
		bool inSpace = char.IsWhiteSpace(s[0]);
		bool startsWithSpace = inSpace;
		for (int i = 0; i < length; i++)
		{
			if (char.IsWhiteSpace(s[i]))
			{
				if (!inSpace)
				{
					words.Add(word.ToString());
					word.Remove(0, word.Length);
				}
				space.Append(s[i]);
				inSpace = true;
			}
			else
			{
				if (inSpace)
				{
					spaces.Add(space.ToString());
					space.Remove(0, space.Length);
				}
				word.Append(s[i]);
				inSpace = false;
			}
		}
		if (inSpace)
		{
			if (space.Length > 0)
			{
				spaces.Add(space.ToString());
			}
		}
		else if (word.Length > 0)
		{
			words.Add(word.ToString());
		}
		spaces.Add(string.Empty);
		bool done = false;
		bool takeSpace = startsWithSpace;
		int wordIndex = 0;
		int spaceIndex = 0;
		StringBuilder result = new StringBuilder(100);
		while (!done)
		{
			if (takeSpace)
			{
				result.Append(spaces[spaceIndex]);
			}
			else
			{
				result.Append(words[wordIndex]);
			}
			textMesh.text = result.ToString();
			// ADAPTADO-U6: Component.renderer -> GetComponent<Renderer>()
			size = textMesh.GetComponent<Renderer>().bounds.size;
			if (useMaxHeight && maxHeight < size.y)
			{
				int pieceLength = takeSpace ? spaces[spaceIndex].Length : words[wordIndex].Length;
				if (logStyleClipping)
				{
					int j;
					for (j = 0; j < result.Length && result[j] != '\n'; j++)
					{
					}
					result.Remove(0, j + 1);
				}
				else
				{
					result.Remove(result.Length - pieceLength, pieceLength);
					done = true;
				}
			}
			if (maxWidth < size.x)
			{
				int pieceLength = takeSpace ? spaces[spaceIndex].Length : words[wordIndex].Length;
				result.Remove(result.Length - pieceLength, pieceLength);
				result.Append("\n");
				if (takeSpace)
				{
					result.Append(spaces[spaceIndex]);
				}
				else
				{
					result.Append(words[wordIndex]);
				}
			}
			if (takeSpace)
			{
				spaceIndex++;
			}
			else
			{
				wordIndex++;
			}
			takeSpace = !takeSpace;
			if (spaceIndex >= spaces.Count || wordIndex >= words.Count)
			{
				done = true;
			}
		}
		textMesh.text = result.ToString();
	}

	// RECUPERADO-AOT UghText.GetParentPublisher token 0x06000485 @0x0004c5c0
	public UghPublisher GetParentPublisher()
	{
		for (Transform t = transform; t != null; t = t.parent)
		{
			UghPublisher publisher = t.gameObject.GetComponent<UghPublisher>();
			if ((bool)publisher)
			{
				return publisher;
			}
		}
		return null;
	}
}
