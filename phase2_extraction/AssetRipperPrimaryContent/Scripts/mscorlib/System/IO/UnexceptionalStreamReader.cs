using System.Runtime.InteropServices;
using System.Text;

namespace System.IO
{
	internal class UnexceptionalStreamReader : StreamReader
	{
		private static bool[] newline;

		private static char newlineChar;

		public UnexceptionalStreamReader(Stream stream, Encoding encoding)
		{
		}

		static UnexceptionalStreamReader()
		{
		}

		public override int Peek()
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public override int Read()
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public override int Read([In][Out] char[] dest_buffer, int index, int count)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		private bool CheckEOL(char current)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public override string ReadLine()
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public override string ReadToEnd()
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}
	}
}
