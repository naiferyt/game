using System.Collections;
using System.Globalization;
using System.IO;
using System.Text;

namespace System.Xml
{
	public class XmlTextWriter : XmlWriter
	{
		internal class StringUtil
		{
			private static CultureInfo cul;

			private static CompareInfo cmp;

			public static int IndexOf(string src, string target)
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}

			public static string Format(string format, params object[] args)
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		private enum XmlDeclState
		{
			Allow = 0,
			Ignore = 1,
			Auto = 2,
			Prohibit = 3
		}

		private class XmlNodeInfo
		{
			public string Prefix;

			public string LocalName;

			public string NS;

			public bool HasSimple;

			public bool HasElements;

			public string XmlLang;

			public XmlSpace XmlSpace;
		}

		private const string XmlNamespace = "http://www.w3.org/XML/1998/namespace";

		private const string XmlnsNamespace = "http://www.w3.org/2000/xmlns/";

		private static readonly Encoding unmarked_utf8encoding;

		private static char[] escaped_text_chars;

		private static char[] escaped_attr_chars;

		private Stream base_stream;

		private TextWriter source;

		private TextWriter writer;

		private StringWriter preserver;

		private string preserved_name;

		private bool is_preserved_xmlns;

		private bool allow_doc_fragment;

		private bool close_output_stream;

		private bool ignore_encoding;

		private bool namespaces;

		private XmlDeclState xmldecl_state;

		private bool check_character_validity;

		private NewLineHandling newline_handling;

		private bool is_document_entity;

		private WriteState state;

		private XmlNodeType node_state;

		private XmlNamespaceManager nsmanager;

		private int open_count;

		private XmlNodeInfo[] elements;

		private Stack new_local_namespaces;

		private ArrayList explicit_nsdecls;

		private NamespaceHandling namespace_handling;

		private bool indent;

		private int indent_count;

		private char indent_char;

		private string indent_string;

		private string newline;

		private bool indent_attributes;

		private char quote_char;

		private bool v2;

		public override string XmlLang
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		public override XmlSpace XmlSpace
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		public XmlTextWriter(TextWriter writer)
		{
		}

		private void Initialize(TextWriter writer)
		{
		}

		public override string LookupPrefix(string namespaceUri)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public override void Close()
		{
		}

		private void WriteStartDocumentCore(bool outputStd, bool standalone)
		{
		}

		public override void WriteDocType(string name, string pubid, string sysid, string subset)
		{
		}

		public override void WriteStartElement(string prefix, string localName, string namespaceUri)
		{
		}

		private void CloseStartElement()
		{
		}

		private void CloseStartElementCore()
		{
		}

		public override void WriteEndElement()
		{
		}

		public override void WriteFullEndElement()
		{
		}

		private void WriteEndElementCore(bool full)
		{
		}

		public override void WriteStartAttribute(string prefix, string localName, string namespaceUri)
		{
		}

		private string DetermineAttributePrefix(string prefix, string local, string ns)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		private string MockupPrefix(string ns, bool skipLookup)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public override void WriteEndAttribute()
		{
		}

		public override void WriteComment(string text)
		{
		}

		public override void WriteProcessingInstruction(string name, string text)
		{
		}

		public override void WriteWhitespace(string text)
		{
		}

		public override void WriteCData(string text)
		{
		}

		public override void WriteString(string text)
		{
		}

		public override void WriteEntityRef(string name)
		{
		}

		private void WriteIndent()
		{
		}

		private void WriteIndentEndElement()
		{
		}

		private void WriteIndentAttribute()
		{
		}

		private bool WriteIndentCore(int nestFix, bool attribute)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		private void OutputAutoStartDocument()
		{
		}

		private void ShiftStateTopLevel(string occured, bool allowAttribute, bool dontCheckXmlDecl, bool isCharacter)
		{
		}

		private void CheckMixedContentState()
		{
		}

		private void ShiftStateContent(string occured, bool allowAttribute)
		{
		}

		private void WriteEscapedString(string text, bool isAttribute)
		{
		}

		private void WriteCheckedString(string s)
		{
		}

		private void WriteCheckedBuffer(char[] text, int idx, int length)
		{
		}

		private void WriteEscapedBuffer(char[] text, int index, int length, bool isAttribute)
		{
		}

		private Exception ArgumentError(string msg)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		private Exception InvalidOperation(string msg)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		private Exception StateError(string occured)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}
	}
}
