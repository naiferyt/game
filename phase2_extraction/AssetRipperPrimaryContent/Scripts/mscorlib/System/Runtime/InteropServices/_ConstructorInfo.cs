using System.Reflection;

namespace System.Runtime.InteropServices
{
	[Guid("E9A19478-9646-3679-9B10-8411AE1FD57D")]
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[CLSCompliant(false)]
	[ComVisible(true)]
	[TypeLibImportClass(typeof(ConstructorInfo))]
	public interface _ConstructorInfo
	{
		MemberTypes MemberType { get; }
	}
}
