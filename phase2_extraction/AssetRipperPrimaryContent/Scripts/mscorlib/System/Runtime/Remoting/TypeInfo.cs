namespace System.Runtime.Remoting
{
	[Serializable]
	internal class TypeInfo : IRemotingTypeInfo
	{
		private string serverType;

		private string[] serverHierarchy;

		private string[] interfacesImplemented;

		public string TypeName
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
			set
			{
			}
		}

		public TypeInfo(Type type)
		{
		}

		public bool CanCastTo(Type fromType, object o)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}
	}
}
