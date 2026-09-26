namespace System.Text.RegularExpressions.Syntax
{
	internal class NonBacktrackingGroup : Group
	{
		public override void Compile(ICompiler cmp, bool reverse)
		{
		}

		public override bool IsComplex()
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}
	}
}
