using System.IO;
using System.Runtime.InteropServices;
using System.Text;

namespace System.Xml
{
	internal class NonBlockingStreamReader : TextReader
	{
		private const int DefaultBufferSize = 1024;

		private const int DefaultFileBufferSize = 4096;

		private const int MinimumBufferSize = 128;

		private byte[] input_buffer;

		private char[] decoded_buffer;

		private int decoded_count;

		private int pos;

		private int buffer_size;

		private Encoding encoding;

		private Decoder decoder;

		private Stream base_stream;

		private bool mayBlock;

		private StringBuilder line_builder;

		private bool foundCR;

		public Encoding Encoding
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		public NonBlockingStreamReader(Stream stream, Encoding encoding)
		{
		}

		public override void Close()
		{
		}

		protected override void Dispose(bool disposing)
		{
		}

		private int ReadBuffer()
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
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

		private int FindNextEOL()
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
