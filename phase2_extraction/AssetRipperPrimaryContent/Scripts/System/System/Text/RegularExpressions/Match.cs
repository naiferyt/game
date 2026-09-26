namespace System.Text.RegularExpressions
{
	[Serializable]
	public class Match : Group
	{
		private Regex regex;

		private IMachine machine;

		private int text_length;

		private GroupCollection groups;

		private static Match empty;

		public static Match Empty
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		public virtual GroupCollection Groups
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		private Match()
		{
		}

		internal Match(Regex regex, IMachine machine, string text, int text_length, int n_groups, int index, int length)
		{
		}

		internal Match(Regex regex, IMachine machine, string text, int text_length, int n_groups, int index, int length, int n_caps)
		{
		}
	}
}
