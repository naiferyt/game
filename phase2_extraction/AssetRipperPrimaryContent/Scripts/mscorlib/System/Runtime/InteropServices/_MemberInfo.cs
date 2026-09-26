using System.Reflection;

namespace System.Runtime.InteropServices
{
	[TypeLibImportClass(typeof(MemberInfo))]
	[Guid("f7102fa9-cabb-3a74-a6da-b4567ef1b079")]
	[CLSCompliant(false)]
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[ComVisible(true)]
	public interface _MemberInfo
	{
		Type DeclaringType { get; }

		MemberTypes MemberType { get; }

		string Name { get; }

		Type ReflectedType { get; }
	}
}
