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
	}

	public PIDVectorController(Vector3 set_point, Vector3 initialValue)
	{
	}

	public Vector3 CalculateOutput(float deltaTime, Vector3 currentValue)
	{
		/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
	}

	public void SetPoint(Vector3 point)
	{
	}
}
