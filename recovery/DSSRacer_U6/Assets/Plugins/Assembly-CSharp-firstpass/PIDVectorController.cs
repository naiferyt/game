using UnityEngine;

// Proportional-integral-derivative controller on a Vector3 (used by GimpedCarAI to settle karts on their path).
// Source listing: recovery/aot_listings/Assembly-CSharp-firstpass/PIDVectorController.txt
public class PIDVectorController
{
	// Field initializers shared by both constructors (tokens 0x0600023a / 0x0600023b).
	private float Kp = 0.6f;

	private float Ki = 0.6f;

	private float Kd = 0.075f;

	private Vector3 setPoint = Vector3.zero;

	private Vector3 previousError = Vector3.zero;

	private Vector3 integral = Vector3.zero;

	// RECUPERADO-AOT PIDVectorController::.ctor token 0x0600023a @0x0002c1b8
	public PIDVectorController(float proportionGain, float integralGain, float derivativeGain, Vector3 set_point, Vector3 initialValue)
	{
		Kp = proportionGain;
		Ki = integralGain;
		Kd = derivativeGain;
		setPoint = set_point;
		previousError = set_point - initialValue;
	}

	// RECUPERADO-AOT PIDVectorController::.ctor token 0x0600023b @0x0002c368
	public PIDVectorController(Vector3 set_point, Vector3 initialValue)
	{
		setPoint = set_point;
		previousError = set_point - initialValue;
	}

	// RECUPERADO-AOT PIDVectorController::CalculateOutput token 0x0600023c @0x0002c4d0
	public Vector3 CalculateOutput(float deltaTime, Vector3 currentValue)
	{
		Vector3 vector = setPoint - currentValue;
		integral += vector * deltaTime;
		Vector3 vector2 = (vector - previousError) / deltaTime;
		Vector3 result = Kp * vector + Ki * integral + Kd * vector2;
		previousError = vector;
		return result;
	}

	// RECUPERADO-AOT PIDVectorController::SetPoint token 0x0600023d @0x0002c784
	public void SetPoint(Vector3 point)
	{
		setPoint = point;
	}
}
