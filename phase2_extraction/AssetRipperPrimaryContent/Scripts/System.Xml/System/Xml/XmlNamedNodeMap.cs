using System.Collections;

namespace System.Xml
{
	public class XmlNamedNodeMap : IEnumerable
	{
		private static readonly IEnumerator emptyEnumerator;

		private XmlNode parent;

		private ArrayList nodeList;

		private bool readOnly;

		private ArrayList NodeList
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		public virtual int Count
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		internal ArrayList Nodes
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		internal XmlNamedNodeMap(XmlNode parent)
		{
		}

		public virtual IEnumerator GetEnumerator()
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public virtual XmlNode GetNamedItem(string name)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public virtual XmlNode GetNamedItem(string localName, string namespaceURI)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public virtual XmlNode RemoveNamedItem(string localName, string namespaceURI)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public virtual XmlNode SetNamedItem(XmlNode node)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		internal XmlNode SetNamedItem(XmlNode node, int pos, bool raiseEvent)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}
	}
}
