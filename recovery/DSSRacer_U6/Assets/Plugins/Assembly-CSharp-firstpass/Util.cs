using UnityEngine;

public class Util
{
	public static GameObject Find(Transform root, string name)
	{
		RecoveryPending.Hit("Util.Find");
		return default(GameObject);
	}

	public static void FatalError(string message)
	{
		RecoveryPending.Hit("Util.FatalError");
	}

	public static bool IsSaneNumber(float f)
	{
		RecoveryPending.Hit("Util.IsSaneNumber");
		return default(bool);
	}

	public static string MD5(string strToEncrypt)
	{
		RecoveryPending.Hit("Util.MD5");
		return default(string);
	}

	public static string[] Split(string s)
	{
		RecoveryPending.Hit("Util.Split");
		return default(string[]);
	}

	public static Vector3[] GetCornerPointsFromBounds(Bounds b)
	{
		RecoveryPending.Hit("Util.GetCornerPointsFromBounds");
		return default(Vector3[]);
	}

	public static string toMinuteSeconds(float f)
	{
		RecoveryPending.Hit("Util.toMinuteSeconds");
		return default(string);
	}

	public static string toMinuteSubSeconds(float f)
	{
		RecoveryPending.Hit("Util.toMinuteSubSeconds");
		return default(string);
	}

	public static string GetTimeString(float t)
	{
		RecoveryPending.Hit("Util.GetTimeString");
		return default(string);
	}

	public static Vector3 Clamp(Vector3 v, float length)
	{
		RecoveryPending.Hit("Util.Clamp");
		return default(Vector3);
	}

	public static float Mod(float x, float period)
	{
		RecoveryPending.Hit("Util.Mod");
		return default(float);
	}

	public static int Mod(int x, int period)
	{
		RecoveryPending.Hit("Util.Mod");
		return default(int);
	}

	public static float Mod(float x)
	{
		RecoveryPending.Hit("Util.Mod");
		return default(float);
	}

	public static int Mod(int x)
	{
		RecoveryPending.Hit("Util.Mod");
		return default(int);
	}

	public static float CyclicDiff(float high, float low, float period, bool skipWrap)
	{
		RecoveryPending.Hit("Util.CyclicDiff");
		return default(float);
	}

	public static int CyclicDiff(int high, int low, int period, bool skipWrap)
	{
		RecoveryPending.Hit("Util.CyclicDiff");
		return default(int);
	}

	public static float CyclicDiff(float high, float low, float period)
	{
		RecoveryPending.Hit("Util.CyclicDiff");
		return default(float);
	}

	public static int CyclicDiff(int high, int low, int period)
	{
		RecoveryPending.Hit("Util.CyclicDiff");
		return default(int);
	}

	public static float CyclicDiff(float high, float low)
	{
		RecoveryPending.Hit("Util.CyclicDiff");
		return default(float);
	}

	public static int CyclicDiff(int high, int low)
	{
		RecoveryPending.Hit("Util.CyclicDiff");
		return default(int);
	}

	public static bool CyclicIsLower(float compared, float comparedTo, float reference, float period)
	{
		RecoveryPending.Hit("Util.CyclicIsLower");
		return default(bool);
	}

	public static bool CyclicIsLower(int compared, int comparedTo, int reference, int period)
	{
		RecoveryPending.Hit("Util.CyclicIsLower");
		return default(bool);
	}

	public static bool CyclicIsLower(float compared, float comparedTo, float reference)
	{
		RecoveryPending.Hit("Util.CyclicIsLower");
		return default(bool);
	}

	public static bool CyclicIsLower(int compared, int comparedTo, int reference)
	{
		RecoveryPending.Hit("Util.CyclicIsLower");
		return default(bool);
	}

	public static float CyclicLerp(float a, float b, float t, float period)
	{
		RecoveryPending.Hit("Util.CyclicLerp");
		return default(float);
	}

	public static Vector3 ProjectOntoPlane(Vector3 v, Vector3 normal)
	{
		RecoveryPending.Hit("Util.ProjectOntoPlane");
		return default(Vector3);
	}

