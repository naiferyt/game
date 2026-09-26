using System.Runtime.InteropServices;
using System.Runtime.Remoting.Activation;

namespace System.Runtime.Remoting.Contexts
{
	[Serializable]
	[ComVisible(true)]
	[AttributeUsage(AttributeTargets.Class)]
	public class ContextAttribute : Attribute, IContextAttribute, IContextProperty
	{
		protected string AttributeName;

		public virtual string Name
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		public ContextAttribute(string name)
		{
		}

		public override bool Equals(object o)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public override int GetHashCode()
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public virtual void GetPropertiesForNewContext(IConstructionCallMessage ctorMsg)
		{
		}

		public virtual bool IsContextOK(Context ctx, IConstructionCallMessage ctorMsg)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}
	}
}
