using System.Collections;

namespace System.Text.RegularExpressions
{
	internal class InterpreterFactory : IMachineFactory
	{
		private IDictionary mapping;

		private ushort[] pattern;

		private string[] namesMapping;

		private int gap;

		public int GroupCount
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		public int Gap
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
			set
			{
			}
		}

		public IDictionary Mapping
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
			set
			{
			}
		}

		public string[] NamesMapping
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
			set
			{
			}
		}

		public InterpreterFactory(ushort[] pattern)
		{
		}

		public IMachine NewInstance()
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}
	}
}
