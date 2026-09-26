using UnityEngine;

public class Util
{
	public static GameObject Find(Transform root, string name)
	{
		return default(GameObject);
	}

	public static void FatalError(string message)
	{
	}

	public static bool IsSaneNumber(float f)
	{
		return default(bool);
	}

	public static string MD5(string strToEncrypt)
	{
		return default(string);
	}

	public static string[] Split(string s)
	{
		return default(string[]);
	}

	public static Vector3[] GetCornerPointsFromBounds(Bounds b)
	{
		return default(Vector3[]);
	}

	public static string toMinuteSeconds(float f)
	{
		return default(string);
	}

	public static string toMinuteSubSeconds(float f)
	{
		return default(string);
	}

	public static string GetTimeString(float t)
	{
		return default(string);
	}

	public static Vector3 Clamp(Vector3 v, float length)
	{
		return default(Vector3);
	}

	public static float Mod(float x, float period)
	{
		return default(float);
	}

	public static int Mod(int x, int period)
	{
		return default(int);
	}

	public static float Mod(float x)
	{
		return default(float);
	}

	public static int Mod(int x)
	{
		return default(int);
	}

	public static float CyclicDiff(float high, float low, float period, bool skipWrap)
	{
		return default(float);
	}

	public static int CyclicDiff(int high, int low, int period, bool skipWrap)
	{
		return default(int);
	}

	public static float CyclicDiff(float high, float low, float period)
	{
		return default(float);
	}

	public static int CyclicDiff(int high, int low, int period)
	{
		return default(int);
	}

	public static float CyclicDiff(float high, float low)
	{
		return default(float);
	}

	public static int CyclicDiff(int high, int low)
	{
		return default(int);
	}

	public static bool CyclicIsLower(float compared, float comparedTo, float reference, float period)
	{
		return default(bool);
	}

	public static bool CyclicIsLower(int compared, int comparedTo, int reference, int period)
	{
		return default(bool);
	}

	public static bool CyclicIsLower(float compared, float comparedTo, float reference)
	{
		return default(bool);
	}

	public static bool CyclicIsLower(int compared, int comparedTo, int reference)
	{
		return default(bool);
	}

	public static float CyclicLerp(float a, float b, float t, float period)
	{
		return default(float);
	}

	public static Vector3 ProjectOntoPlane(Vector3 v, Vector3 normal)
	{
		return default(Vector3);
	}

	public static Vector3 SetHeight(Vector3 originalVector, Vector3 referenceHeightVector, Vector3 upVector)
	{
		return default(Vector3);
	}

	public static Vector3 GetHighest(Vector3 a, Vector3 b, Vector3 upVector)
	{
		return default(Vector3);
	}

	public static Vector3 GetLowest(Vector3 a, Vector3 b, Vector3 upVector)
	{
		return default(Vector3);
	}

	public static Matrix4x4 RelativeMatrix(Transform t, Transform relativeTo)
	{
		return default(Matrix4x4);
	}

	public static Vector3 TransformVector(Matrix4x4 m, Vector3 v)
	{
		return default(Vector3);
	}

	public static Vector3 TransformVector(Transform t, Vector3 v)
	{
		return default(Vector3);
	}

	public static void TransformFromMatrix(Matrix4x4 matrix, Transform trans)
	{
	}

	public static Quaternion QuaternionFromMatrix(Matrix4x4 m)
	{
		return default(Quaternion);
	}

	public static Matrix4x4 MatrixFromQuaternion(Quaternion q)
	{
		return default(Matrix4x4);
	}

	public static Matrix4x4 MatrixFromQuaternionPosition(Quaternion q, Vector3 p)
	{
		return default(Matrix4x4);
	}

	public static Matrix4x4 MatrixSlerp(Matrix4x4 a, Matrix4x4 b, float t)
	{
		return default(Matrix4x4);
	}

	public static Matrix4x4 CreateMatrix(Vector3 right, Vector3 up, Vector3 forward, Vector3 position)
	{
		return default(Matrix4x4);
	}

	public static Matrix4x4 CreateMatrixPosition(Vector3 position)
	{
		return default(Matrix4x4);
	}

	public static void TranslateMatrix(ref Matrix4x4 m, Vector3 position)
	{
	}

	public static Vector3 ConstantSlerp(Vector3 from, Vector3 to, float angle)
	{
		return default(Vector3);
	}

	public static Quaternion ConstantSlerp(Quaternion from, Quaternion to, float angle)
	{
		return default(Quaternion);
	}

	public static Vector3 ConstantLerp(Vector3 from, Vector3 to, float length)
	{
		return default(Vector3);
	}

	public static float ConstantLerp(float from, float to, float length)
	{
		return default(float);
	}

	public static Vector3 Bezier(Vector3 a, Vector3 b, Vector3 c, Vector3 d, float t)
	{
		return default(Vector3);
	}

	public static GameObject Create3dText(Font font, string text, Vector3 position, float size, Color color)
	{
		return default(GameObject);
	}

	public static float[] GetLineSphereIntersections(Vector3 lineStart, Vector3 lineDir, Vector3 sphereCenter, float sphereRadius)
	{
		return default(float[]);
	}
}
