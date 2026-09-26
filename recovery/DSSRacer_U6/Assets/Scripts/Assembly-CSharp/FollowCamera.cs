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
		RecoveryPending.Hit("FollowCamera.NoCarUpdate");
	}

	private void WithCarUpdate()
	{
		RecoveryPending.Hit("FollowCamera.WithCarUpdate");
	}

	private void CrashCamUpdate()
	{
		RecoveryPending.Hit("FollowCamera.CrashCamUpdate");
	}

	private void Start()
	{
		RecoveryPending.Hit("FollowCamera.Start");
	}

	private void FixedUpdate()
	{
		RecoveryPending.Hit("FollowCamera.FixedUpdate");
	}

	private void SetCrashCam(bool state)
	{
		RecoveryPending.Hit("FollowCamera.SetCrashCam");
	}
}
