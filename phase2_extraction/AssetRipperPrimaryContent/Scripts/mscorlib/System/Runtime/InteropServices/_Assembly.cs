using System.Reflection;

namespace System.Runtime.InteropServices
{
	[CLSCompliant(false)]
	[InterfaceType(ComInterfaceType.InterfaceIsDual)]
	[Guid("17156360-2F1A-384A-BC52-FDE93C215C5B")]
	[ComVisible(true)]
	[TypeLibImportClass(typeof(Assembly))]
	public interface _Assembly
	{
		string FullName { get; }

		MethodInfo EntryPoint { get; }

		new string ToString();

		AssemblyName GetName();

		AssemblyName GetName(bool copiedName);

		Type GetType(string name);

		Type GetType(string name, bool throwOnError);

		Type GetType(string name, bool throwOnError, bool ignoreCase);

		Module[] GetModules(bool getResourceModules);

		Module GetModule(string name);
	}
}
