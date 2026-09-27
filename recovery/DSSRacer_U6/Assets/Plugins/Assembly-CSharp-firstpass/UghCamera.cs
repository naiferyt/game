using System;
using UnityEngine;

// Orthographic camera that renders the Ugh UI layer. The UI is laid out in world units (PixelsPerUnit = 100)
// on a virtual screen screenSize.y units tall; the width follows the real aspect ratio.
// Source listing: recovery/aot_listings/Assembly-CSharp-firstpass/UghCamera.txt
[ExecuteInEditMode]
public class UghCamera : MonoBehaviour
{
	public const int GUI_LAYER = 20;

	// RECUPERADO-AOT UghCamera..cctor token 0x0600041d @0x00040f0c
	public static readonly float PixelsPerUnit = 100f;

	private static UghCamera instance;

	// RECUPERADO-AOT UghCamera..ctor token 0x0600041c @0x00040e28 (field initializers)
	public int guiLayer = 20;

	private Vector3 screenSize = new Vector3(7.2f, 9.6f, 0f);

	private Vector3 cachedCameraPixelSize;

	private ScreenOrientation cachedScreenOrientation;

	public static UghCamera Instance
	{
		// RECUPERADO-AOT UghCamera.get_Instance token 0x0600041e @0x00040f58
		get
		{
			if ((bool)instance)
			{
				return instance;
			}
			// ADAPTADO-U6: Object.FindObjectsOfType -> U4Compat (FindObjectsByType)
			UnityEngine.Object[] cameras = U4Compat.FindObjectsOfType(typeof(UghCamera));
			if (cameras.Length > 1)
			{
				throw new Exception("More than one UghCamera in the scene");
			}
			if (cameras.Length == 1)
			{
				instance = cameras[0] as UghCamera;
				return instance;
			}
			GameObject go = new GameObject("+UghCamera", typeof(Camera), typeof(UghCamera));
			instance = go.GetComponent<UghCamera>();
			return instance;
		}
	}

	public Vector3 CameraPixelSize
	{
		// RECUPERADO-AOT UghCamera.get_CameraPixelSize token 0x0600041f @0x00041180
		get
		{
			if (cachedCameraPixelSize == Vector3.zero)
			{
				ResetCamera();
			}
			return cachedCameraPixelSize;
		}
	}

	public Vector3 ScreenSize
	{
		// RECUPERADO-AOT UghCamera.get_ScreenSize token 0x06000420 @0x00041240
		get
		{
			return new Vector3(screenSize.y * Aspect, screenSize.y, 0f);
		}
	}

	public Vector3 ScreenExtents
	{
		// RECUPERADO-AOT UghCamera.get_ScreenExtents token 0x06000421 @0x00041330
		get
		{
			return ScreenSize * 0.5f;
		}
	}

	public float Aspect
	{
		// RECUPERADO-AOT UghCamera.get_Aspect token 0x06000422 @0x000413b4
		get
		{
			if (cachedCameraPixelSize == Vector3.zero)
			{
				ResetCamera();
			}
			return cachedCameraPixelSize.x / cachedCameraPixelSize.y;
		}
	}

	// RECUPERADO-AOT UghCamera.ScreenAnchorToPosition token 0x06000423 @0x0004145c
	public Vector3 ScreenAnchorToPosition(UghSprite.Anchor anchor, Vector3 customAnchor)
	{
		switch (anchor)
		{
		case UghSprite.Anchor.UpperLeft:
			return new Vector3(ScreenSize.x * -0.5f, ScreenSize.y * 0.5f);
		case UghSprite.Anchor.UpperCenter:
			return new Vector3(0f, ScreenSize.y * 0.5f);
		case UghSprite.Anchor.UpperRight:
			return new Vector3(ScreenSize.x * 0.5f, ScreenSize.y * 0.5f);
		case UghSprite.Anchor.MiddleLeft:
			return new Vector3(ScreenSize.x * -0.5f, 0f);
		case UghSprite.Anchor.MiddleCenter:
			return new Vector3(0f, 0f);
		case UghSprite.Anchor.MiddleRight:
			return new Vector3(ScreenSize.x * 0.5f, 0f);
		case UghSprite.Anchor.LowerLeft:
			return new Vector3(ScreenSize.x * -0.5f, ScreenSize.y * -0.5f);
		case UghSprite.Anchor.LowerCenter:
			return new Vector3(0f, ScreenSize.y * -0.5f);
		case UghSprite.Anchor.LowerRight:
			return new Vector3(ScreenSize.x * 0.5f, ScreenSize.y * -0.5f);
		default:
			return new Vector3(customAnchor.x * ScreenSize.x, customAnchor.y * ScreenSize.y, customAnchor.z);
		}
	}

	// RECUPERADO-AOT UghCamera.OnLevelWasLoaded token 0x06000424 @0x00041d70
	// ADAPTADO-U6: OnLevelWasLoaded -> OnLevelWasLoadedU6, sent by U4Compat after each scene load.
	private void OnLevelWasLoadedU6()
	{
		instance = null;
		if (Application.isPlaying)
		{
			ResetCamera();
		}
	}

	// RECUPERADO-AOT UghCamera.Reset token 0x06000425 @0x00041dc8
	private void Reset()
	{
		ResetCamera();
	}

	// RECUPERADO-AOT UghCamera.Start token 0x06000426 @0x00041dfc
	private void Start()
	{
		ResetCamera();
		UghInput unused = UghInput.Instance;
	}

	// RECUPERADO-AOT UghCamera.Update token 0x06000427 @0x00041e38
	// ADAPTADO-U6 (PC, stage 4.0): the original only re-laid the UI out when the device rotated. On PC the window
	// can be resized or switched to another resolution/fullscreen at any time, so a change of the camera's pixel
	// size also resets the camera and marks every aligned/stretched element dirty (they re-anchor on their next
	// Update, as they do at start).
	private void Update()
	{
		if (Screen.orientation != cachedScreenOrientation)
		{
			ResetCamera();
		}
		Camera cam = GetComponent<Camera>();
		if (Application.isPlaying && (cam.pixelWidth != cachedCameraPixelSize.x || cam.pixelHeight != cachedCameraPixelSize.y))
		{
			ResetCamera();
			foreach (UghStretch stretch in UnityEngine.Object.FindObjectsByType<UghStretch>(FindObjectsSortMode.None))
			{
				stretch.IsDirty = true;
			}
			foreach (UghAlign align in UnityEngine.Object.FindObjectsByType<UghAlign>(FindObjectsSortMode.None))
			{
				align.IsDirty = true;
			}
		}
	}

	// RECUPERADO-AOT UghCamera.ResetCamera token 0x06000428 @0x00041e80
	private void ResetCamera()
	{
		// ADAPTADO-U6: Component.camera -> GetComponent<Camera>(); Camera.isOrthoGraphic -> orthographic
		Camera cam = GetComponent<Camera>();
		cam.orthographic = true;
		cam.orthographicSize = screenSize.y / 2f;
		cam.clearFlags = CameraClearFlags.Depth;
		cam.nearClipPlane = 0.3f;
		cam.farClipPlane = 100f;
		cam.cullingMask = 1 << guiLayer;
		ResetCameraPosition();
		cachedScreenOrientation = Screen.orientation;
		cachedCameraPixelSize.x = GetComponent<Camera>().pixelWidth;
		cachedCameraPixelSize.y = GetComponent<Camera>().pixelHeight;
	}

	// RECUPERADO-AOT UghCamera.ResetCameraPosition token 0x06000429 @0x00042010
	private void ResetCameraPosition()
	{
		transform.position = new Vector3(0f, 0f, -10f);
	}
}
