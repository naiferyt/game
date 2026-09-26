using System.Reflection;
using System.Runtime.InteropServices;

namespace System
{
	[Serializable]
	[ComDefaultInterface(typeof(_Attribute))]
	[ClassInterface(ClassInterfaceType.None)]
	[AttributeUsage(AttributeTargets.All)]
	[ComVisible(true)]
	public abstract class Attribute : _Attribute
	{
		private static void CheckParameters(object element, Type attributeType)
		{
		}

		public static Attribute GetCustomAttribute(MemberInfo element, Type attributeType)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public static Attribute GetCustomAttribute(MemberInfo element, Type attributeType, bool inherit)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public override int GetHashCode()
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public static bool IsDefined(ParameterInfo element, Type attributeType)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public static bool IsDefined(MemberInfo element, Type attributeType)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public static bool IsDefined(MemberInfo element, Type attributeType, bool inherit)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public static bool IsDefined(ParameterInfo element, Type attributeType, bool inherit)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public override bool Equals(object obj)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}
	}
}
