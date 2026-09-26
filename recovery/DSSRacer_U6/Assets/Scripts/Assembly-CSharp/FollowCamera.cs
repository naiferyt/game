using UnityEngine;

// Chase camera behind the player's kart: distance grows with speed (curve), catches up faster while
// drifting, keeps above the ground, looks slightly above the kart, and uses an oblique projection.
// Source listing: recovery/aot_listings/Assembly-CSharp/FollowCamera.txt
public class FollowCamera : MonoBehaviour
{
	private const int groundLayerMask = 256;

	public GameObject followObject;

	// RECUPERADO-AOT FollowCamera::.ctor token 0x060001a2 @0x000d6538 (field initializers)
	public float followHeight = 2f;

	public Vector3 lookAtOffset = new Vector3(0f, 1.9f, 0f);

	public Rangef followDistance = new Rangef(2f, 6f);

	public Vector2 oblique = new Vector2(0f, 0.25f);

	public Rangef cameraSpeed = new Rangef(7.5f, 15f);

	public AnimationCurve distanceSpeedCurve;

	public AnimationCurve cameraSpeedCurve;

	[HideInInspector]
	public bool crashCam;

	private Camera followCam;

	private CarCollider car;

	private Vector3 crashCamOffset = -Vector3.forward + Vector3.up;

	private float driftEase;

	private float driftEaseSpeed = 4f;

	// RECUPERADO-AOT FollowCamera::NoCarUpdate token 0x060001a3 @0x000d680c
	private void NoCarUpdate()
	{
		Quaternion quaternion = Quaternion.Euler(0f, followObject.transform.rotation.eulerAngles.y, 0f);
		Vector3 vector = quaternion * -Vector3.forward * followDistance.max + Vector3.up * followHeight;
		Vector3 b = vector + followObject.transform.position;
		base.transform.position = Vector3.Slerp(base.transform.position, b, Time.deltaTime * cameraSpeed.min);
	}

	// RECUPERADO-AOT FollowCamera::WithCarUpdate token 0x060001a4 @0x000d6ab0
	// ADAPTADO-U6: Component.camera -> GetComponent<Camera>().
	private void WithCarUpdate()
	{
		if (car.isDrifting)
		{
			driftEase += Time.deltaTime * driftEaseSpeed;
			if (driftEase > 1f)
			{
				driftEase = 1f;
			}
		}
		else
		{
			driftEase -= Time.deltaTime * driftEaseSpeed;
			if (driftEase < 0f)
			{
				driftEase = 0f;
			}
		}
		float num = car.GetVelocity().magnitude / (car.attributes.maxSpeed * 2f);
		if (float.IsNaN(num) || float.IsNegativeInfinity(num) || float.IsPositiveInfinity(num))
		{
			num = 0f;
		}
		float num2 = followDistance.Lerp(distanceSpeedCurve.Evaluate(num));
		Vector3 b = followObject.transform.position + -followObject.transform.forward * num2;
		b += Vector3.up * followHeight;
		Rangef rangef = new Rangef(15f, 60f);
		float num3 = rangef.Lerp(driftEase);
		base.transform.position = Vector3.Lerp(base.transform.position, b, Time.deltaTime * num3);
		Matrix4x4 projectionMatrix = GetComponent<Camera>().projectionMatrix;
		projectionMatrix[0, 2] = oblique.x;
		projectionMatrix[1, 2] = oblique.y;
		GetComponent<Camera>().projectionMatrix = projectionMatrix;
	}

	// RECUPERADO-AOT FollowCamera::CrashCamUpdate token 0x060001a5 @0x000d70e4
	private void CrashCamUpdate()
	{
		base.transform.position = followObject.transform.position + crashCamOffset;
	}

	// RECUPERADO-AOT FollowCamera::Start token 0x060001a6 @0x000d719c
	private void Start()
	{
		followCam = base.gameObject.GetComponent<Camera>();
		if (followCam == null)
		{
			Debug.LogError("There is no Camera on this object!!");
		}
		if (followObject != null)
		{
			car = followObject.GetComponent<CarCollider>();
		}
	}

	// RECUPERADO-AOT FollowCamera::FixedUpdate token 0x060001a7 @0x000d724c
	// Picks up the "Player" object when it appears; lifts the camera if it gets within 1 unit of the ground.
	private void FixedUpdate()
	{
		if (followObject == null)
		{
			followObject = GameObject.FindGameObjectWithTag("Player");
			return;
		}
		if (crashCam)
		{
			CrashCamUpdate();
			return;
		}
		if (car == null)
		{
			car = followObject.GetComponent<CarCollider>();
			NoCarUpdate();
		}
		else
		{
			WithCarUpdate();
		}
		RaycastHit hitInfo;
		if (Physics.Raycast(followCam.gameObject.transform.position, Vector3.down, out hitInfo, float.PositiveInfinity, 256) && hitInfo.distance < 1f)
		{
			followCam.transform.position = followCam.transform.position + new Vector3(0f, followHeight, 0f);
		}
		base.transform.LookAt(followObject.transform.position + lookAtOffset);
	}

	// RECUPERADO-AOT FollowCamera::SetCrashCam token 0x060001a8 @0x000d7570
	public void SetCrashCam(bool state)
	{
		crashCam = state;
		if (followObject != null)
		{
			crashCamOffset = base.transform.position - followObject.transform.position;
		}
	}
}
