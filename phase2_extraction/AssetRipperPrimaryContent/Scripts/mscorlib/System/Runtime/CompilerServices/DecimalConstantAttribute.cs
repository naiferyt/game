using System.Runtime.InteropServices;

namespace System.Runtime.CompilerServices
{
	[Serializable]
	[ComVisible(true)]
	[AttributeUsage(AttributeTargets.Field | AttributeTargets.Parameter, Inherited = false)]
	public sealed class DecimalConstantAttribute : Attribute
	{
		private byte scale;

		private bool sign;

		private int hi;

		private int mid;

		private int low;

		[CLSCompliant(false)]
		public DecimalConstantAttribute(byte scale, byte sign, uint hi, uint mid, uint low)
		{
		}
	}
}
