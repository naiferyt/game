using System.Collections;

namespace System.Xml
{
	internal class XmlNodeListChildren : XmlNodeList
	{
		private class Enumerator : IEnumerator
		{
			private IHasXmlChildNode parent;

			private XmlLinkedNode currentChild;

			private bool passedLastNode;

			public virtual object Current
			{
				get
				{
					/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
				}
			}

			internal Enumerator(IHasXmlChildNode parent)
			{
			}

			public virtual bool MoveNext()
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}

			public virtual void Reset()
			{
			}
		}

		private IHasXmlChildNode parent;

		public override int Count
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		public XmlNodeListChildren(IHasXmlChildNode parent)
		{
		}

		public override IEnumerator GetEnumerator()
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public override XmlNode Item(int index)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}
	}
}
