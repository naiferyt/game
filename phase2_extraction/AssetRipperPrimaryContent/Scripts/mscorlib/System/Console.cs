using System.IO;

namespace System
{
	public static class Console
	{
		internal static TextWriter stdout;

		private static TextWriter stderr;

		private static TextReader stdin;

		public static TextWriter Error
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		public static TextWriter Out
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		static Console()
		{
		}

		private static Stream Open(IntPtr handle, FileAccess access, int bufferSize)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public static Stream OpenStandardError(int bufferSize)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public static Stream OpenStandardInput(int bufferSize)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public static Stream OpenStandardOutput(int bufferSize)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public static void SetOut(TextWriter newOut)
		{
		}

		public static void WriteLine(string value)
		{
		}
	}
}
