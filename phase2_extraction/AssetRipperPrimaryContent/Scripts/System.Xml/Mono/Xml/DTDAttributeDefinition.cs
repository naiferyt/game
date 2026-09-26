using System.Collections;
using System.Xml.Schema;

namespace Mono.Xml
{
	internal class DTDAttributeDefinition : DTDNode
	{
		private string name;

		private XmlSchemaDatatype datatype;

		private ArrayList enumeratedLiterals;

		private string unresolvedDefault;

		private ArrayList enumeratedNotations;

		private DTDAttributeOccurenceType occurenceType;

		private string resolvedDefaultValue;

		private string resolvedNormalizedDefaultValue;

		public string Name
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		public XmlSchemaDatatype Datatype
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		public string DefaultValue
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		public string UnresolvedDefaultValue
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		internal string ComputeDefaultValue()
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}
	}
}
