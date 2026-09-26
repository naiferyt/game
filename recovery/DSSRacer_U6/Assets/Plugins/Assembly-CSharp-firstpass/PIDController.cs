public class PIDController
{
	private float Kp;

	private float Ki;

	private float Kd;

	private float setPoint;

	private float previousError;

	private float integral;

	public PIDController(float proportionGain, float integralGain, float derivativeGain, float set_point, float initialValue)
	{
	}

	public PIDController(float set_point, float initialValue)
	{
	}

	public float CalculateOutput(float deltaTime, float currentValue)
	{
		/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
	}

	public void SetPoint(float point)
	{
	}
}
