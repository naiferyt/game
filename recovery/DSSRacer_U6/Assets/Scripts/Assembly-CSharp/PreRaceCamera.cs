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
	}

	private void Update()
	{
	}

	private void Awake()
	{
	}

	private void FixedUpdate()
	{
	}

	public void StartCamera()
	{
	}

	public void ShutdownPreRace()
	{
	}

	private void OnDrawGizmos()
	{
	}
}
