using UnityEngine;

// Base of the in-race missions (turn, brake, drift, use a power-up...): texts, optional HUD arrow and signal handling.
// Source listing: recovery/aot_listings/Assembly-CSharp/BaseMission.txt
public abstract class BaseMission : MonoBehaviour
{
	// RECUPERADO-AOT BaseMission::.ctor token 0x06000291 @0x000ea384 (field initializers)
	public LocalizedString missionName = new LocalizedString("Change this mission's name");

	public LocalizedString missionInstructions = new LocalizedString("Change this mission's instructions");

	public LocalizedString missionInstructionsWeb = new LocalizedString("Change this mission's web instructions");

	public MissionManager manager;

	public MissionCollection missionCollection;

	public bool hasArrow;

	public float arrowRotation;

	public float arrowXOffset;

	public float arrowYOffset;

	public abstract void Init();

	public abstract void Update();

	public abstract void Shutdown();

	public abstract void Signal(string signal);

	public abstract void Signal(string signal, object value);

	// RECUPERADO-AOT BaseMission::GetHasArrow token 0x06000297 @0x000ea46c
	public bool GetHasArrow()
	{
		return hasArrow;
	}

	// RECUPERADO-AOT BaseMission::GetTaskDisplay token 0x06000298 @0x000ea4a0
	// Note (original): only the iOS player (RuntimePlatform 8) shows missionInstructions; every other platform,
	// PC included, shows missionInstructionsWeb (the web player's keyboard texts).
	public string GetTaskDisplay()
	{
		if (this is MissionCollection)
		{
			return ((MissionCollection)this).GetTaskDisplay();
		}
		if (Application.platform == (RuntimePlatform)8)
		{
			return missionInstructions.Text;
		}
		return missionInstructionsWeb.Text;
	}

	// RECUPERADO-AOT BaseMission::GetCurrentMissionName token 0x06000299 @0x000ea5bc (GetCurrentMission inlined in the ARM)
	public string GetCurrentMissionName()
	{
		if (this is MissionCollection)
		{
			return ((MissionCollection)this).GetCurrentMission().missionName.Text;
		}
		return missionName.Text;
	}

	// RECUPERADO-AOT BaseMission::GetCurrentUntranslatedMissionName token 0x0600029a @0x000ea6e8 (GetCurrentMission inlined in the ARM)
	public string GetCurrentUntranslatedMissionName()
	{
		if (this is MissionCollection)
		{
			return ((MissionCollection)this).GetCurrentMission().missionName.baseText;
		}
		return missionName.baseText;
	}
}
