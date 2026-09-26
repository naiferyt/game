using System.Collections;
using System.Runtime.CompilerServices;

namespace System.Xml
{
	public sealed class XmlAttributeCollection : XmlNamedNodeMap, ICollection, IEnumerable
	{
		private XmlElement ownerElement;

		private XmlDocument ownerDocument;

		bool ICollection.IsSynchronized
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		object ICollection.SyncRoot
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		private bool IsReadOnly
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		[IndexerName("ItemOf")]
		public XmlAttribute this[string name]
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		[IndexerName("ItemOf")]
		public XmlAttribute this[int i]
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		[IndexerName("ItemOf")]
		public XmlAttribute this[string localName, string namespaceURI]
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		internal XmlAttributeCollection(XmlNode parent)
		{
		}

		void ICollection.CopyTo(Array array, int index)
		{
		}

		public XmlAttribute Remove(XmlAttribute node)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public void RemoveAll()
		{
		}

		public override XmlNode SetNamedItem(XmlNode node)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		private void AdjustIdenticalAttributes(XmlAttribute node, XmlNode existing)
		{
		}

		private XmlNode RemoveIdenticalAttribute(XmlNode existing)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}
	}
}
