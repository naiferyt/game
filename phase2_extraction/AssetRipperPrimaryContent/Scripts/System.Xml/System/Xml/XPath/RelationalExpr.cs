namespace System.Xml.XPath
{
	internal abstract class RelationalExpr : ExprBoolean
	{
		public override bool StaticValueAsBoolean
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		public RelationalExpr(Expression left, Expression right)
		{
		}

		public override bool EvaluateBoolean(BaseIterator iter)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public abstract bool Compare(double arg1, double arg2);

		public bool Compare(double arg1, double arg2, bool fReverse)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}
	}
}
