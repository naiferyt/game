using System.Runtime.InteropServices;

namespace System.Reflection
{
	[AttributeUsage(AttributeTargets.Assembly, Inherited = false)]
	[ComVisible(true)]
	public sealed class AssemblyFileVersionAttribute : Attribute
	{
		private string name;

		public AssemblyFileVersionAttribute(string version)
		{
		}
	}
}
