using System.Runtime.Remoting.Messaging;

namespace System.Runtime.Remoting
{
	[Serializable]
	internal class EnvoyInfo : IEnvoyInfo
	{
		private IMessageSink envoySinks;

		public IMessageSink EnvoySinks
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		public EnvoyInfo(IMessageSink sinks)
		{
		}
	}
}
