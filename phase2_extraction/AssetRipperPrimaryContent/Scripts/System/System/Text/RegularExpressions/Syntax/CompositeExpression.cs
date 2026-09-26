namespace System.Text.RegularExpressions.Syntax
{
	internal abstract class CompositeExpression : Expression
	{
		private ExpressionCollection expressions;

		protected ExpressionCollection Expressions
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		public CompositeExpression()
		{
		}

		protected void GetWidth(out int min, out int max, int count)
		{
		}

		public override bool IsComplex()
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}
	}
}
