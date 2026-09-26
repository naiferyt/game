using System;

namespace UnityEngine.Internal
{
	[Serializable]
	[AttributeUsage(AttributeTargets.Parameter | AttributeTargets.GenericParameter)]
	public class DefaultValueAttribute : Attribute
	{
		private object DefaultValue;

		public object Value
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		public DefaultValueAttribute(string value)
		{
		}

		public override bool Equals(object obj)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public override int GetHashCode()
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}
	}
}
