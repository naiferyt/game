using System.Collections;
using System.Xml.Schema;
using System.Xml.XPath;
using Mono.Xml;

namespace System.Xml
{
	public class XmlDocument : XmlNode, IHasXmlChildNode
	{
		private static readonly Type[] optimal_create_types;

		private bool optimal_create_element;

		private bool optimal_create_attribute;

		private XmlNameTable nameTable;

		private string baseURI;

		private XmlImplementation implementation;

		private bool preserveWhitespace;

		private XmlResolver resolver;

		private Hashtable idTable;

		private XmlNameEntryCache nameCache;

		private XmlLinkedNode lastLinkedChild;

		private XmlAttribute nsNodeXml;

		private XmlSchemaSet schemas;

		private IXmlSchemaInfo schemaInfo;

		private bool loadMode;

		private XmlNodeChangedEventHandler NodeChanged;

		private XmlNodeChangedEventHandler NodeChanging;

		private XmlNodeChangedEventHandler NodeInserted;

		private XmlNodeChangedEventHandler NodeInserting;

		private XmlNodeChangedEventHandler NodeRemoved;

		private XmlNodeChangedEventHandler NodeRemoving;

		XmlLinkedNode IHasXmlChildNode.LastLinkedChild
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
			set
			{
			}
		}

		internal XmlAttribute NsNodeXml
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		public override string BaseURI
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		public XmlElement DocumentElement
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		public virtual XmlDocumentType DocumentType
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		public override bool IsReadOnly
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		public override string LocalName
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		public override string Name
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		internal XmlNameEntryCache NameCache
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		public XmlNameTable NameTable
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		public override XmlNodeType NodeType
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		internal override XPathNodeType XPathNodeType
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		public override XmlDocument OwnerDocument
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		public bool PreserveWhitespace
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		internal XmlResolver Resolver
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		internal override string XmlLang
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		internal override XmlSpace XmlSpace
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		public override XmlNode ParentNode
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		internal override IXmlSchemaInfo SchemaInfo
		{
			set
			{
			}
		}

		public XmlDocument()
		{
		}

		protected internal XmlDocument(XmlImplementation imp)
		{
		}

		private XmlDocument(XmlImplementation impl, XmlNameTable nt)
		{
		}

		internal void AddIdenticalAttribute(XmlAttribute attr)
		{
		}

		public override XmlNode CloneNode(bool deep)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public XmlAttribute CreateAttribute(string name)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public virtual XmlAttribute CreateAttribute(string prefix, string localName, string namespaceURI)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		internal XmlAttribute CreateAttribute(string prefix, string localName, string namespaceURI, bool atomizedNames, bool checkNamespace)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public virtual XmlCDataSection CreateCDataSection(string data)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public virtual XmlComment CreateComment(string data)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public virtual XmlDocumentFragment CreateDocumentFragment()
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public virtual XmlDocumentType CreateDocumentType(string name, string publicId, string systemId, string internalSubset)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		private XmlDocumentType CreateDocumentType(DTDObjectModel dtd)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public virtual XmlElement CreateElement(string prefix, string localName, string namespaceURI)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		internal XmlElement CreateElement(string prefix, string localName, string namespaceURI, bool nameAtomized)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public virtual XmlEntityReference CreateEntityReference(string name)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public override XPathNavigator CreateNavigator()
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		protected internal virtual XPathNavigator CreateNavigator(XmlNode node)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public virtual XmlProcessingInstruction CreateProcessingInstruction(string target, string data)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public virtual XmlSignificantWhitespace CreateSignificantWhitespace(string text)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public virtual XmlText CreateTextNode(string text)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public virtual XmlWhitespace CreateWhitespace(string text)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public virtual XmlDeclaration CreateXmlDeclaration(string version, string encoding, string standalone)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public virtual XmlElement GetElementById(string elementId)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public virtual XmlNodeList GetElementsByTagName(string name)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		internal XmlAttribute GetIdenticalAttribute(string id)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public virtual XmlNode ImportNode(XmlNode node, bool deep)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public virtual void Load(XmlReader xmlReader)
		{
		}

		public virtual void LoadXml(string xml)
		{
		}

		internal void onNodeChanged(XmlNode node, XmlNode parent, string oldValue, string newValue)
		{
		}

		internal void onNodeChanging(XmlNode node, XmlNode parent, string oldValue, string newValue)
		{
		}

		internal void onNodeInserted(XmlNode node, XmlNode newParent)
		{
		}

		internal void onNodeInserting(XmlNode node, XmlNode newParent)
		{
		}

		internal void onNodeRemoved(XmlNode node, XmlNode oldParent)
		{
		}

		internal void onNodeRemoving(XmlNode node, XmlNode oldParent)
		{
		}

		private void ParseName(string name, out string prefix, out string localName)
		{
		}

		private XmlAttribute ReadAttributeNode(XmlReader reader)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		internal void ReadAttributeNodeValue(XmlReader reader, XmlAttribute attribute)
		{
		}

		public virtual XmlNode ReadNode(XmlReader reader)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		private XmlNode ReadNodeCore(XmlReader reader)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		private string MakeReaderErrorMessage(string message, XmlReader reader)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		internal void RemoveIdenticalAttribute(string id)
		{
		}

		private void AddDefaultNameTableKeys()
		{
		}

		internal void CheckIdTableUpdate(XmlAttribute attr, string oldValue, string newValue)
		{
		}
	}
}
