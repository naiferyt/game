using System.Collections;

namespace System.Text.RegularExpressions.Syntax
{
	internal class Parser
	{
		private string pattern;

		private int ptr;

		private ArrayList caps;

		private Hashtable refs;

		private int num_groups;

		private int gap;

		public static int ParseDecimal(string str, ref int ptr)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public static int ParseOctal(string str, ref int ptr)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public static int ParseHex(string str, ref int ptr, int digits)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public static int ParseNumber(string str, ref int ptr, int b, int min, int max)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public static string ParseName(string str, ref int ptr)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public RegularExpression ParseRegularExpression(string pattern, RegexOptions options)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public int GetMapping(Hashtable mapping)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		private void ParseGroup(Group group, RegexOptions options, Assertion assertion)
		{
		}

		private Expression ParseGroupingConstruct(ref RegexOptions options)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		private bool ParseAssertionType(ExpressionAssertion assertion)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		private void ParseOptions(ref RegexOptions options, bool negate)
		{
		}

		private Expression ParseCharacterClass(RegexOptions options)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		private bool ParseRepetitionBounds(out int min, out int max, RegexOptions options)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		private Category ParseUnicodeCategory()
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		private Expression ParseSpecial(RegexOptions options)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		private int ParseEscape()
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		private string ParseName()
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		private static bool IsNameChar(char c)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		private int ParseNumber(int b, int min, int max)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		private static int ParseDigit(char c, int b, int n)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		private void ConsumeWhitespace(bool ignore)
		{
		}

		private void ResolveReferences()
		{
		}

		private void HandleExplicitNumericGroups(ArrayList explicit_numeric_groups)
		{
		}

		private static bool IsIgnoreCase(RegexOptions options)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		private static bool IsMultiline(RegexOptions options)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		private static bool IsExplicitCapture(RegexOptions options)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		private static bool IsSingleline(RegexOptions options)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		private static bool IsIgnorePatternWhitespace(RegexOptions options)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		private static bool IsECMAScript(RegexOptions options)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		private ArgumentException NewParseException(string msg)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}
	}
}
