using System.Globalization;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;

namespace System
{
	[Serializable]
	internal class MonoType : Type, ISerializable
	{
		[NonSerialized]
		private MonoTypeInfo type_info;

		public override Type UnderlyingSystemType
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		public override extern Assembly Assembly
		{
			[MethodImpl(MethodImplOptions.InternalCall)]
			get;
		}

		public override string AssemblyQualifiedName
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		public override extern Type BaseType
		{
			[MethodImpl(MethodImplOptions.InternalCall)]
			get;
		}

		public override string FullName
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		public override Guid GUID
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		public override MemberTypes MemberType
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		public override extern string Name
		{
			[MethodImpl(MethodImplOptions.InternalCall)]
			get;
		}

		public override extern string Namespace
		{
			[MethodImpl(MethodImplOptions.InternalCall)]
			get;
		}

		public override extern Module Module
		{
			[MethodImpl(MethodImplOptions.InternalCall)]
			get;
		}

		public override extern Type DeclaringType
		{
			[MethodImpl(MethodImplOptions.InternalCall)]
			get;
		}

		public override Type ReflectedType
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		public override RuntimeTypeHandle TypeHandle
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern TypeAttributes get_attributes(Type type);

		internal ConstructorInfo GetDefaultConstructor()
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		protected override TypeAttributes GetAttributeFlagsImpl()
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		protected override ConstructorInfo GetConstructorImpl(BindingFlags bindingAttr, Binder binder, CallingConventions callConvention, Type[] types, ParameterModifier[] modifiers)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		internal extern ConstructorInfo[] GetConstructors_internal(BindingFlags bindingAttr, Type reflected_type);

		public override ConstructorInfo[] GetConstructors(BindingFlags bindingAttr)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern EventInfo InternalGetEvent(string name, BindingFlags bindingAttr);

		public override EventInfo GetEvent(string name, BindingFlags bindingAttr)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		public override extern FieldInfo GetField(string name, BindingFlags bindingAttr);

		[MethodImpl(MethodImplOptions.InternalCall)]
		internal extern FieldInfo[] GetFields_internal(BindingFlags bindingAttr, Type reflected_type);

		public override FieldInfo[] GetFields(BindingFlags bindingAttr)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		public override extern Type[] GetInterfaces();

		[MethodImpl(MethodImplOptions.InternalCall)]
		internal extern MethodInfo[] GetMethodsByName(string name, BindingFlags bindingAttr, bool ignoreCase, Type reflected_type);

		public override MethodInfo[] GetMethods(BindingFlags bindingAttr)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		protected override MethodInfo GetMethodImpl(string name, BindingFlags bindingAttr, Binder binder, CallingConventions callConvention, Type[] types, ParameterModifier[] modifiers)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		internal extern PropertyInfo[] GetPropertiesByName(string name, BindingFlags bindingAttr, bool icase, Type reflected_type);

		protected override PropertyInfo GetPropertyImpl(string name, BindingFlags bindingAttr, Binder binder, Type returnType, Type[] types, ParameterModifier[] modifiers)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		protected override bool HasElementTypeImpl()
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		protected override bool IsArrayImpl()
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		protected override extern bool IsByRefImpl();

		[MethodImpl(MethodImplOptions.InternalCall)]
		protected override extern bool IsPointerImpl();

		[MethodImpl(MethodImplOptions.InternalCall)]
		protected override extern bool IsPrimitiveImpl();

		public override bool IsSubclassOf(Type type)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public override object InvokeMember(string name, BindingFlags invokeAttr, Binder binder, object target, object[] args, ParameterModifier[] modifiers, CultureInfo culture, string[] namedParameters)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		public override extern Type GetElementType();

		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern string getFullName(bool full_name, bool assembly_qualified);

		public override bool IsDefined(Type attributeType, bool inherit)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public override object[] GetCustomAttributes(bool inherit)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public override object[] GetCustomAttributes(Type attributeType, bool inherit)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		public override extern int GetArrayRank();

		public void GetObjectData(SerializationInfo info, StreamingContext context)
		{
		}

		public override string ToString()
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		private MethodBase CheckMethodSecurity(MethodBase mb)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		private void ReorderParamArrayArguments(ref object[] args, MethodBase method)
		{
		}
	}
}
