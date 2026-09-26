using System.Collections;

namespace System.Text.RegularExpressions.Syntax
{
	internal class BackslashNumber : Reference
	{
		private string literal;

		private bool ecma;

		public BackslashNumber(bool ignore, bool ecma)
		{
		}

		public bool ResolveReference(string num_str, Hashtable groups)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public override void Compile(ICompiler cmp, bool reverse)
		{
		}
	}
}
