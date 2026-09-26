namespace System.Text.RegularExpressions.Syntax
{
	internal class Alternation : CompositeExpression
	{
		public ExpressionCollection Alternatives
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		public void AddAlternative(Expression e)
		{
		}

		public override void Compile(ICompiler cmp, bool reverse)
		{
		}

		public override void GetWidth(out int min, out int max)
		{
		}
	}
}
