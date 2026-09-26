using System.Runtime.CompilerServices;
using System.Text;

namespace System.Xml
{
	public sealed class XmlWriterSettings
	{
		private bool checkCharacters;

		private bool closeOutput;

		private ConformanceLevel conformance;

		private Encoding encoding;

		private bool indent;

		private string indentChars;

		private string newLineChars;

		private bool newLineOnAttributes;

		private NewLineHandling newLineHandling;

		private bool omitXmlDeclaration;

		private XmlOutputMethod outputMethod;

		[CompilerGenerated]
		private NamespaceHandling _003CNamespaceHandling_003Ek__BackingField;
	}
}
