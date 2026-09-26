namespace System.Runtime.Serialization.Formatters.Binary
{
	internal abstract class ClrTypeMetadata : TypeMetadata
	{
		public Type InstanceType;

		public override bool RequiresTypes
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		public ClrTypeMetadata(Type instanceType)
		{
		}
	}
}
