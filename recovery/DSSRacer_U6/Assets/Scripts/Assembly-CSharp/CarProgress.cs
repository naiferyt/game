public class CarProgress
{
	public string carName;

	public int lapCount;

	public float lastDistance;

	public ProgressTriggerLogic lastProgressTrigger;

	public bool isActive;

	public int finalPlace;

	public int finishTime;

	public CarProgress(string name)
	{
		RecoveryPending.Hit("CarProgress..ctor");
	}

	public CarProgress GetProgressCopy()
	{
		RecoveryPending.Hit("CarProgress.GetProgressCopy");
		return default(CarProgress);
	}
}
