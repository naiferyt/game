using UnityEngine;

public abstract class BaseMission : MonoBehaviour
{
	public LocalizedString missionName;

	public LocalizedString missionInstructions;

	public LocalizedString missionInstructionsWeb;

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

	public bool GetHasArrow()
	{
		RecoveryPending.Hit("BaseMission.GetHasArrow");
		return default(bool);
	}

	public string GetTaskDisplay()
	{
		RecoveryPending.Hit("BaseMission.GetTaskDisplay");
		return default(string);
	}

	public string GetCurrentMissionName()
	{
		RecoveryPending.Hit("BaseMission.GetCurrentMissionName");
		return default(string);
	}

	public string GetCurrentUntranslatedMissionName()
	{
		RecoveryPending.Hit("BaseMission.GetCurrentUntranslatedMissionName");
		return default(string);
	}
}
