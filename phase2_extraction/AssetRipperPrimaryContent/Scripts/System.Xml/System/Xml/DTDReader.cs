using System.Collections;
using System.Text;
using Mono.Xml;

namespace System.Xml
{
	internal class DTDReader : IXmlLineInfo
	{
		private const int initialNameCapacity = 256;

		private XmlParserInput currentInput;

		private Stack parserInputStack;

		private char[] nameBuffer;

		private int nameLength;

		private int nameCapacity;

		private StringBuilder valueBuffer;

		private int currentLinkedNodeLineNumber;

		private int currentLinkedNodeLinePosition;

		private int dtdIncludeSect;

		private bool normalization;

		private bool processingInternalSubset;

		private string cachedPublicId;

		private string cachedSystemId;

		private DTDObjectModel DTD;

		public string BaseURI
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		public bool Normalization
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
			set
			{
			}
		}

		public int LineNumber
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		public int LinePosition
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		public DTDReader(DTDObjectModel dtd, int startLineNumber, int startLinePosition)
		{
		}

		private XmlException NotWFError(string message)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		private void Init()
		{
		}

		internal DTDObjectModel GenerateDTDObjectModel()
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		private bool ProcessDTDSubset()
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		private void CompileDeclaration()
		{
		}

		private void ReadIgnoreSect()
		{
		}

		private DTDElementDeclaration ReadElementDecl()
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		private void ReadContentSpec(DTDElementDeclaration decl)
		{
		}

		private DTDContentModel ReadCP(DTDElementDeclaration elem)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		private void AddContentModel(DTDContentModelCollection cmc, DTDContentModel cm)
		{
		}

		private void ReadParameterEntityDecl()
		{
		}

		private void ResolveExternalEntityReplacementText(DTDEntityBase decl)
		{
		}

		private void ResolveInternalEntityReplacementText(DTDEntityBase decl)
		{
		}

		private int GetCharacterReference(DTDEntityBase li, string value, ref int index, int end)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		private string GetPEValue(string peName)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		private DTDParameterEntityDeclaration GetPEDecl(string peName)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		private bool TryExpandPERef()
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		private bool TryExpandPERefSpaceKeep()
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		private void ExpandPERef()
		{
		}

		private DTDEntityDeclaration ReadEntityDecl()
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		private void ReadEntityValueDecl(DTDEntityDeclaration decl)
		{
		}

		private DTDAttListDeclaration ReadAttListDecl()
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		private DTDAttributeDefinition ReadAttributeDefinition()
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		private DTDNotationDeclaration ReadNotationDecl()
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		private void ReadExternalID()
		{
		}

		private string ReadSystemLiteral(bool expectSYSTEM)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		private string ReadPubidLiteral()
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		internal string ReadName()
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		private string ReadNameOrNmToken(bool isNameToken)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		private void Expect(int expected)
		{
		}

		private void Expect(string expected)
		{
		}

		private void ExpectAfterWhitespace(char c)
		{
		}

		private bool SkipWhitespace()
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		private int PeekChar()
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		private int ReadChar()
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		private void ReadComment()
		{
		}

		private void ReadProcessingInstruction()
		{
		}

		private void ReadTextDeclaration()
		{
		}

		private void AppendNameChar(int ch)
		{
		}

		private void CheckNameCapacity()
		{
		}

		private string CreateNameString()
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		private void AppendValueChar(int ch)
		{
		}

		private string CreateValueString()
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		private void ClearValueBuffer()
		{
		}

		private void PushParserInput(string url)
		{
		}

		private void PopParserInput()
		{
		}

		private void HandleError(XmlException ex)
		{
		}
	}
}
