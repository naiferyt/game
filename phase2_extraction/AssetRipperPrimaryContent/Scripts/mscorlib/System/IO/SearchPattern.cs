namespace System.IO
{
	internal class SearchPattern
	{
		private class Op
		{
			public OpCode Code;

			public string Argument;

			public Op Next;
		}

		private enum OpCode
		{
			ExactString = 0,
			AnyChar = 1,
			AnyString = 2,
			End = 3,
			True = 4
		}

		private Op ops;

		private bool ignore;

		internal static readonly char[] WildcardChars;

		internal static readonly char[] InvalidChars;
	}
}
