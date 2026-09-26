using System.Runtime.InteropServices;
using System.Text;

namespace System.IO
{
	[Serializable]
	[ComVisible(true)]
	public abstract class TextWriter : IDisposable
	{
		private sealed class NullTextWriter : TextWriter
		{
			public override Encoding Encoding
			{
				get
				{
					/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
				}
			}

			public override void Write(string s)
			{
			}

			public override void Write(char value)
			{
			}

			public override void Write(char[] value, int index, int count)
			{
			}
		}

		protected char[] CoreNewLine;

		internal IFormatProvider internalFormatProvider;

		public static readonly TextWriter Null;

		public abstract Encoding Encoding { get; }

		public virtual string NewLine
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		public virtual void Close()
		{
		}

		protected virtual void Dispose(bool disposing)
		{
		}

		public void Dispose()
		{
		}

		public virtual void Flush()
		{
		}

		internal static TextWriter Synchronized(TextWriter writer, bool neverClose)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public virtual void Write(char value)
		{
		}

		public virtual void Write(char[] buffer)
		{
		}

		public virtual void Write(string value)
		{
		}

		public virtual void Write(char[] buffer, int index, int count)
		{
		}

		public virtual void WriteLine()
		{
		}

		public virtual void WriteLine(string value)
		{
		}
	}
}
