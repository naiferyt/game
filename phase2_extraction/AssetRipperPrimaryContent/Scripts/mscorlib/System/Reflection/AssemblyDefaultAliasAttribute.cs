using System.Runtime.InteropServices;

namespace System.Reflection
{
	[AttributeUsage(AttributeTargets.Assembly, Inherited = false)]
	[ComVisible(true)]
	public sealed class AssemblyDefaultAliasAttribute : Attribute
	{
		private string name;

		public AssemblyDefaultAliasAttribute(string defaultAlias)
		{
		}
	}
}
