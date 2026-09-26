using System.Reflection;

namespace System.Runtime.InteropServices
{
	[Guid("FFCC1B5D-ECB8-38DD-9B01-3DC8ABC2AA5F")]
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[CLSCompliant(false)]
	[ComVisible(true)]
	[TypeLibImportClass(typeof(MethodInfo))]
	public interface _MethodInfo
	{
		MemberTypes MemberType { get; }

		Type ReturnType { get; }

		MethodInfo GetBaseDefinition();
	}
}
