using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace System.Reflection
{
	[Serializable]
	[ComVisible(true)]
	[ComDefaultInterface(typeof(_Module))]
	[ClassInterface(ClassInterfaceType.None)]
	public class Module : ICustomAttributeProvider, _Module, ISerializable
	{
		private const BindingFlags defaultBindingFlags = BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public;

		public static readonly TypeFilter FilterTypeName;

		public static readonly TypeFilter FilterTypeNameIgnoreCase;

		private IntPtr _impl;

		internal Assembly assembly;

		internal string fqname;

		internal string name;

		internal string scopename;

		internal bool is_resource;

		internal int token;

		public Assembly Assembly
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		public string ScopeName
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		internal Module()
		{
		}

		static Module()
		{
		}

		public virtual object[] GetCustomAttributes(bool inherit)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public virtual object[] GetCustomAttributes(Type attributeType, bool inherit)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public virtual void GetObjectData(SerializationInfo info, StreamingContext context)
		{
		}

		public virtual bool IsDefined(Type attributeType, bool inherit)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public bool IsResource()
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public override string ToString()
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		private static bool filter_by_type_name(Type m, object filterCriteria)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		private static bool filter_by_type_name_ignore_case(Type m, object filterCriteria)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		internal extern IntPtr GetHINSTANCE();
	}
}
