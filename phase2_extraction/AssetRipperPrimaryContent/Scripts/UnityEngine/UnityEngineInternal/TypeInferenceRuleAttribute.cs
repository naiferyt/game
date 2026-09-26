using System;

namespace UnityEngineInternal
{
	[Serializable]
	[AttributeUsage(AttributeTargets.Method)]
	public class TypeInferenceRuleAttribute : Attribute
	{
		private readonly string _rule;

		public TypeInferenceRuleAttribute(TypeInferenceRules rule)
		{
		}

		public TypeInferenceRuleAttribute(string rule)
		{
		}

		public override string ToString()
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}
	}
}
