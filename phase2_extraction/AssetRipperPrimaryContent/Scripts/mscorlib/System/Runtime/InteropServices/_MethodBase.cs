using System.Globalization;
using System.Reflection;

namespace System.Runtime.InteropServices
{
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[CLSCompliant(false)]
	[ComVisible(true)]
	[TypeLibImportClass(typeof(MethodBase))]
	[Guid("6240837A-707F-3181-8E98-A36AE086766B")]
	public interface _MethodBase
	{
		MethodAttributes Attributes { get; }

		CallingConventions CallingConvention { get; }

		bool IsPublic { get; }

		bool IsStatic { get; }

		bool IsVirtual { get; }

		RuntimeMethodHandle MethodHandle { get; }

		ParameterInfo[] GetParameters();

		object Invoke(object obj, object[] parameters);

		object Invoke(object obj, BindingFlags invokeAttr, Binder binder, object[] parameters, CultureInfo culture);
	}
}
