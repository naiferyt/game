using UnityEngine;

[ExecuteInEditMode]
public class UghCamera : MonoBehaviour
{
	public const int GUI_LAYER = 20;

	public static readonly float PixelsPerUnit;

	private static UghCamera instance;

	public int guiLayer;

	private Vector3 screenSize;

	private Vector3 cachedCameraPixelSize;

	private ScreenOrientation cachedScreenOrientation;

	public static UghCamera Instance
	{
		get
		{
			RecoveryPending.Hit("UghCamera.get_Instance");
			return default(UghCamera);
		}
	}

	public Vector3 CameraPixelSize
	{
		get
		{
			RecoveryPending.Hit("UghCamera.get_CameraPixelSize");
			return default(Vector3);
		}
	}

	public Vector3 ScreenSize
	{
		get
		{
			RecoveryPending.Hit("UghCamera.get_ScreenSize");
			return default(Vector3);
		}
	}

	public Vector3 ScreenExtents
	{
		get
		{
			RecoveryPending.Hit("UghCamera.get_ScreenExtents");
			return default(Vector3);
		}
	}

	public float Aspect
	{
		get
		{
			RecoveryPending.Hit("UghCamera.get_Aspect");
			return default(float);
		}
	}

	public Vector3 ScreenAnchorToPosition(UghSprite.Anchor anchor, Vector3 customAnchor)
	{
		RecoveryPending.Hit("UghCamera.ScreenAnchorToPosition");
		return default(Vector3);
	}

	private void OnLevelWasLoaded()
	{
		RecoveryPending.Hit("UghCamera.OnLevelWasLoaded");
	}

	private void Reset()
	{
		RecoveryPending.Hit("UghCamera.Reset");
	}

	private void Start()
	{
		RecoveryPending.Hit("UghCamera.Start");
	}

	private void Update()
	{
		RecoveryPending.Hit("UghCamera.Update");
	}

	private void ResetCamera()
	{
		RecoveryPending.Hit("UghCamera.ResetCamera");
	}

	private void ResetCameraPosition()
	{
		RecoveryPending.Hit("UghCamera.ResetCameraPosition");
	}
}
