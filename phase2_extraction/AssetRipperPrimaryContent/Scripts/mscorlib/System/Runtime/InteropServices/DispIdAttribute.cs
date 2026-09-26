namespace System.Runtime.InteropServices
{
	[ComVisible(true)]
	[AttributeUsage(AttributeTargets.Method | AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Event, Inherited = false)]
	public sealed class DispIdAttribute : Attribute
	{
		private int id;

		public DispIdAttribute(int dispId)
		{
		}
	}
}
