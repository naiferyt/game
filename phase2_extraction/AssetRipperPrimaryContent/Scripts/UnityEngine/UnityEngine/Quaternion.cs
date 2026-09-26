using System.Reflection;
using System.Runtime.CompilerServices;
using UnityEngine.Internal;

namespace UnityEngine
{
	[DefaultMember("Item")]
	public struct Quaternion
	{
		public const float kEpsilon = 1E-06f;

		public float x;

		public float y;

		public float z;

		public float w;

		public static Quaternion identity
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		public Vector3 eulerAngles
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		public Quaternion(float x, float y, float z, float w)
		{
		}

		public static float Dot(Quaternion a, Quaternion b)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public static Quaternion AngleAxis(float angle, Vector3 axis)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		private static extern Quaternion INTERNAL_CALL_AngleAxis(float angle, ref Vector3 axis);

		public static Quaternion FromToRotation(Vector3 fromDirection, Vector3 toDirection)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		private static extern Quaternion INTERNAL_CALL_FromToRotation(ref Vector3 fromDirection, ref Vector3 toDirection);

		public static Quaternion LookRotation(Vector3 forward, [DefaultValue("Vector3.up")] Vector3 upwards)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		[ExcludeFromDocs]
		public static Quaternion LookRotation(Vector3 forward)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		private static extern Quaternion INTERNAL_CALL_LookRotation(ref Vector3 forward, ref Vector3 upwards);

		public static Quaternion Slerp(Quaternion from, Quaternion to, float t)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		private static extern Quaternion INTERNAL_CALL_Slerp(ref Quaternion from, ref Quaternion to, float t);

		public static Quaternion Lerp(Quaternion from, Quaternion to, float t)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		private static extern Quaternion INTERNAL_CALL_Lerp(ref Quaternion from, ref Quaternion to, float t);

		public static Quaternion Inverse(Quaternion rotation)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		private static extern Quaternion INTERNAL_CALL_Inverse(ref Quaternion rotation);

		public override string ToString()
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public static float Angle(Quaternion a, Quaternion b)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public static Quaternion Euler(float x, float y, float z)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public static Quaternion Euler(Vector3 euler)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		private static Vector3 Internal_ToEulerRad(Quaternion rotation)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		private static extern Vector3 INTERNAL_CALL_Internal_ToEulerRad(ref Quaternion rotation);

		private static Quaternion Internal_FromEulerRad(Vector3 euler)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		private static extern Quaternion INTERNAL_CALL_Internal_FromEulerRad(ref Vector3 euler);

		public override int GetHashCode()
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public override bool Equals(object other)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public static Quaternion operator *(Quaternion lhs, Quaternion rhs)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public static Vector3 operator *(Quaternion rotation, Vector3 point)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}
	}
}
