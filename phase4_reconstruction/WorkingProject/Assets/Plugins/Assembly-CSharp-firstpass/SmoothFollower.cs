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
	}

	public SmoothFollower(float smoothingTime, float prediction)
	{
	}

	public Vector3 Update(Vector3 targetPositionNew, float deltaTime)
	{
		return default(Vector3);
	}

	public Vector3 Update(Vector3 targetPositionNew, float deltaTime, bool reset)
	{
		return default(Vector3);
	}

	public Vector3 GetPosition()
	{
		return default(Vector3);
	}

	public Vector3 GetVelocity()
	{
		return default(Vector3);
	}
}
