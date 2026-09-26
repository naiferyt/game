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
		/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
	}

	public string GetTaskDisplay()
	{
		/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
	}

	public string GetCurrentMissionName()
	{
		/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
	}

	public string GetCurrentUntranslatedMissionName()
	{
		/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
	}
}
