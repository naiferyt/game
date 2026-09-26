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
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}
	}

	public Vector3 CameraPixelSize
	{
		get
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}
	}

	public Vector3 ScreenSize
	{
		get
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}
	}

	public Vector3 ScreenExtents
	{
		get
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}
	}

	public float Aspect
	{
		get
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}
	}

	public Vector3 ScreenAnchorToPosition(UghSprite.Anchor anchor, Vector3 customAnchor)
	{
		/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
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
