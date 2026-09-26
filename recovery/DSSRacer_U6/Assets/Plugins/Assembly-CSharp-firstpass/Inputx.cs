using UnityEngine;

public class Inputx
{
	public static bool InputDownStart()
	{
		RecoveryPending.Hit("Inputx.InputDownStart");
		return default(bool);
	}

	public static bool InputDown()
	{
		RecoveryPending.Hit("Inputx.InputDown");
		return default(bool);
	}

	public static bool InputUp()
	{
		RecoveryPending.Hit("Inputx.InputUp");
		return default(bool);
	}

	public static Vector3 InputPosition()
	{
		RecoveryPending.Hit("Inputx.InputPosition");
		return default(Vector3);
	}
}
