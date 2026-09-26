using UnityEngine;

public class FollowCamera : MonoBehaviour
{
	private const int groundLayerMask = 256;

	public GameObject followObject;

	public float followHeight;

	public Vector3 lookAtOffset;

	public Rangef followDistance;

	public Vector2 oblique;

	public Rangef cameraSpeed;

	public AnimationCurve distanceSpeedCurve;

	public AnimationCurve cameraSpeedCurve;

	[HideInInspector]
	public bool crashCam;

	private Camera followCam;

	private CarCollider car;

	private Vector3 crashCamOffset;

	private float driftEase;

	private float driftEaseSpeed;

	private void NoCarUpdate()
	{
	}

	private void WithCarUpdate()
	{
	}

	private void CrashCamUpdate()
	{
	}

	private void Start()
	{
	}

	private void FixedUpdate()
	{
	}

	private void SetCrashCam(bool state)
	{
	}
}
