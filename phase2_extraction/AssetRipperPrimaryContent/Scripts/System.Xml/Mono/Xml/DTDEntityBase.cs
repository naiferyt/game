using System;
using System.Xml;

namespace Mono.Xml
{
	internal class DTDEntityBase : DTDNode
	{
		private string name;

		private string publicId;

		private string systemId;

		private string literalValue;

		private string replacementText;

		private string uriString;

		private Uri absUri;

		private bool isInvalid;

		private bool loadFailed;

		private XmlResolver resolver;

		internal bool IsInvalid
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		public bool LoadFailed
		{
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

		public string LiteralEntityValue
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
			set
			{
			}
		}

		public string ReplacementText
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

		public string ActualUri
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		protected DTDEntityBase(DTDObjectModel root)
		{
		}

		public void Resolve()
		{
		}
	}
}
