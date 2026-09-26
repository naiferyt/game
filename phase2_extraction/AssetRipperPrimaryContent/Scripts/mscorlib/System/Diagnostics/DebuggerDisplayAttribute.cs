using System.Runtime.InteropServices;

namespace System.Diagnostics
{
	[AttributeUsage(AttributeTargets.Assembly | AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Enum | AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Delegate, AllowMultiple = true)]
	[ComVisible(true)]
	public sealed class DebuggerDisplayAttribute : Attribute
	{
		private string value;

		private string type;

		private string name;

		private string target_type_name;

		private Type target_type;

		public string Name
		{
			set
			{
			}
		}

		public DebuggerDisplayAttribute(string value)
		{
		}
	}
}
