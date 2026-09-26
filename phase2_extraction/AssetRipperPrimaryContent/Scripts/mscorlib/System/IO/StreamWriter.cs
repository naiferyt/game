using System.Runtime.InteropServices;
using System.Text;

namespace System.IO
{
	[Serializable]
	[ComVisible(true)]
	public class StreamWriter : TextWriter
	{
		private const int DefaultBufferSize = 1024;

		private const int DefaultFileBufferSize = 4096;

		private const int MinimumBufferSize = 256;

		private Encoding internalEncoding;

		private Stream internalStream;

		private bool iflush;

		private byte[] byte_buf;

		private int byte_pos;

		private char[] decode_buf;

		private int decode_pos;

		private bool DisposedAlready;

		private bool preamble_done;

		public new static readonly StreamWriter Null;

		public virtual bool AutoFlush
		{
			set
			{
			}
		}

		public virtual Stream BaseStream
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		public override Encoding Encoding
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		public StreamWriter(Stream stream)
		{
		}

		public StreamWriter(Stream stream, Encoding encoding)
		{
		}

		public StreamWriter(Stream stream, Encoding encoding, int bufferSize)
		{
		}

		public StreamWriter(string path, bool append, Encoding encoding)
		{
		}

		public StreamWriter(string path, bool append, Encoding encoding, int bufferSize)
		{
		}

		internal void Initialize(Encoding encoding, int bufferSize)
		{
		}

		protected override void Dispose(bool disposing)
		{
		}

		public override void Flush()
		{
		}

		private void FlushBytes()
		{
		}

		private void Decode()
		{
		}

		public override void Write(char[] buffer, int index, int count)
		{
		}

		private void LowLevelWrite(char[] buffer, int index, int count)
		{
		}

		private void LowLevelWrite(string s)
		{
		}

		public override void Write(char value)
		{
		}

		public override void Write(char[] buffer)
		{
		}

		public override void Write(string value)
		{
		}

		public override void Close()
		{
		}

		~StreamWriter()
		{
		}
	}
}
