using System.Collections;
using System.Reflection;
using System.Runtime.InteropServices;

namespace System.Runtime.Serialization
{
	[ComVisible(true)]
	public class ObjectManager
	{
		private ObjectRecord _objectRecordChain;

		private ObjectRecord _lastObjectRecord;

		private ArrayList _deserializedRecords;

		private ArrayList _onDeserializedCallbackRecords;

		private Hashtable _objectRecords;

		private bool _finalFixup;

		private ISurrogateSelector _selector;

		private StreamingContext _context;

		private int _registeredObjectsCount;

		public ObjectManager(ISurrogateSelector selector, StreamingContext context)
		{
		}

		public virtual void DoFixups()
		{
		}

		internal ObjectRecord GetObjectRecord(long objectID)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public virtual object GetObject(long objectID)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public virtual void RaiseDeserializationEvent()
		{
		}

		public void RaiseOnDeserializingEvent(object obj)
		{
		}

		private void RaiseOnDeserializedEvent(object obj)
		{
		}

		private void AddFixup(BaseFixupRecord record)
		{
		}

		public virtual void RecordArrayElementFixup(long arrayToBeFixed, int index, long objectRequired)
		{
		}

		public virtual void RecordArrayElementFixup(long arrayToBeFixed, int[] indices, long objectRequired)
		{
		}

		public virtual void RecordDelayedFixup(long objectToBeFixed, string memberName, long objectRequired)
		{
		}

		public virtual void RecordFixup(long objectToBeFixed, MemberInfo member, long objectRequired)
		{
		}

		private void RegisterObjectInternal(object obj, ObjectRecord record)
		{
		}

		public void RegisterObject(object obj, long objectID, SerializationInfo info, long idOfContainingObj, MemberInfo member, int[] arrayIndex)
		{
		}
	}
}
