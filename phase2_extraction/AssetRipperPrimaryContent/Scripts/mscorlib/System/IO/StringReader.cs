using System.Runtime.InteropServices;

namespace System.IO
{
	[Serializable]
	[ComVisible(true)]
	public class StringReader : TextReader
	{
		private string source;

		private int nextChar;

		private int sourceLength;

		public StringReader(string s)
		{
		}

		public override void Close()
		{
		}

		protected override void Dispose(bool disposing)
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

		public override int Read([In][Out] char[] buffer, int index, int count)
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

		private void CheckObjectDisposedException()
		{
		}
	}
}
