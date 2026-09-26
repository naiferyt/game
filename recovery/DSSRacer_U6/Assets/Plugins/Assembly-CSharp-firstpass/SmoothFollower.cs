using UnityEngine;

public class SmoothFollower
{
	private Vector3 targetPosition;

	private Vector3 position;

	private Vector3 velocity;

	private float smoothingTime;

	private float prediction;

	public SmoothFollower(float smoothingTime)
	{
		RecoveryPending.Hit("SmoothFollower..ctor");
	}

	public SmoothFollower(float smoothingTime, float prediction)
	{
		RecoveryPending.Hit("SmoothFollower..ctor");
	}

	public Vector3 Update(Vector3 targetPositionNew, float deltaTime)
	{
		RecoveryPending.Hit("SmoothFollower.Update");
		return default(Vector3);
	}

	public Vector3 Update(Vector3 targetPositionNew, float deltaTime, bool reset)
	{
		RecoveryPending.Hit("SmoothFollower.Update");
		return default(Vector3);
	}

	public Vector3 GetPosition()
	{
		RecoveryPending.Hit("SmoothFollower.GetPosition");
		return default(Vector3);
	}

	public Vector3 GetVelocity()
	{
		RecoveryPending.Hit("SmoothFollower.GetVelocity");
		return default(Vector3);
	}
}
