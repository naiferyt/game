using UnityEngine;

// Pull-down tab listing the (up to 3) active achievements; slides between inPos and outPos.
// Source listing: recovery/aot_listings/Assembly-CSharp/MissionDialogPublisher.txt
public class MissionDialogPublisher : UghPublisher
{
	public AchievementPanelPublisher[] panels;

	private bool rolledOut;

	// RECUPERADO-AOT MissionDialogPublisher::.ctor token 0x06000794 @0x0013dcc8 (field initializers)
	private Vector3 outPos = new Vector3(0f, 1.2f, -3f);

	private Vector3 inPos = new Vector3(0f, -5.5f, -3f);

	private bool canAct = true;

	// RECUPERADO-AOT MissionDialogPublisher::Start token 0x06000795 @0x0013de54
	private void Start()
	{
		inPos.z = base.transform.position.z;
		outPos.z = base.transform.position.z;
		AchievementManager instance = AchievementManager.Instance;
		if (instance == null)
		{
			UnityEngine.Debug.LogWarning("There is no AchievementManager in the scene");
			return;
		}
		for (int i = 0; i < 3; i++)
		{
			if (i >= instance.activeListeners.Length)
			{
				base.transforms["Mission Slot " + (i + 1)].gameObject.SetActive(false);
				continue;
			}
			AchievementListener achievementListener = instance.activeListeners[i];
			if (achievementListener != null && panels != null && i < panels.Length)
			{
				panels[i].Achievement = achievementListener;
			}
		}
	}

	// RECUPERADO-AOT MissionDialogPublisher::PressedTab token 0x06000796 @0x0013e084
	private void PressedTab()
	{
		if (canAct)
		{
			canAct = false;
			rolledOut = !rolledOut;
		}
	}

	// RECUPERADO-AOT MissionDialogPublisher::FixedUpdate token 0x06000797 @0x0013e0d8
	private void FixedUpdate()
	{
		if (rolledOut)
		{
			base.transform.position = Vector3.Lerp(base.transform.position, outPos, Time.deltaTime * 10f);
		}
		else
		{
			base.transform.position = Vector3.Lerp(base.transform.position, inPos, Time.deltaTime * 10f);
		}
	}

	// RECUPERADO-AOT MissionDialogPublisher::SetRollState token 0x06000798 @0x0013e27c
	public void SetRollState(bool state)
	{
		if (AchievementManager.Instance != null && AchievementManager.Instance.activeListeners.Length <= 0)
		{
			rolledOut = false;
		}
		else
		{
			rolledOut = state;
		}
	}

	// RECUPERADO-AOT MissionDialogPublisher::Update token 0x06000799 @0x0013e2f0
	// ADAPTADO-U6: the Application.isWebPlayer branch is gone (always false); the space-bar shortcut stays editor-only.
	private void Update()
	{
		canAct = true;
		if (Application.isEditor && Input.GetKeyDown(KeyCode.Space))
		{
			PressedTab();
		}
	}
}
