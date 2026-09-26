using UnityEngine;

public class PIDVectorController
{
	private float Kp;

	private float Ki;

	private float Kd;

	private Vector3 setPoint;

	private Vector3 previousError;

	private Vector3 integral;

	public PIDVectorController(float proportionGain, float integralGain, float derivativeGain, Vector3 set_point, Vector3 initialValue)
	{
		RecoveryPending.Hit("PIDVectorController..ctor");
	}

	public PIDVectorController(Vector3 set_point, Vector3 initialValue)
	{
		RecoveryPending.Hit("PIDVectorController..ctor");
	}

	public Vector3 CalculateOutput(float deltaTime, Vector3 currentValue)
	{
		RecoveryPending.Hit("PIDVectorController.CalculateOutput");
		return default(Vector3);
	}

	public void SetPoint(Vector3 point)
	{
		RecoveryPending.Hit("PIDVectorController.SetPoint");
	}
}
