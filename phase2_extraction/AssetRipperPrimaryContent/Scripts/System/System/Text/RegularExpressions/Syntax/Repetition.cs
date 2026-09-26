namespace System.Text.RegularExpressions.Syntax
{
	internal class Repetition : CompositeExpression
	{
		private int min;

		private int max;

		private bool lazy;

		public Expression Expression
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
			set
			{
			}
		}

		public int Minimum
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		public Repetition(int min, int max, bool lazy)
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
	}
}
