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
		RecoveryPending.Hit("CharacterPreview.Update");
	}

	private void PlayRandomIdleAnimation(Animation anim)
	{
		RecoveryPending.Hit("CharacterPreview.PlayRandomIdleAnimation");
	}

	private void OnDestroy()
	{
		RecoveryPending.Hit("CharacterPreview.OnDestroy");
	}

	public static void SetCharacter(CartPart part, bool force)
	{
		RecoveryPending.Hit("CharacterPreview.SetCharacter");
	}

	public static void Refresh(bool force)
	{
		RecoveryPending.Hit("CharacterPreview.Refresh");
	}

	public static void Blackout(bool state)
	{
		RecoveryPending.Hit("CharacterPreview.Blackout");
	}

	public static void Unhide()
	{
		RecoveryPending.Hit("CharacterPreview.Unhide");
	}

	public static void Hide()
	{
		RecoveryPending.Hit("CharacterPreview.Hide");
	}
}
