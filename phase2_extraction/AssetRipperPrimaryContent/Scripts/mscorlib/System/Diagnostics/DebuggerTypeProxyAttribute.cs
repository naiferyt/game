using System.Runtime.InteropServices;

namespace System.Diagnostics
{
	[AttributeUsage(AttributeTargets.Assembly | AttributeTargets.Class | AttributeTargets.Struct, AllowMultiple = true)]
	[ComVisible(true)]
	public sealed class DebuggerTypeProxyAttribute : Attribute
	{
		private string proxy_type_name;

		private string target_type_name;

		private Type target_type;

		public DebuggerTypeProxyAttribute(Type type)
		{
		}
	}
}
