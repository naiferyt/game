using System.Collections;
using System.Xml.Serialization;

namespace System.Xml.Schema
{
	public abstract class XmlSchemaObject
	{
		private int lineNumber;

		private int linePosition;

		private string sourceUri;

		private XmlSerializerNamespaces namespaces;

		internal ArrayList unhandledAttributeList;

		internal bool isCompiled;

		internal int errorCount;

		internal Guid CompilationId;

		internal Guid ValidationId;

		internal bool isRedefineChild;

		internal bool isRedefinedComponent;

		internal XmlSchemaObject redefinedObject;

		private XmlSchemaObject parent;
	}
}
