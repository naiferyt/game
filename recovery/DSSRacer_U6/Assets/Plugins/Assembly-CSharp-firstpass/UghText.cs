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
			RecoveryPending.Hit("UghText.get_Text");
			return default(string);
		}
		set
		{
			RecoveryPending.Hit("UghText.set_Text");
		}
	}

	private void Start()
	{
		RecoveryPending.Hit("UghText.Start");
	}

	private void AutoInheritText()
	{
		RecoveryPending.Hit("UghText.AutoInheritText");
	}

	private void OnDrawGizmos()
	{
		RecoveryPending.Hit("UghText.OnDrawGizmos");
	}

	public void ForceUpdate()
	{
		RecoveryPending.Hit("UghText.ForceUpdate");
	}

	private void UpdateDropShadow()
	{
		RecoveryPending.Hit("UghText.UpdateDropShadow");
	}

	private void SetTextMeshAndWordWrap(string s, float maxWidth, bool useMaxHeight, float maxHeight)
	{
		RecoveryPending.Hit("UghText.SetTextMeshAndWordWrap");
	}

	public UghPublisher GetParentPublisher()
	{
		RecoveryPending.Hit("UghText.GetParentPublisher");
		return default(UghPublisher);
	}
}
