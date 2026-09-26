using UnityEngine;

[RequireComponent(typeof(TextMesh), typeof(MeshRenderer))]
public class UghText : MonoBehaviour
{
	private const int allocSize = 100;

	public LocalizedString text;

	public bool wordWrap;

	public float maxWidth;

	public bool useMaxHeight;

	public float maxHeight;

	public bool logStyleClipping;

	public Material dropShadowMaterial;

	public Vector3 dropShadowLocalOffset;

	private MeshRenderer meshRenderer;

	private TextMesh textMesh;

	private bool hasTriedInherited;

	public string Text
	{
		get
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}
		set
		{
		}
	}

	private void Start()
	{
	}

	private void AutoInheritText()
	{
	}

	private void OnDrawGizmos()
	{
	}

	public void ForceUpdate()
	{
	}

	private void UpdateDropShadow()
	{
	}

	private void SetTextMeshAndWordWrap(string s, float maxWidth, bool useMaxHeight, float maxHeight)
	{
	}

	public UghPublisher GetParentPublisher()
	{
		/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
	}
}
