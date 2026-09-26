using System.Reflection;

namespace System.Runtime.InteropServices
{
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[CLSCompliant(false)]
	[ComVisible(true)]
	[TypeLibImportClass(typeof(Type))]
	[Guid("BCA8B44D-AAD6-3A86-8AB7-03349F4F2DA2")]
	public interface _Type
	{
		Assembly Assembly { get; }

		string AssemblyQualifiedName { get; }

		TypeAttributes Attributes { get; }

		Type BaseType { get; }

		Type DeclaringType { get; }

		string FullName { get; }

		Guid GUID { get; }

		bool HasElementType { get; }

		bool IsAbstract { get; }

		bool IsArray { get; }

		bool IsByRef { get; }

		bool IsClass { get; }

		bool IsContextful { get; }

		bool IsEnum { get; }

		bool IsImport { get; }

		bool IsInterface { get; }

		bool IsMarshalByRef { get; }

		bool IsPointer { get; }

		bool IsPrimitive { get; }

		bool IsSealed { get; }

		bool IsSerializable { get; }

		bool IsValueType { get; }

		MemberTypes MemberType { get; }

		Module Module { get; }

		string Namespace { get; }

		Type ReflectedType { get; }

		RuntimeTypeHandle TypeHandle { get; }

		new bool Equals(object other);

		bool Equals(Type o);

		int GetArrayRank();

		ConstructorInfo GetConstructor(Type[] types);

		ConstructorInfo GetConstructor(BindingFlags bindingAttr, Binder binder, Type[] types, ParameterModifier[] modifiers);

		ConstructorInfo GetConstructor(BindingFlags bindingAttr, Binder binder, CallingConventions callConvention, Type[] types, ParameterModifier[] modifiers);

		ConstructorInfo[] GetConstructors(BindingFlags bindingAttr);

		Type GetElementType();

		EventInfo GetEvent(string name, BindingFlags bindingAttr);

		FieldInfo[] GetFields();

		new int GetHashCode();

		Type[] GetInterfaces();

		MethodInfo GetMethod(string name);

		MethodInfo GetMethod(string name, Type[] types);

		MethodInfo GetMethod(string name, BindingFlags bindingAttr, Binder binder, CallingConventions callConvention, Type[] types, ParameterModifier[] modifiers);

		PropertyInfo GetProperty(string name, Type returnType);

		PropertyInfo GetProperty(string name, Type returnType, Type[] types);

		bool IsAssignableFrom(Type c);

		bool IsInstanceOfType(object o);

		bool IsSubclassOf(Type c);

		new string ToString();
	}
}
