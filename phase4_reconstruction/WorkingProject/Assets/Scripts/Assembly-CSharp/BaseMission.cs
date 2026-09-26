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
		return default(bool);
	}

	public string GetTaskDisplay()
	{
		return default(string);
	}

	public string GetCurrentMissionName()
	{
		return default(string);
	}

	public string GetCurrentUntranslatedMissionName()
	{
		return default(string);
	}
}
