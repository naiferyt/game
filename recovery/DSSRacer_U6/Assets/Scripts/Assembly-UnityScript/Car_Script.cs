using System;
using UnityEngine;

[Serializable]
public class Car_Script : MonoBehaviour
{
	public Transform wheelFR;

	public Transform wheelFL;

	public Transform wheelBR;

	public Transform wheelBL;

	public float suspensionDistance;

	public float springs;

	public float dampers;

	public float torque;

	public float brakeTorque;

	public float wheelWeight;

	public Vector3 shiftCenter;

	public float frontWheelRadius;

	public float backWheelRadius;

	public float maxSteerAngle;

	public float idleRPM;

	private int currentGear;

	private float wheelRadius;

	public WheelData[] wheels;

	public float wantedRPM;

	public float motorRPM;

	public float killEngine;

	public virtual WheelData SetWheelParams(Transform wheel, float maxSteer, bool motor, float rad)
	{
		RecoveryPending.Hit("Car_Script.SetWheelParams");
		return default(WheelData);
	}

	public virtual void Start()
	{
		RecoveryPending.Hit("Car_Script.Start");
	}

	public virtual void FixedUpdate()
	{
		RecoveryPending.Hit("Car_Script.FixedUpdate");
	}

	public virtual void Main()
	{
		RecoveryPending.Hit("Car_Script.Main");
	}
}
