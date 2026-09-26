using System.Runtime.InteropServices;

namespace System
{
	[Serializable]
	[ComVisible(true)]
	[AttributeUsage(AttributeTargets.Class)]
	public sealed class AttributeUsageAttribute : Attribute
	{
		private AttributeTargets valid_on;

		private bool allow_multiple;

		private bool inherited;

		public bool AllowMultiple
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
			set
			{
			}
		}

		public bool Inherited
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
			set
			{
			}
		}

		public AttributeUsageAttribute(AttributeTargets validOn)
		{
		}
	}
}
