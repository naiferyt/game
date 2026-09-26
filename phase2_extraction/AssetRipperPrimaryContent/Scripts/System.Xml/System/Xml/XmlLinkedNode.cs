namespace System.Xml
{
	public abstract class XmlLinkedNode : XmlNode
	{
		private XmlLinkedNode nextSibling;

		internal bool IsRooted
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		public override XmlNode NextSibling
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		internal XmlLinkedNode NextLinkedSibling
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
			set
			{
			}
		}

		public override XmlNode PreviousSibling
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		internal XmlLinkedNode(XmlDocument doc)
		{
		}
	}
}
