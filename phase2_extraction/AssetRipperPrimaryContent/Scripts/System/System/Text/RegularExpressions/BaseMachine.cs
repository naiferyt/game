namespace System.Text.RegularExpressions
{
	internal abstract class BaseMachine : IMachine
	{
		protected bool needs_groups_or_captures;

		public virtual Match Scan(Regex regex, string text, int start, int end)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}
	}
}
