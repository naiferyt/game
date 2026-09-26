using UnityEngine;

public class CameraShake : MonoBehaviour
{
	public float shakeIntensity;

	public float shakeDuration;

	private float intensity;

	private bool isShaking;

	private bool isStationary;

	private Vector3 originPos;

	private Quaternion originRot;

	public bool IsShaking
	{
		get
		{
			RecoveryPending.Hit("CameraShake.get_IsShaking");
			return default(bool);
		}
	}

	public bool IsStationary
	{
		get
		{
			RecoveryPending.Hit("CameraShake.get_IsStationary");
			return default(bool);
		}
		set
		{
			RecoveryPending.Hit("CameraShake.set_IsStationary");
		}
	}

	private void Start()
	{
		RecoveryPending.Hit("CameraShake.Start");
	}

	private void Update()
	{
		RecoveryPending.Hit("CameraShake.Update");
	}

	public void TurnOnShake(float duration, float intensity)
	{
		RecoveryPending.Hit("CameraShake.TurnOnShake");
	}

	public void TurnOnStationaryShake(float duration, float intensity)
	{
		RecoveryPending.Hit("CameraShake.TurnOnStationaryShake");
	}

	public void TurnOffShake()
	{
		RecoveryPending.Hit("CameraShake.TurnOffShake");
	}
}
