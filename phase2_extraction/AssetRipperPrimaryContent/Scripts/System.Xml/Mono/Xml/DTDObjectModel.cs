using System.Collections;
using System.Xml;
using Mono.Xml2;

namespace Mono.Xml
{
	internal class DTDObjectModel
	{
		public const int AllowedExternalEntitiesMax = 256;

		private DTDAutomataFactory factory;

		private DTDElementAutomata rootAutomata;

		private DTDEmptyAutomata emptyAutomata;

		private DTDAnyAutomata anyAutomata;

		private DTDInvalidAutomata invalidAutomata;

		private DTDElementDeclarationCollection elementDecls;

		private DTDAttListDeclarationCollection attListDecls;

		private DTDParameterEntityDeclarationCollection peDecls;

		private DTDEntityDeclarationCollection entityDecls;

		private DTDNotationDeclarationCollection notationDecls;

		private ArrayList validationErrors;

		private XmlResolver resolver;

		private XmlNameTable nameTable;

		private Hashtable externalResources;

		private string baseURI;

		private string name;

		private string publicId;

		private string systemId;

		private string intSubset;

		private bool intSubsetHasPERef;

		private bool isStandalone;

		private int lineNumber;

		private int linePosition;

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

		public bool IsStandalone
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
			set
			{
			}
		}

		public string Name
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
			set
			{
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
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
			set
			{
			}
		}

		public string SystemId
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
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

		public bool InternalSubsetHasPEReference
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
			set
			{
			}
		}

		public int LinePosition
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
			set
			{
			}
		}

		internal XmlResolver Resolver
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		public XmlResolver XmlResolver
		{
			set
			{
			}
		}

		internal Hashtable ExternalResources
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		public DTDElementDeclarationCollection ElementDecls
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		public DTDAttListDeclarationCollection AttListDecls
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		public DTDEntityDeclarationCollection EntityDecls
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		public DTDParameterEntityDeclarationCollection PEDecls
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		public DTDNotationDeclarationCollection NotationDecls
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		public DTDObjectModel(XmlNameTable nameTable)
		{
		}

		public string ResolveEntity(string name)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public void AddError(XmlException ex)
		{
		}

		internal string GenerateEntityAttributeText(string entityName)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		internal Mono.Xml2.XmlTextReader GenerateEntityContentReader(string entityName, XmlParserContext context)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}
	}
}
