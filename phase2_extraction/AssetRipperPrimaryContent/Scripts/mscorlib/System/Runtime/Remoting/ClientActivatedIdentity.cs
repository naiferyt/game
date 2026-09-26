namespace System.Runtime.Remoting
{
	internal class ClientActivatedIdentity : ServerIdentity
	{
		private MarshalByRefObject _targetThis;

		public ClientActivatedIdentity(string objectUri, Type objectType)
		{
		}

		public MarshalByRefObject GetServerObject()
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public override void OnLifetimeExpired()
		{
		}
	}
}
