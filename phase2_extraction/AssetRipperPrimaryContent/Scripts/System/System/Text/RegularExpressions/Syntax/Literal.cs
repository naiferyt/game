namespace System.Text.RegularExpressions.Syntax
{
	internal class Literal : Expression
	{
		private string str;

		private bool ignore;

		public Literal(string str, bool ignore)
		{
		}

		public static void CompileLiteral(string str, ICompiler cmp, bool ignore, bool reverse)
		{
		}

		public override void Compile(ICompiler cmp, bool reverse)
		{
		}

		public override void GetWidth(out int min, out int max)
		{
		}

		public override AnchorInfo GetAnchorInfo(bool reverse)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public override bool IsComplex()
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}
	}
}
