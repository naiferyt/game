using System.Runtime.CompilerServices;

namespace System.Reflection
{
	internal struct MonoMethodInfo
	{
		private Type parent;

		private Type ret;

		internal MethodAttributes attrs;

		internal MethodImplAttributes iattrs;

		private CallingConventions callconv;

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void get_method_info(IntPtr handle, out MonoMethodInfo info);

		internal static MonoMethodInfo GetMethodInfo(IntPtr handle)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		internal static Type GetDeclaringType(IntPtr handle)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		internal static Type GetReturnType(IntPtr handle)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		internal static MethodAttributes GetAttributes(IntPtr handle)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		internal static CallingConventions GetCallingConvention(IntPtr handle)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern ParameterInfo[] get_parameter_info(IntPtr handle, MemberInfo member);

		internal static ParameterInfo[] GetParametersInfo(IntPtr handle, MemberInfo member)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}
	}
}
