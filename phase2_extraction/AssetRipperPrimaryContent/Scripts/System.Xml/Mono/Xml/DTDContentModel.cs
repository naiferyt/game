namespace Mono.Xml
{
	internal class DTDContentModel : DTDNode
	{
		private DTDObjectModel root;

		private DTDAutomata compiledAutomata;

		private string ownerElementName;

		private string elementName;

		private DTDContentOrderType orderType;

		private DTDContentModelCollection childModels;

		private DTDOccurence occurence;

		public DTDContentModelCollection ChildModels
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		public string ElementName
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
			set
			{
			}
		}

		public DTDOccurence Occurence
		{
			set
			{
			}
		}

		public DTDContentOrderType OrderType
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
			set
			{
			}
		}

		internal DTDContentModel(DTDObjectModel root, string ownerElementName)
		{
		}
	}
}
