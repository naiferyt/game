namespace System.Runtime.Remoting.Activation
{
	[Serializable]
	internal class ContextLevelActivator : IActivator
	{
		private IActivator m_NextActivator;

		public ContextLevelActivator(IActivator next)
		{
		}

		public IConstructionReturnMessage Activate(IConstructionCallMessage ctorCall)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}
	}
}
