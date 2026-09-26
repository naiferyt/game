namespace System.Runtime.Remoting.Activation
{
	internal class AppDomainLevelActivator : IActivator
	{
		private string _activationUrl;

		private IActivator _next;

		public AppDomainLevelActivator(string activationUrl, IActivator next)
		{
		}

		public IConstructionReturnMessage Activate(IConstructionCallMessage ctorCall)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}
	}
}
