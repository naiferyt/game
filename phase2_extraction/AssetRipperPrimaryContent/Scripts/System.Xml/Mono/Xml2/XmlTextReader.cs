using System;
using System.Collections;
using System.IO;
using System.Text;
using System.Xml;
using Mono.Xml;

namespace Mono.Xml2
{
	internal class XmlTextReader : XmlReader, IHasXmlParserContext, IXmlLineInfo, IXmlNamespaceResolver
	{
		private enum DtdInputState
		{
			Free = 1,
			ElementDecl = 2,
			AttlistDecl = 3,
			EntityDecl = 4,
			NotationDecl = 5,
			PI = 6,
			Comment = 7,
			InsideSingleQuoted = 8,
			InsideDoubleQuoted = 9
		}

		private class DtdInputStateStack
		{
			private Stack intern;

			public DtdInputState Peek()
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}

			public DtdInputState Pop()
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}

			public void Push(DtdInputState val)
			{
			}
		}

		private struct TagName
		{
			public readonly string Name;

			public readonly string LocalName;

			public readonly string Prefix;

			public TagName(string n, string l, string p)
			{
			}
		}

		internal class XmlAttributeTokenInfo : XmlTokenInfo
		{
			public int ValueTokenStartIndex;

			public int ValueTokenEndIndex;

			private string valueCache;

			private StringBuilder tmpBuilder;

			public override string Value
			{
				get
				{
					/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
				}
				set
				{
				}
			}

			public XmlAttributeTokenInfo(XmlTextReader reader)
			{
			}

			public override void Clear()
			{
			}

			internal void FillXmlns()
			{
			}

			internal void FillNamespace()
			{
			}
		}

		internal class XmlTokenInfo
		{
			private string valueCache;

			protected XmlTextReader Reader;

			public string Name;

			public string LocalName;

			public string Prefix;

			public string NamespaceURI;

			public bool IsEmptyElement;

			public char QuoteChar;

			public int LineNumber;

			public int LinePosition;

			public int ValueBufferStart;

			public int ValueBufferEnd;

			public XmlNodeType NodeType;

			public virtual string Value
			{
				get
				{
					/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
				}
				set
				{
				}
			}

			public XmlTokenInfo(XmlTextReader xtr)
			{
			}

			public virtual void Clear()
			{
			}
		}

		private const int peekCharCapacity = 1024;

		private XmlTokenInfo cursorToken;

		private XmlTokenInfo currentToken;

		private XmlAttributeTokenInfo currentAttributeToken;

		private XmlTokenInfo currentAttributeValueToken;

		private XmlAttributeTokenInfo[] attributeTokens;

		private XmlTokenInfo[] attributeValueTokens;

		private int currentAttribute;

		private int currentAttributeValue;

		private int attributeCount;

		private XmlParserContext parserContext;

		private XmlNameTable nameTable;

		private XmlNamespaceManager nsmgr;

		private ReadState readState;

		private bool disallowReset;

		private int depth;

		private int elementDepth;

		private bool depthUp;

		private bool popScope;

		private TagName[] elementNames;

		private int elementNameStackPos;

		private bool allowMultipleRoot;

		private bool isStandalone;

		private bool returnEntityReference;

		private string entityReferenceName;

		private StringBuilder valueBuffer;

		private TextReader reader;

		private char[] peekChars;

		private int peekCharsIndex;

		private int peekCharsLength;

		private int curNodePeekIndex;

		private bool preserveCurrentTag;

		private int line;

		private int column;

		private int currentLinkedNodeLineNumber;

		private int currentLinkedNodeLinePosition;

		private bool useProceedingLineInfo;

		private XmlNodeType startNodeType;

		private XmlNodeType currentState;

		private int nestLevel;

		private bool readCharsInProgress;

		private XmlReaderBinarySupport.CharGetter binaryCharGetter;

		private bool namespaces;

		private WhitespaceHandling whitespaceHandling;

		private XmlResolver resolver;

		private bool normalization;

		private bool checkCharacters;

		private bool prohibitDtd;

		private bool closeInput;

		private EntityHandling entityHandling;

		private NameTable whitespacePool;

		private char[] whitespaceCache;

		private DtdInputStateStack stateStack;

		XmlParserContext IHasXmlParserContext.ParserContext
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		public override int AttributeCount
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

		internal bool CharacterChecking
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
			set
			{
			}
		}

		internal bool CloseInput
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
			set
			{
			}
		}

		public override int Depth
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		public EntityHandling EntityHandling
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		public override bool EOF
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		public override bool IsDefault
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		public override bool IsEmptyElement
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
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

		public override string NamespaceURI
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		public override XmlNameTable NameTable
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

		public override string Prefix
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		public override ReadState ReadState
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		public override XmlReaderSettings Settings
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		public override string Value
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		public WhitespaceHandling WhitespaceHandling
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
			set
			{
			}
		}

		public XmlResolver XmlResolver
		{
			set
			{
			}
		}

		public override XmlSpace XmlSpace
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		internal DTDObjectModel DTD
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

		internal ConformanceLevel Conformance
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
			set
			{
			}
		}

		private DtdInputState State
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		public XmlTextReader(TextReader input, XmlNameTable nt)
		{
		}

		public XmlTextReader(Stream xmlFragment, XmlNodeType fragType, XmlParserContext context)
		{
		}

		public XmlTextReader(string url, Stream input, XmlNameTable nt)
		{
		}

		public XmlTextReader(string url, TextReader input, XmlNameTable nt)
		{
		}

		public XmlTextReader(string xmlFragment, XmlNodeType fragType, XmlParserContext context)
		{
		}

		internal XmlTextReader(string url, TextReader fragment, XmlNodeType fragType, XmlParserContext context)
		{
		}

		string IXmlNamespaceResolver.LookupPrefix(string ns)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public override void Close()
		{
		}

		public override string GetAttribute(string name)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		private int GetIndexOfQualifiedAttribute(string localName, string namespaceURI)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public TextReader GetRemainder()
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public override string LookupNamespace(string prefix)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		private string LookupNamespace(string prefix, bool atomizedNames)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public string LookupPrefix(string ns, bool atomizedName)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public override void MoveToAttribute(int i)
		{
		}

		public override bool MoveToAttribute(string localName, string namespaceName)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public override bool MoveToElement()
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public override bool MoveToFirstAttribute()
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public override bool MoveToNextAttribute()
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public override bool Read()
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public override bool ReadAttributeValue()
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public int ReadChars(char[] buffer, int offset, int length)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public override void ResolveEntity()
		{
		}

		[System.MonoTODO]
		public override void Skip()
		{
		}

		private XmlException NotWFError(string message)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		private void Init()
		{
		}

		private void Clear()
		{
		}

		private void InitializeContext(string url, XmlParserContext context, TextReader fragment, XmlNodeType fragType)
		{
		}

		private void SetProperties(XmlNodeType nodeType, string name, string prefix, string localName, bool isEmptyElement, string value, bool clearAttributes)
		{
		}

		private void SetTokenProperties(XmlTokenInfo token, XmlNodeType nodeType, string name, string prefix, string localName, bool isEmptyElement, string value, bool clearAttributes)
		{
		}

		private void ClearAttributes()
		{
		}

		private int PeekSurrogate(int c)
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

		private void Advance(int ch)
		{
		}

		private bool ReadTextReader(int remained)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		private bool ReadContent()
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		private void SetEntityReferenceProperties()
		{
		}

		private void ReadStartTag()
		{
		}

		private void PushElementName(string name, string local, string prefix)
		{
		}

		private void ReadEndTag()
		{
		}

		private void CheckCurrentStateUpdate()
		{
		}

		private void AppendValueChar(int ch)
		{
		}

		private void AppendSurrogatePairValueChar(int ch)
		{
		}

		private string CreateValueString()
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		private void ClearValueBuffer()
		{
		}

		private void ReadText(bool notWhitespace)
		{
		}

		private int ReadReference(bool ignoreEntityReferences)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		private int ReadCharacterReference()
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		private int ReadEntityReference(bool ignoreEntityReferences)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		private void ReadAttributes(bool isXmlDecl)
		{
		}

		private void AddAttributeWithValue(string name, string value)
		{
		}

		private void IncrementAttributeToken()
		{
		}

		private void IncrementAttributeValueToken()
		{
		}

		private void ReadAttributeValueTokens(int dummyQuoteChar)
		{
		}

		private void CheckAttributeEntityReferenceWFC(string entName)
		{
		}

		private void ReadProcessingInstruction()
		{
		}

		private void VerifyXmlDeclaration()
		{
		}

		private bool SkipWhitespaceInString(string text, ref int idx)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		private void ParseAttributeFromString(string src, ref int idx, out string name, out string value)
		{
		}

		internal void SkipTextDeclaration()
		{
		}

		private void ReadDeclaration()
		{
		}

		private void ReadComment()
		{
		}

		private void ReadCDATA()
		{
		}

		private void ReadDoctypeDecl()
		{
		}

		internal DTDObjectModel GenerateDTDObjectModel(string name, string publicId, string systemId, string internalSubset)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		internal DTDObjectModel GenerateDTDObjectModel(string name, string publicId, string systemId, string internalSubset, int intSubsetStartLine, int intSubsetStartColumn)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		private int ReadValueChar()
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		private void ExpectAndAppend(string s)
		{
		}

		private void ReadInternalSubset()
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

		private string ReadName()
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		private string ReadName(out string prefix, out string localName)
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

		private bool ReadWhitespace()
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		private int ReadCharsInternal(char[] buffer, int offset, int length)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		private bool ReadUntilEndTag()
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}
	}
}
