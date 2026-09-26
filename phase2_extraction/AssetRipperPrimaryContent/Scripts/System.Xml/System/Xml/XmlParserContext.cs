using System.Collections;
using System.Text;
using Mono.Xml;

namespace System.Xml
{
	public class XmlParserContext
	{
		private class ContextItem
		{
			public string BaseURI;

			public string XmlLang;

			public XmlSpace XmlSpace;
		}

		private string baseURI;

		private string docTypeName;

		private Encoding encoding;

		private string internalSubset;

		private XmlNamespaceManager namespaceManager;

		private XmlNameTable nameTable;

		private string publicID;

		private string systemID;

		private string xmlLang;

		private XmlSpace xmlSpace;

		private ArrayList contextItems;

		private int contextItemCount;

		private DTDObjectModel dtd;

		public string BaseURI
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
			set
			{
			}
		}

		public string DocTypeName
		{
			set
			{
			}
		}

		internal DTDObjectModel Dtd
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
			set
			{
			}
		}

		public Encoding Encoding
		{
			set
			{
			}
		}

		public string InternalSubset
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
			set
			{
			}
		}

		public XmlNamespaceManager NamespaceManager
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

		public string PublicId
		{
			set
			{
			}
		}

		public string SystemId
		{
			set
			{
			}
		}

		public string XmlLang
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
			set
			{
			}
		}

		public XmlSpace XmlSpace
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
			set
			{
			}
		}

		public XmlParserContext(XmlNameTable nt, XmlNamespaceManager nsMgr, string xmlLang, XmlSpace xmlSpace)
		{
		}

		public XmlParserContext(XmlNameTable nt, XmlNamespaceManager nsMgr, string docTypeName, string pubId, string sysId, string internalSubset, string baseURI, string xmlLang, XmlSpace xmlSpace, Encoding enc)
		{
		}

		internal XmlParserContext(XmlNameTable nt, XmlNamespaceManager nsMgr, DTDObjectModel dtd, string baseURI, string xmlLang, XmlSpace xmlSpace, Encoding enc)
		{
		}

		internal void PushScope()
		{
		}

		internal void PopScope()
		{
		}
	}
}
