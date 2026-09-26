using UnityEngine;

public class PreRaceCamera : MonoBehaviour
{
	public Transform[] targets;

	public float speed;

	public float rotationThreshold;

	private int currentTargetIndex;

	private float timer;

	private float duration;

	private Vector3 lastPos;

	private Quaternion lastRot;

	public float preRaceCamTime;

	private bool isActive;

	private void SetNextTargetIndex(int index)
	{
		RecoveryPending.Hit("PreRaceCamera.SetNextTargetIndex");
	}

	private void Update()
	{
		RecoveryPending.Hit("PreRaceCamera.Update");
	}

	private void Awake()
	{
		RecoveryPending.Hit("PreRaceCamera.Awake");
	}

	private void FixedUpdate()
	{
		RecoveryPending.Hit("PreRaceCamera.FixedUpdate");
	}

	public void StartCamera()
	{
		RecoveryPending.Hit("PreRaceCamera.StartCamera");
	}

	public void ShutdownPreRace()
	{
		RecoveryPending.Hit("PreRaceCamera.ShutdownPreRace");
	}

	private void OnDrawGizmos()
	{
		RecoveryPending.Hit("PreRaceCamera.OnDrawGizmos");
	}
}
