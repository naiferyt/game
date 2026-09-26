using System.Runtime.InteropServices;

namespace System.Diagnostics
{
	[Serializable]
	[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true)]
	[ComVisible(true)]
	public sealed class ConditionalAttribute : Attribute
	{
		private string myCondition;

		public ConditionalAttribute(string conditionString)
		{
		}
	}
}
