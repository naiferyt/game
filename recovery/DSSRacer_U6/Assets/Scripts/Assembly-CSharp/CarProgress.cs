// Race progress of one kart: laps, last progress trigger, distance along the track, final place and time.
// Source listing: recovery/aot_listings/Assembly-CSharp/CarProgress.txt
public class CarProgress
{
	public string carName;

	public int lapCount;

	public float lastDistance;

	public ProgressTriggerLogic lastProgressTrigger;

	public bool isActive;

	public int finalPlace;

	public int finishTime;

	// RECUPERADO-AOT CarProgress::.ctor token 0x06000516 @0x0010dacc
	public CarProgress(string name)
	{
		carName = string.Empty;
		isActive = true;
		carName = name;
	}

	// RECUPERADO-AOT CarProgress::GetProgressCopy token 0x06000517 @0x0010db24
	public CarProgress GetProgressCopy()
	{
		CarProgress carProgress = new CarProgress(carName);
		carProgress.lapCount = lapCount;
		carProgress.lastDistance = lastDistance;
		carProgress.lastProgressTrigger = lastProgressTrigger;
		carProgress.finalPlace = finalPlace;
		carProgress.finishTime = finishTime;
		return carProgress;
	}
}
