namespace System.Text.RegularExpressions.Syntax
{
	internal abstract class Expression
	{
		public abstract void Compile(ICompiler cmp, bool reverse);

		public abstract void GetWidth(out int min, out int max);

		public int GetFixedWidth()
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public virtual AnchorInfo GetAnchorInfo(bool reverse)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public abstract bool IsComplex();
	}
}
