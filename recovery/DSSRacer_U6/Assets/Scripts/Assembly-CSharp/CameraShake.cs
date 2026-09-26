using UnityEngine;

// Random position/rotation jitter that decays over time (around the camera's current pose, or a fixed origin).
// Source listing: recovery/aot_listings/Assembly-CSharp/CameraShake.txt
public class CameraShake : MonoBehaviour
{
	// RECUPERADO-AOT CameraShake::.ctor token 0x060003f8 @0x000fa808 (field initializers)
	public float shakeIntensity = 0.2f;

	public float shakeDuration = -1f;

	private float intensity = 1f;

	private bool isShaking;

	private bool isStationary;

	private Vector3 originPos;

	private Quaternion originRot;

	// RECUPERADO-AOT CameraShake::get_IsShaking token 0x060003f9 @0x000fa884
	public bool IsShaking
	{
		get
		{
			return isShaking;
		}
	}

	// RECUPERADO-AOT CameraShake::get_IsStationary token 0x060003fa @0x000fa8b8
	// RECUPERADO-AOT CameraShake::set_IsStationary token 0x060003fb @0x000fa8ec
	public bool IsStationary
	{
		get
		{
			return isStationary;
		}
		set
		{
			isStationary = value;
		}
	}

	// RECUPERADO-AOT CameraShake::Start token 0x060003fc @0x000fa928
	private void Start()
	{
		intensity = shakeIntensity;
	}

	// RECUPERADO-AOT CameraShake::Update token 0x060003fd @0x000fa968
	private void Update()
	{
		if (!isShaking)
		{
			return;
		}
		if (shakeDuration > 0f)
		{
			shakeDuration -= Time.deltaTime * 0.5f;
			intensity *= shakeDuration;
			if (!(shakeDuration > 0f))
			{
				TurnOffShake();
			}
		}
		if (isStationary)
		{
			base.transform.position = originPos + Random.insideUnitSphere * intensity;
			base.transform.rotation = new Quaternion(originRot.x + Random.Range(0f - intensity, intensity) * 0.1f, originRot.y + Random.Range(0f - intensity, intensity) * 0.1f, originRot.z + Random.Range(0f - intensity, intensity) * 0.1f, originRot.w + Random.Range(0f - intensity, intensity) * 0.1f);
		}
		else
		{
			base.transform.position = base.transform.position + Random.insideUnitSphere * intensity;
			base.transform.rotation = new Quaternion(base.transform.rotation.x + Random.Range(0f - intensity, intensity) * 0.1f, base.transform.rotation.y + Random.Range(0f - intensity, intensity) * 0.1f, base.transform.rotation.z + Random.Range(0f - intensity, intensity) * 0.1f, base.transform.rotation.w + Random.Range(0f - intensity, intensity) * 0.1f);
		}
	}

	// RECUPERADO-AOT CameraShake::TurnOnShake token 0x060003fe @0x000fb138
	public void TurnOnShake(float duration, float intensity)
	{
		if (duration > 0f)
		{
			shakeDuration = duration;
		}
		this.intensity = shakeIntensity;
		if (intensity > 0f)
		{
			this.intensity = intensity;
		}
		isShaking = true;
	}

	// RECUPERADO-AOT CameraShake::TurnOnStationaryShake token 0x060003ff @0x000fb1f4
	public void TurnOnStationaryShake(float duration, float intensity)
	{
		originPos = base.transform.position;
		originRot = base.transform.rotation;
		if (duration > 0f)
		{
			shakeDuration = duration;
		}
		this.intensity = shakeIntensity;
		if (intensity > 0f)
		{
			this.intensity = intensity;
		}
		isShaking = true;
		isStationary = true;
	}

	// RECUPERADO-AOT CameraShake::TurnOffShake token 0x06000400 @0x000fb330
	public void TurnOffShake()
	{
		shakeDuration = 0f;
		intensity = 0f;
		isShaking = false;
		isStationary = false;
	}
}
