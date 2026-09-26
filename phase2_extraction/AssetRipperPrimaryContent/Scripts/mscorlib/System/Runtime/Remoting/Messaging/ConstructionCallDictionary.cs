using System.Runtime.Remoting.Activation;

namespace System.Runtime.Remoting.Messaging
{
	internal class ConstructionCallDictionary : MethodDictionary
	{
		public static string[] InternalKeys;

		public ConstructionCallDictionary(IConstructionCallMessage message)
		{
		}

		protected override object GetMethodProperty(string key)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		protected override void SetMethodProperty(string key, object value)
		{
		}
	}
}
