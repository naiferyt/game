namespace System.Text.RegularExpressions.Syntax
{
	internal class CaptureAssertion : Assertion
	{
		private ExpressionAssertion alternate;

		private CapturingGroup group;

		private Literal literal;

		public CapturingGroup CapturingGroup
		{
			set
			{
			}
		}

		private ExpressionAssertion Alternate
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		public CaptureAssertion(Literal l)
		{
		}

		public override void Compile(ICompiler cmp, bool reverse)
		{
		}

		public override bool IsComplex()
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}
	}
}
