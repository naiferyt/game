using System.Collections;
using System.Runtime.Remoting.Contexts;

namespace System.Runtime.Remoting.Activation
{
	internal class RemoteActivationAttribute : Attribute, IContextAttribute
	{
		private IList _contextProperties;

		public RemoteActivationAttribute(IList contextProperties)
		{
		}

		public bool IsContextOK(Context ctx, IConstructionCallMessage ctor)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public void GetPropertiesForNewContext(IConstructionCallMessage ctor)
		{
		}
	}
}
