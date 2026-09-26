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
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}
	}

	public bool IsStationary
	{
		get
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}
		set
		{
		}
	}

	private void Start()
	{
	}

	private void Update()
	{
	}

	public void TurnOnShake(float duration, float intensity)
	{
	}

	public void TurnOnStationaryShake(float duration, float intensity)
	{
	}

	public void TurnOffShake()
	{
	}
}
