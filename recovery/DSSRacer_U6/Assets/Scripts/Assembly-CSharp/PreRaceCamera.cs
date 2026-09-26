using UnityEngine;

// Track fly-by before the countdown: flies through its target points (or orbits the player's kart when it
// has none) for preRaceCamTime seconds or until a tap, owning the only active camera meanwhile.
// Source listing: recovery/aot_listings/Assembly-CSharp/PreRaceCamera.txt
public class PreRaceCamera : MonoBehaviour
{
	public Transform[] targets;

	// RECUPERADO-AOT PreRaceCamera::.ctor token 0x060001a9 @0x000d7644 (field initializers)
	public float speed = 40f;

	public float rotationThreshold = 1f;

	private int currentTargetIndex;

	private float timer;

	private float duration;

	private Vector3 lastPos;

	private Quaternion lastRot;

	public float preRaceCamTime = 5f;

	private bool isActive;

	// RECUPERADO-AOT PreRaceCamera::SetNextTargetIndex token 0x060001aa @0x000d76c0
	// The leg duration comes from the distance at the camera speed. (The original guard is
	// "targets != null || index < targets.Length", so stepping past the last point indexes out of range;
	// kept as is.)
	private void SetNextTargetIndex(int index)
	{
		timer = 0f;
		currentTargetIndex = index;
		if (targets != null || currentTargetIndex < targets.Length)
		{
			duration = (targets[currentTargetIndex].position - base.transform.position).magnitude / speed;
		}
	}

	// RECUPERADO-AOT PreRaceCamera::Update token 0x060001ab @0x000d77f8
	private void Update()
	{
		if (isActive)
		{
			preRaceCamTime -= Time.deltaTime;
			if (preRaceCamTime <= 0f || UghInput.IsInputDown)
			{
				RaceManager.Instance.preRaceActive = false;
				ShutdownPreRace();
			}
		}
	}

	// RECUPERADO-AOT PreRaceCamera::Awake token 0x060001ac @0x000d789c
	private void Awake()
	{
		AudioListener component = base.gameObject.GetComponent<AudioListener>();
		if (component != null)
		{
			if (!RaceManager.Instance.preRaceActive)
			{
				base.gameObject.GetComponent<AudioListener>().enabled = false;
			}
			else
			{
				base.gameObject.GetComponent<AudioListener>().enabled = true;
			}
		}
	}

	// RECUPERADO-AOT PreRaceCamera::FixedUpdate token 0x060001ad @0x000d7978
	private void FixedUpdate()
	{
		if (!isActive)
		{
			return;
		}
		if (targets.Length > 0)
		{
			Transform transform = base.transform;
			if (targets != null && currentTargetIndex < targets.Length)
			{
				transform = targets[currentTargetIndex];
			}
			timer += Time.deltaTime;
			float num = timer / duration;
			if (num >= 1f)
			{
				base.transform.position = (lastPos = transform.position);
				base.transform.rotation = (lastRot = transform.rotation);
				SetNextTargetIndex(currentTargetIndex + 1);
			}
			else
			{
				base.transform.position = Vector3.Slerp(lastPos, transform.position, num);
				base.transform.rotation = Quaternion.Slerp(lastRot, transform.rotation, num);
			}
			return;
		}
		GameObject playerCar = RaceManager.GetPlayerCar();
		if (playerCar != null)
		{
			Vector3 vector = base.transform.position - playerCar.transform.position;
			vector = Quaternion.Euler(0f, Time.deltaTime * speed, 0f) * vector;
			float magnitude = vector.magnitude;
			if (magnitude > 10f)
			{
				vector = vector.normalized * (magnitude - speed * Time.deltaTime);
			}
			else if (magnitude < 5f)
			{
				vector = vector.normalized * (magnitude + speed * Time.deltaTime);
			}
			base.transform.position = playerCar.transform.position + vector;
			base.transform.rotation = Quaternion.LookRotation(-vector);
		}
	}

	// RECUPERADO-AOT PreRaceCamera::StartCamera token 0x060001ae @0x000d8050
	// Disables every other camera (and its audio listener) and starts at the first target, or above and
	// ahead of the player's kart looking at it.
	// ADAPTADO-U6: GameObject.camera -> GetComponent<Camera>(); FindObjectsOfType -> U4Compat.
	public void StartCamera()
	{
		RaceManager.Instance.preRaceActive = true;
		Object[] array = U4Compat.FindObjectsOfType(typeof(Camera));
		for (int i = 0; i < array.Length; i++)
		{
			Camera camera = (Camera)array[i];
			if (camera != base.gameObject.GetComponent<Camera>())
			{
				if (camera.gameObject.GetComponent<AudioListener>() != null)
				{
					camera.gameObject.GetComponent<AudioListener>().enabled = false;
				}
				camera.enabled = false;
			}
			else if (camera.gameObject.GetComponent<AudioListener>() != null)
			{
				camera.gameObject.GetComponent<AudioListener>().enabled = true;
			}
		}
		if (targets != null && targets.Length > 0)
		{
			base.transform.position = (lastPos = targets[0].position);
			base.transform.rotation = (lastRot = targets[0].rotation);
			SetNextTargetIndex(1);
		}
		else
		{
			GameObject playerCar = RaceManager.GetPlayerCar();
			if (playerCar != null)
			{
				Vector3 position = playerCar.transform.position + playerCar.transform.forward * 10f;
				position += Vector3.up * 5f;
				base.transform.position = position;
				base.transform.rotation = Quaternion.LookRotation(playerCar.transform.position - base.transform.position);
			}
		}
		isActive = true;
	}

	// RECUPERADO-AOT PreRaceCamera::ShutdownPreRace token 0x060001af @0x000d865c
	// ADAPTADO-U6: GameObject.camera -> GetComponent<Camera>(); FindObjectsOfType -> U4Compat.
	private void ShutdownPreRace()
	{
		isActive = false;
		Object[] array = U4Compat.FindObjectsOfType(typeof(Camera));
		for (int i = 0; i < array.Length; i++)
		{
			Camera camera = (Camera)array[i];
			if (camera != base.gameObject.GetComponent<Camera>())
			{
				if (camera.gameObject.GetComponent<AudioListener>() != null)
				{
					camera.gameObject.GetComponent<AudioListener>().enabled = true;
				}
				camera.enabled = true;
			}
		}
		Object.Destroy(base.gameObject);
	}

	// RECUPERADO-AOT PreRaceCamera::OnDrawGizmos token 0x060001b0 @0x000d87e8
	private void OnDrawGizmos()
	{
		if (targets.Length > 1)
		{
			Gizmos.color = Color.yellow;
			for (int i = 1; i < targets.Length; i++)
			{
				Gizmos.DrawLine(targets[i - 1].position, targets[i].position);
			}
		}
	}
}
