using System.Reflection;
using System.Runtime.CompilerServices;

namespace System
{
	internal class MonoCustomAttrs
	{
		private class AttributeInfo
		{
			private AttributeUsageAttribute _usage;

			private int _inheritanceLevel;

			public AttributeUsageAttribute Usage
			{
				get
				{
					/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
				}
			}

			public int InheritanceLevel
			{
				get
				{
					/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
				}
			}

			public AttributeInfo(AttributeUsageAttribute usage, int inheritanceLevel)
			{
			}
		}

		private static Assembly corlib;

		private static readonly Type AttributeUsageType;

		private static readonly AttributeUsageAttribute DefaultAttributeUsage;

		private static bool IsUserCattrProvider(object obj)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		internal static extern object[] GetCustomAttributesInternal(ICustomAttributeProvider obj, Type attributeType, bool pseudoAttrs);

		internal static object[] GetPseudoCustomAttributes(ICustomAttributeProvider obj, Type attributeType)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		internal static object[] GetCustomAttributesBase(ICustomAttributeProvider obj, Type attributeType)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		internal static Attribute GetCustomAttribute(ICustomAttributeProvider obj, Type attributeType, bool inherit)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		internal static object[] GetCustomAttributes(ICustomAttributeProvider obj, Type attributeType, bool inherit)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		internal static object[] GetCustomAttributes(ICustomAttributeProvider obj, bool inherit)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		internal static bool IsDefined(ICustomAttributeProvider obj, Type attributeType, bool inherit)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		internal static extern bool IsDefinedInternal(ICustomAttributeProvider obj, Type AttributeType);

		private static PropertyInfo GetBasePropertyDefinition(PropertyInfo property)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		private static ICustomAttributeProvider GetBase(ICustomAttributeProvider obj)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		private static AttributeUsageAttribute RetrieveAttributeUsage(Type attributeType)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}
	}
}
