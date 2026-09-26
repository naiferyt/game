using System.Globalization;
using System.Reflection;

namespace System.Runtime.InteropServices
{
	[Guid("8A7C1442-A9FB-366B-80D8-4939FFA6DBE0")]
	[TypeLibImportClass(typeof(FieldInfo))]
	[ComVisible(true)]
	[CLSCompliant(false)]
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface _FieldInfo
	{
		FieldAttributes Attributes { get; }

		RuntimeFieldHandle FieldHandle { get; }

		Type FieldType { get; }

		bool IsLiteral { get; }

		bool IsNotSerialized { get; }

		bool IsPublic { get; }

		bool IsStatic { get; }

		MemberTypes MemberType { get; }

		object GetValue(object obj);

		void SetValue(object obj, object value);

		void SetValue(object obj, object value, BindingFlags invokeAttr, Binder binder, CultureInfo culture);
	}
}
