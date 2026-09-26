using System.Collections;
using System.Diagnostics;

namespace System.Xml.XPath
{
	public abstract class XPathNavigator : XPathItem, ICloneable, IXmlNamespaceResolver, IXPathNavigable
	{
		private class EnumerableIterator : XPathNodeIterator
		{
			private IEnumerable source;

			private IEnumerator e;

			private int pos;

			public override int CurrentPosition
			{
				get
				{
					/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
				}
			}

			public override XPathNavigator Current
			{
				get
				{
					/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
				}
			}

			public EnumerableIterator(IEnumerable source, int pos)
			{
			}

			public override XPathNodeIterator Clone()
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}

			public override bool MoveNext()
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		private static readonly char[] escape_text_chars;

		private static readonly char[] escape_attr_chars;

		public virtual bool HasAttributes
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		public virtual bool HasChildren
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		public abstract string LocalName { get; }

		public abstract string Name { get; }

		public abstract string NamespaceURI { get; }

		public abstract XPathNodeType NodeType { get; }

		public virtual string XmlLang
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		object ICloneable.Clone()
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public abstract XPathNavigator Clone();

		public virtual XmlNodeOrder ComparePosition(XPathNavigator nav)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public virtual XPathExpression Compile(string xpath)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public virtual bool IsDescendant(XPathNavigator nav)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public abstract bool IsSamePosition(XPathNavigator other);

		public abstract bool MoveTo(XPathNavigator other);

		public virtual bool MoveToAttribute(string localName, string namespaceURI)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public virtual bool MoveToNamespace(string name)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public virtual bool MoveToFirst()
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public virtual void MoveToRoot()
		{
		}

		internal bool MoveToFirstImpl()
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public abstract bool MoveToFirstAttribute();

		public abstract bool MoveToFirstChild();

		public bool MoveToFirstNamespace()
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public abstract bool MoveToFirstNamespace(XPathNamespaceScope namespaceScope);

		public abstract bool MoveToId(string id);

		public abstract bool MoveToNext();

		public abstract bool MoveToNextAttribute();

		public bool MoveToNextNamespace()
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public abstract bool MoveToNextNamespace(XPathNamespaceScope namespaceScope);

		public abstract bool MoveToParent();

		public virtual XPathNodeIterator Select(XPathExpression expr)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		internal XPathNodeIterator Select(XPathExpression expr, IXmlNamespaceResolver ctx)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		[DebuggerHidden]
		private static IEnumerable EnumerateChildren(XPathNavigator n, XPathNodeType type)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public virtual XPathNodeIterator SelectChildren(XPathNodeType type)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public override string ToString()
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public virtual XPathNavigator CreateNavigator()
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public virtual string LookupNamespace(string prefix)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public virtual string LookupPrefix(string namespaceUri)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}
	}
}
