using System.Reflection;

namespace System.Runtime.InteropServices
{
	[CLSCompliant(false)]
	[ComVisible(true)]
	[TypeLibImportClass(typeof(EventInfo))]
	[Guid("9DE59C64-D889-35A1-B897-587D74469E5B")]
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface _EventInfo
	{
		EventAttributes Attributes { get; }

		Type EventHandlerType { get; }

		MemberTypes MemberType { get; }

		MethodInfo GetAddMethod(bool nonPublic);
	}
}
