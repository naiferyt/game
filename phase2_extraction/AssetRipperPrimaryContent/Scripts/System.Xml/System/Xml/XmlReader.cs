using System.Text;
using System.Xml.Schema;

namespace System.Xml
{
	public abstract class XmlReader : IDisposable
	{
		private StringBuilder readStringBuffer;

		private XmlReaderBinarySupport binary;

		private XmlReaderSettings settings;

		public abstract int AttributeCount { get; }

		public abstract string BaseURI { get; }

		internal XmlReaderBinarySupport Binary
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		public virtual bool CanResolveEntity
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		public abstract int Depth { get; }

		public abstract bool EOF { get; }

		public virtual bool HasAttributes
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		public abstract bool IsEmptyElement { get; }

		public virtual bool IsDefault
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		public virtual string this[string name]
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		public abstract string LocalName { get; }

		public virtual string Name
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		public abstract string NamespaceURI { get; }

		public abstract XmlNameTable NameTable { get; }

		public abstract XmlNodeType NodeType { get; }

		public abstract string Prefix { get; }

		public abstract ReadState ReadState { get; }

		public virtual IXmlSchemaInfo SchemaInfo
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		public virtual XmlReaderSettings Settings
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		public abstract string Value { get; }

		public virtual XmlSpace XmlSpace
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		void IDisposable.Dispose()
		{
		}

		public abstract void Close();

		protected virtual void Dispose(bool disposing)
		{
		}

		public abstract string GetAttribute(string name);

		public abstract string LookupNamespace(string prefix);

		public virtual void MoveToAttribute(int i)
		{
		}

		public abstract bool MoveToAttribute(string localName, string namespaceName);

		public abstract bool MoveToElement();

		public abstract bool MoveToFirstAttribute();

		public abstract bool MoveToNextAttribute();

		public abstract bool Read();

		public abstract bool ReadAttributeValue();

		public virtual string ReadOuterXml()
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public abstract void ResolveEntity();

		public virtual void Skip()
		{
		}
	}
}
