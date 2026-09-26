using System.Globalization;
using System.Reflection;

namespace System.Runtime.InteropServices
{
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[TypeLibImportClass(typeof(PropertyInfo))]
	[ComVisible(true)]
	[CLSCompliant(false)]
	[Guid("F59ED4E4-E68F-3218-BD77-061AA82824BF")]
	public interface _PropertyInfo
	{
		PropertyAttributes Attributes { get; }

		MemberTypes MemberType { get; }

		Type PropertyType { get; }

		MethodInfo GetGetMethod(bool nonPublic);

		ParameterInfo[] GetIndexParameters();

		MethodInfo GetSetMethod(bool nonPublic);

		void SetValue(object obj, object value, object[] index);

		void SetValue(object obj, object value, BindingFlags invokeAttr, Binder binder, object[] index, CultureInfo culture);
	}
}
