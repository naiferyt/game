namespace System.Text.RegularExpressions.Syntax
{
	internal class PositionAssertion : Expression
	{
		private Position pos;

		public PositionAssertion(Position pos)
		{
		}

		public override void Compile(ICompiler cmp, bool reverse)
		{
		}

		public override void GetWidth(out int min, out int max)
		{
		}

		public override bool IsComplex()
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public override AnchorInfo GetAnchorInfo(bool revers)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}
	}
}
