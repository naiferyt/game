using Mono.Xml;

namespace System.Xml
{
	public class XmlDocumentType : XmlLinkedNode
	{
		internal XmlNamedNodeMap entities;

		internal XmlNamedNodeMap notations;

		private DTDObjectModel dtd;

		internal DTDObjectModel DTD
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		public XmlNamedNodeMap Entities
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		public override bool IsReadOnly
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

		public override XmlNodeType NodeType
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		protected internal XmlDocumentType(string name, string publicId, string systemId, string internalSubset, XmlDocument doc)
		{
		}

		internal XmlDocumentType(DTDObjectModel dtd, XmlDocument doc)
		{
		}

		private void ImportFromDTD()
		{
		}

		public override XmlNode CloneNode(bool deep)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}
	}
}
