using System.Collections;

namespace System.Xml.Schema
{
	public class XmlSchemaSet
	{
		private XmlNameTable nameTable;

		private XmlResolver xmlResolver;

		private ArrayList schemas;

		private XmlSchemaObjectTable attributes;

		private XmlSchemaObjectTable elements;

		private XmlSchemaObjectTable types;

		private Hashtable idCollection;

		private XmlSchemaObjectTable namedIdentities;

		private XmlSchemaCompilationSettings settings;

		private bool isCompiled;

		internal Guid CompilationId;

		private ValidationEventHandler ValidationEventHandler;

		public XmlSchemaSet()
		{
		}

		public XmlSchemaSet(XmlNameTable nameTable)
		{
		}
	}
}
