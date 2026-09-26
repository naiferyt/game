using System.Collections;
using System.Reflection;
using System.Runtime.InteropServices;

namespace System.Runtime.Serialization
{
	[ComVisible(true)]
	public sealed class FormatterServices
	{
		private const BindingFlags fieldFlags = BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic;

		public static object[] GetObjectData(object obj, MemberInfo[] members)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public static MemberInfo[] GetSerializableMembers(Type type, StreamingContext context)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		private static void GetFields(Type reflectedType, Type type, ArrayList fields)
		{
		}

		public static object GetUninitializedObject(Type type)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public static object GetSafeUninitializedObject(Type type)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}
	}
}
