using System.Text;

namespace System.IO
{
	[Serializable]
	internal class SynchronizedWriter : TextWriter
	{
		private TextWriter writer;

		private bool neverClose;

		public override Encoding Encoding
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		public override string NewLine
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		public SynchronizedWriter(TextWriter writer, bool neverClose)
		{
		}

		public override void Close()
		{
		}

		public override void Flush()
		{
		}

		public override void Write(char value)
		{
		}

		public override void Write(char[] value)
		{
		}

		public override void Write(string value)
		{
		}

		public override void Write(char[] buffer, int index, int count)
		{
		}

		public override void WriteLine()
		{
		}

		public override void WriteLine(string value)
		{
		}
	}
}
