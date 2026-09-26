namespace System.Runtime.Serialization
{
	internal abstract class BaseFixupRecord
	{
		protected internal ObjectRecord ObjectToBeFixed;

		protected internal ObjectRecord ObjectRequired;

		public BaseFixupRecord NextSameContainer;

		public BaseFixupRecord NextSameRequired;

		public BaseFixupRecord(ObjectRecord objectToBeFixed, ObjectRecord objectRequired)
		{
		}

		public bool DoFixup(ObjectManager manager, bool strict)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		protected abstract void FixupImpl(ObjectManager manager);
	}
}
