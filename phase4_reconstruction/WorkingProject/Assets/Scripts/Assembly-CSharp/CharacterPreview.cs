using UnityEngine;

public class CharacterPreview : MonoBehaviour
{
	public class PreviewPart
	{
		public GameObject mesh;

		public CartPart part;

		public StreamManager.Asset asset;
	}

	private const float IDLE_TIMER = 10f;

	public Material blackoutMaterial;

	private PreviewPart previewCharacter;

	private bool blackedOut;

	private float idleTime;

	private string curAnimName;

	public bool hidden;

	public int randomTime;

	private void Update()
	{
	}

	private void PlayRandomIdleAnimation(Animation anim)
	{
	}

	private void OnDestroy()
	{
	}

	public static void SetCharacter(CartPart part, bool force)
	{
	}

	public static void Refresh(bool force)
	{
	}

	public static void Blackout(bool state)
	{
	}

	public static void Unhide()
	{
	}

	public static void Hide()
	{
	}
}
