namespace System.Xml.XPath
{
	internal abstract class ExprBinary : Expression
	{
		protected Expression _left;

		protected Expression _right;

		public override bool HasStaticValue
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		protected abstract string Operator { get; }

		internal override bool Peer
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		public ExprBinary(Expression left, Expression right)
		{
		}

		public override Expression Optimize()
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public override string ToString()
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}
	}
}
