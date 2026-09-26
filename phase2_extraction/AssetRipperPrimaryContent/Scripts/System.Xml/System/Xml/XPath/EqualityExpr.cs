namespace System.Xml.XPath
{
	internal abstract class EqualityExpr : ExprBoolean
	{
		private bool trueVal;

		public override bool StaticValueAsBoolean
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		public EqualityExpr(Expression left, Expression right, bool trueVal)
		{
		}

		public override bool EvaluateBoolean(BaseIterator iter)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}
	}
}
