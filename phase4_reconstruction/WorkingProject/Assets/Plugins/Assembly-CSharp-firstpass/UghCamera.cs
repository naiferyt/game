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
			return default(UghCamera);
		}
	}

	public Vector3 CameraPixelSize
	{
		get
		{
			return default(Vector3);
		}
	}

	public Vector3 ScreenSize
	{
		get
		{
			return default(Vector3);
		}
	}

	public Vector3 ScreenExtents
	{
		get
		{
			return default(Vector3);
		}
	}

	public float Aspect
	{
		get
		{
			return default(float);
		}
	}

	public Vector3 ScreenAnchorToPosition(UghSprite.Anchor anchor, Vector3 customAnchor)
	{
		return default(Vector3);
	}

	private void OnLevelWasLoaded()
	{
	}

	private void Reset()
	{
	}

	private void Start()
	{
	}

	private void Update()
	{
	}

	private void ResetCamera()
	{
	}

	private void ResetCameraPosition()
	{
	}
}
