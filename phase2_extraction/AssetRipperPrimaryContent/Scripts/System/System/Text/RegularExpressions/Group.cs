namespace System.Text.RegularExpressions
{
	[Serializable]
	public class Group : Capture
	{
		internal static Group Fail;

		private bool success;

		private CaptureCollection captures;

		public CaptureCollection Captures
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		public bool Success
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		internal Group(string text, int index, int length, int n_caps)
		{
		}

		internal Group(string text, int index, int length)
		{
		}

		internal Group()
		{
		}
	}
}
