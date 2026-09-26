using UnityEngine;

// Lap/checkpoint trigger. Tracks chain their ProgressTriggerLogic objects through nextTrigger;
// exactly one per track has isLapLine = true (see RECOVERY_REPORT.md 6.2).
// Source listing: recovery/aot_listings/Assembly-CSharp/ProgressTriggerLogic.txt
public class ProgressTriggerLogic : MonoBehaviour
{
	public ProgressTriggerLogic nextTrigger;

	public bool isLapLine;

	public float trackDistance;

	// RECUPERADO-AOT ProgressTriggerLogic.CanTriggerForCar token 0x06000527 @0x0010e308
	private bool CanTriggerForCar(GameObject car)
	{
		if (car == null)
		{
			return false;
		}
		if (car.GetComponent<CarCollider>() == null)
		{
			return false;
		}
		ProgressTriggerLogic lastTrigger = RaceManager.GetCarLastProgressTrigger(car);
		if (lastTrigger == null)
		{
			return isLapLine;
		}
		return lastTrigger.nextTrigger == this;
	}

	// RECUPERADO-AOT ProgressTriggerLogic.OnTriggerEnter token 0x06000528 @0x0010e3d8
	private void OnTriggerEnter(Collider other)
	{
		if (!CanTriggerForCar(other.gameObject))
		{
			return;
		}
		RaceManager.SetCarProgressTrigger(other.gameObject, this);
		if (!isLapLine)
		{
			return;
		}
		RaceManager.AdvanceCarLap(other.gameObject);
		CarAIPathRecorder recorder = other.gameObject.GetComponent<CarAIPathRecorder>();
		if (recorder != null)
		{
			recorder.FinishRecording();
			recorder.StartRecording();
		}
	}
}