	public static Vector3 SetHeight(Vector3 originalVector, Vector3 referenceHeightVector, Vector3 upVector)
	{
		RecoveryPending.Hit("Util.SetHeight");
		return default(Vector3);
	}

	public static Vector3 GetHighest(Vector3 a, Vector3 b, Vector3 upVector)
	{
		RecoveryPending.Hit("Util.GetHighest");
		return default(Vector3);
	}

	public static Vector3 GetLowest(Vector3 a, Vector3 b, Vector3 upVector)
	{
		RecoveryPending.Hit("Util.GetLowest");
		return default(Vector3);
	}

	public static Matrix4x4 RelativeMatrix(Transform t, Transform relativeTo)
	{
		RecoveryPending.Hit("Util.RelativeMatrix");
		return default(Matrix4x4);
	}

	public static Vector3 TransformVector(Matrix4x4 m, Vector3 v)
	{
		RecoveryPending.Hit("Util.TransformVector");
		return default(Vector3);
	}

	public static Vector3 TransformVector(Transform t, Vector3 v)
	{
		RecoveryPending.Hit("Util.TransformVector");
		return default(Vector3);
	}

	public static void TransformFromMatrix(Matrix4x4 matrix, Transform trans)
	{
		RecoveryPending.Hit("Util.TransformFromMatrix");
	}

	public static Quaternion QuaternionFromMatrix(Matrix4x4 m)
	{
		RecoveryPending.Hit("Util.QuaternionFromMatrix");
		return default(Quaternion);
	}

	public static Matrix4x4 MatrixFromQuaternion(Quaternion q)
	{
		RecoveryPending.Hit("Util.MatrixFromQuaternion");
		return default(Matrix4x4);
	}

	public static Matrix4x4 MatrixFromQuaternionPosition(Quaternion q, Vector3 p)
	{
		RecoveryPending.Hit("Util.MatrixFromQuaternionPosition");
		return default(Matrix4x4);
	}

	public static Matrix4x4 MatrixSlerp(Matrix4x4 a, Matrix4x4 b, float t)
	{
		RecoveryPending.Hit("Util.MatrixSlerp");
		return default(Matrix4x4);
	}

	public static Matrix4x4 CreateMatrix(Vector3 right, Vector3 up, Vector3 forward, Vector3 position)
	{
		RecoveryPending.Hit("Util.CreateMatrix");
		return default(Matrix4x4);
	}

	public static Matrix4x4 CreateMatrixPosition(Vector3 position)
	{
		RecoveryPending.Hit("Util.CreateMatrixPosition");
		return default(Matrix4x4);
	}

	public static void TranslateMatrix(ref Matrix4x4 m, Vector3 position)
	{
		RecoveryPending.Hit("Util.TranslateMatrix");
	}

	public static Vector3 ConstantSlerp(Vector3 from, Vector3 to, float angle)
	{
		RecoveryPending.Hit("Util.ConstantSlerp");
		return default(Vector3);
	}

	public static Quaternion ConstantSlerp(Quaternion from, Quaternion to, float angle)
	{
		RecoveryPending.Hit("Util.ConstantSlerp");
		return default(Quaternion);
	}

	public static Vector3 ConstantLerp(Vector3 from, Vector3 to, float length)
	{
		RecoveryPending.Hit("Util.ConstantLerp");
		return default(Vector3);
	}

	public static float ConstantLerp(float from, float to, float length)
	{
		RecoveryPending.Hit("Util.ConstantLerp");
		return default(float);
	}

	public static Vector3 Bezier(Vector3 a, Vector3 b, Vector3 c, Vector3 d, float t)
	{
		RecoveryPending.Hit("Util.Bezier");
		return default(Vector3);
	}

	public static GameObject Create3dText(Font font, string text, Vector3 position, float size, Color color)
	{
		RecoveryPending.Hit("Util.Create3dText");
		return default(GameObject);
	}

	public static float[] GetLineSphereIntersections(Vector3 lineStart, Vector3 lineDir, Vector3 sphereCenter, float sphereRadius)
	{
		RecoveryPending.Hit("Util.GetLineSphereIntersections");
		return default(float[]);
	}
}
