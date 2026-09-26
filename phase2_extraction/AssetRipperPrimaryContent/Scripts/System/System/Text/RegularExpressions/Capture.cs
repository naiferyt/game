namespace System.Text.RegularExpressions
{
	[Serializable]
	public class Capture
	{
		internal int index;

		internal int length;

		internal string text;

		public string Value
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		internal Capture(string text)
		{
		}

		internal Capture(string text, int index, int length)
		{
		}

		public override string ToString()
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}
	}
}
