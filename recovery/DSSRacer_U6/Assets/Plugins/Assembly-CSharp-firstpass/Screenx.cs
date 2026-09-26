using UnityEngine;

public class Screenx
{
	public static int baseWidth;

	public static int baseHeight;

	public static float baseAspectRatio
	{
		get
		{
			RecoveryPending.Hit("Screenx.get_baseAspectRatio");
			return default(float);
		}
	}

	public static float aspectRatio
	{
		get
		{
			RecoveryPending.Hit("Screenx.get_aspectRatio");
			return default(float);
		}
	}

	public static float scaleWithCutoff
	{
		get
		{
			RecoveryPending.Hit("Screenx.get_scaleWithCutoff");
			return default(float);
		}
	}

	public static float scale
	{
		get
		{
			RecoveryPending.Hit("Screenx.get_scale");
			return default(float);
		}
	}

	public static Vector3 center
	{
		get
		{
			RecoveryPending.Hit("Screenx.get_center");
			return default(Vector3);
		}
	}

	public static Vector2 bottomLeft
	{
		get
		{
			RecoveryPending.Hit("Screenx.get_bottomLeft");
			return default(Vector2);
		}
	}

	public static Vector2 bottomCenter
	{
		get
		{
			RecoveryPending.Hit("Screenx.get_bottomCenter");
			return default(Vector2);
		}
	}

	public static Vector2 bottomRight
	{
		get
		{
			RecoveryPending.Hit("Screenx.get_bottomRight");
			return default(Vector2);
		}
	}

	public static Vector2 topCenter
	{
		get
		{
			RecoveryPending.Hit("Screenx.get_topCenter");
			return default(Vector2);
		}
	}

	public static Vector2 topLeft
	{
		get
		{
			RecoveryPending.Hit("Screenx.get_topLeft");
			return default(Vector2);
		}
	}

	public static Vector2 topRight
	{
		get
		{
			RecoveryPending.Hit("Screenx.get_topRight");
			return default(Vector2);
		}
	}

	public static Vector2 middleCenter
	{
		get
		{
			RecoveryPending.Hit("Screenx.get_middleCenter");
			return default(Vector2);
		}
	}

	public static Vector2 middleRight
	{
		get
		{
			RecoveryPending.Hit("Screenx.get_middleRight");
			return default(Vector2);
		}
	}

	public static Vector2 middleLeft
	{
		get
		{
			RecoveryPending.Hit("Screenx.get_middleLeft");
			return default(Vector2);
		}
	}

	public static void ScaleGUI()
	{
		RecoveryPending.Hit("Screenx.ScaleGUI");
	}

	public static Vector2 TouchToScreenCords(Vector2 pos)
	{
		RecoveryPending.Hit("Screenx.TouchToScreenCords");
		return default(Vector2);
	}

	public static Vector2 TouchToiPadScreenCoords(Vector2 pos)
	{
		RecoveryPending.Hit("Screenx.TouchToiPadScreenCoords");
		return default(Vector2);
	}

	public static float ScaleGUIToHeight()
	{
		RecoveryPending.Hit("Screenx.ScaleGUIToHeight");
		return default(float);
	}

	public static float ScaleGUIToWidth()
	{
		RecoveryPending.Hit("Screenx.ScaleGUIToWidth");
		return default(float);
	}
}
