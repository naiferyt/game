using System.Collections;

namespace System.Xml
{
	public class XmlNamespaceManager : IEnumerable, IXmlNamespaceResolver
	{
		private struct NsDecl
		{
			public string Prefix;

			public string Uri;
		}

		private struct NsScope
		{
			public int DeclCount;

			public string DefaultNamespace;
		}

		internal const string XmlnsXml = "http://www.w3.org/XML/1998/namespace";

		internal const string XmlnsXmlns = "http://www.w3.org/2000/xmlns/";

		internal const string PrefixXml = "xml";

		internal const string PrefixXmlns = "xmlns";

		private NsDecl[] decls;

		private int declPos;

		private NsScope[] scopes;

		private int scopePos;

		private string defaultNamespace;

		private int count;

		private XmlNameTable nameTable;

		internal bool internalAtomizedNames;

		public virtual string DefaultNamespace
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		public virtual XmlNameTable NameTable
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		public XmlNamespaceManager(XmlNameTable nameTable)
		{
		}

		private void InitData()
		{
		}

		private void GrowDecls()
		{
		}

		private void GrowScopes()
		{
		}

		public virtual void AddNamespace(string prefix, string uri)
		{
		}

		private void AddNamespace(string prefix, string uri, bool atomizedNames)
		{
		}

		private static string IsValidDeclaration(string prefix, string uri, bool throwException)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public virtual IEnumerator GetEnumerator()
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public virtual string LookupNamespace(string prefix)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		internal string LookupNamespace(string prefix, bool atomizedNames)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public virtual string LookupPrefix(string uri)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		private bool CompareString(string s1, string s2, bool atomizedNames)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		internal string LookupPrefix(string uri, bool atomizedName)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		internal string LookupPrefixExclusive(string uri, bool atomizedName)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		private string LookupPrefixCore(string uri, bool atomizedName, bool excludeOverriden)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		private bool IsOverriden(int idx)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public virtual bool PopScope()
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public virtual void PushScope()
		{
		}

		public virtual void RemoveNamespace(string prefix, string uri)
		{
		}

		private void RemoveNamespace(string prefix, string uri, bool atomizedNames)
		{
		}
	}
}
