using System.Runtime.InteropServices;

namespace System.IO
{
	[ComVisible(true)]
	public class FileStream : Stream
	{
		private delegate int ReadDelegate(byte[] buffer, int offset, int count);

		private delegate void WriteDelegate(byte[] buffer, int offset, int count);

		internal const int DefaultBufferSize = 8192;

		private FileAccess access;

		private bool owner;

		private bool async;

		private bool canseek;

		private long append_startpos;

		private bool anonymous;

		private byte[] buf;

		private int buf_size;

		private int buf_length;

		private int buf_offset;

		private bool buf_dirty;

		private long buf_start;

		private string name;

		private IntPtr handle;

		public override bool CanRead
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		public override bool CanWrite
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		public override bool CanSeek
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		public override long Length
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		public override long Position
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
			set
			{
			}
		}

		internal FileStream(IntPtr handle, FileAccess access, bool ownsHandle, int bufferSize, bool isAsync, bool noBuffering)
		{
		}

		public FileStream(string path, FileMode mode)
		{
		}

		public FileStream(string path, FileMode mode, FileAccess access, FileShare share)
		{
		}

		public FileStream(string path, FileMode mode, FileAccess access, FileShare share, int bufferSize)
		{
		}

		internal FileStream(string path, FileMode mode, FileAccess access, FileShare share, int bufferSize, bool anonymous, FileOptions options)
		{
		}

		public override int ReadByte()
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public override void WriteByte(byte value)
		{
		}

		public override int Read([In][Out] byte[] array, int offset, int count)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		private int ReadInternal(byte[] dest, int offset, int count)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public override IAsyncResult BeginRead(byte[] array, int offset, int numBytes, AsyncCallback userCallback, object stateObject)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public override int EndRead(IAsyncResult asyncResult)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public override void Write(byte[] array, int offset, int count)
		{
		}

		private void WriteInternal(byte[] src, int offset, int count)
		{
		}

		public override IAsyncResult BeginWrite(byte[] array, int offset, int numBytes, AsyncCallback userCallback, object stateObject)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public override void EndWrite(IAsyncResult asyncResult)
		{
		}

		public override long Seek(long offset, SeekOrigin origin)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public override void SetLength(long value)
		{
		}

		public override void Flush()
		{
		}

		~FileStream()
		{
		}

		protected override void Dispose(bool disposing)
		{
		}

		private int ReadSegment(byte[] dest, int dest_offset, int count)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		private int WriteSegment(byte[] src, int src_offset, int count)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		private void FlushBuffer(Stream st)
		{
		}

		private void FlushBuffer()
		{
		}

		private void FlushBufferIfDirty()
		{
		}

		private void RefillBuffer()
		{
		}

		private int ReadData(IntPtr handle, byte[] buf, int offset, int count)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		private void InitBuffer(int size, bool noBuffering)
		{
		}

		private string GetSecureFileName(string filename)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		private string GetSecureFileName(string filename, bool full)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}
	}
}
