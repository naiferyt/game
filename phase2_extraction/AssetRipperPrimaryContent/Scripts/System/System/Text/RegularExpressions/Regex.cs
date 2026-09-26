using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace System.Text.RegularExpressions
{
	[Serializable]
	public class Regex : ISerializable
	{
		private static FactoryCache cache;

		private IMachineFactory machineFactory;

		private IDictionary mapping;

		private int group_count;

		private int gap;

		private bool refsInitialized;

		private string[] group_names;

		private int[] group_numbers;

		protected internal string pattern;

		protected internal RegexOptions roptions;

		[System.MonoTODO]
		internal Dictionary<string, int> capnames;

		[System.MonoTODO]
		internal Dictionary<int, int> caps;

		[System.MonoTODO]
		protected internal int capsize;

		[System.MonoTODO]
		protected internal string[] capslist;

		public RegexOptions Options
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		public bool RightToLeft
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		internal int Gap
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		protected Regex()
		{
		}

		public Regex(string pattern)
		{
		}

		public Regex(string pattern, RegexOptions options)
		{
		}

		protected Regex(SerializationInfo info, StreamingContext context)
		{
		}

		void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
		{
		}

		public static bool IsMatch(string input, string pattern)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public static bool IsMatch(string input, string pattern, RegexOptions options)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		private static void validate_options(RegexOptions options)
		{
		}

		private void Init()
		{
		}

		private void InitNewRegex()
		{
		}

		private static IMachineFactory CreateMachineFactory(string pattern, RegexOptions options)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		private int default_startat(string input)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public bool IsMatch(string input)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public bool IsMatch(string input, int startat)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public Match Match(string input, int startat)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public override string ToString()
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		private IMachine CreateMachine()
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		private static string[] GetGroupNamesArray(int groupCount, IDictionary mapping)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}
	}
}
