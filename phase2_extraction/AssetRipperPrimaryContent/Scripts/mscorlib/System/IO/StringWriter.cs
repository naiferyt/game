using System.Runtime.InteropServices;
using System.Text;

namespace System.IO
{
	[Serializable]
	[ComVisible(true)]
	[MonoTODO("Serialization format not compatible with .NET")]
	public class StringWriter : TextWriter
	{
		private StringBuilder internalString;

		private bool disposed;

		public override Encoding Encoding
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		public StringWriter()
		{
		}

		public StringWriter(StringBuilder sb)
		{
		}

		public StringWriter(StringBuilder sb, IFormatProvider formatProvider)
		{
		}

		public override void Close()
		{
		}

		protected override void Dispose(bool disposing)
		{
		}

		public virtual StringBuilder GetStringBuilder()
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public override string ToString()
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public override void Write(char value)
		{
		}

		public override void Write(string value)
		{
		}

		public override void Write(char[] buffer, int index, int count)
		{
		}
	}
}
