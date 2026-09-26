using System.Reflection;

namespace System.Runtime.Serialization
{
	internal class ObjectRecord
	{
		public ObjectRecordStatus Status;

		public object OriginalObject;

		public object ObjectInstance;

		public long ObjectID;

		public SerializationInfo Info;

		public long IdOfContainingObj;

		public ISerializationSurrogate Surrogate;

		public ISurrogateSelector SurrogateSelector;

		public MemberInfo Member;

		public int[] ArrayIndex;

		public BaseFixupRecord FixupChainAsContainer;

		public BaseFixupRecord FixupChainAsRequired;

		public ObjectRecord Next;

		public bool IsInstanceReady
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		public bool IsUnsolvedObjectReference
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		public bool IsRegistered
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		public bool HasPendingFixups
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		public void SetMemberValue(ObjectManager manager, MemberInfo member, object value)
		{
		}

		public void SetArrayValue(ObjectManager manager, object value, int[] indices)
		{
		}

		public void SetMemberValue(ObjectManager manager, string memberName, object value)
		{
		}

		public bool DoFixups(bool asContainer, ObjectManager manager, bool strict)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public void RemoveFixup(BaseFixupRecord fixupToRemove, bool asContainer)
		{
		}

		private void UnchainFixup(BaseFixupRecord fixup, BaseFixupRecord prevFixup, bool asContainer)
		{
		}

		public void ChainFixup(BaseFixupRecord fixup, bool asContainer)
		{
		}

		public bool LoadData(ObjectManager manager, ISurrogateSelector selector, StreamingContext context)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}
	}
}
