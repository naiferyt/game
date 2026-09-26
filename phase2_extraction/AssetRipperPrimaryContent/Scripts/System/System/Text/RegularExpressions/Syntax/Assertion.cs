namespace System.Text.RegularExpressions.Syntax
{
	internal abstract class Assertion : CompositeExpression
	{
		public Expression TrueExpression
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
			set
			{
			}
		}

		public Expression FalseExpression
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
			set
			{
			}
		}

		public Assertion()
		{
		}

		public override void GetWidth(out int min, out int max)
		{
		}
	}
}
