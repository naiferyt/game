using System.Runtime.InteropServices;

namespace System
{
	[Serializable]
	[ComVisible(true)]
	[AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Enum | AttributeTargets.Constructor | AttributeTargets.Method | AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Event | AttributeTargets.Interface | AttributeTargets.Delegate, Inherited = false)]
	public sealed class ObsoleteAttribute : Attribute
	{
		private string _message;

		private bool _error;

		public ObsoleteAttribute()
		{
		}

		public ObsoleteAttribute(string message)
		{
		}

		public ObsoleteAttribute(string message, bool error)
		{
		}
	}
}
