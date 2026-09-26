using System.Collections;

namespace Mono.Xml
{
	internal class DTDEntityDeclaration : DTDEntityBase
	{
		private string entityValue;

		private string notationName;

		private ArrayList ReferencingEntities;

		private bool scanned;

		private bool recursed;

		private bool hasExternalReference;

		public string NotationName
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
			set
			{
			}
		}

		public bool HasExternalReference
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		public string EntityValue
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		internal DTDEntityDeclaration(DTDObjectModel root)
		{
		}

		public void ScanEntityValue(ArrayList refs)
		{
		}
	}
}
