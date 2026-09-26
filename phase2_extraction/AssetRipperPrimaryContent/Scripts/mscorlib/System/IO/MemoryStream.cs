using System.Runtime.InteropServices;

namespace System.IO
{
	[Serializable]
	[MonoTODO("Serialization format not compatible with .NET")]
	[ComVisible(true)]
	public class MemoryStream : Stream
	{
		private bool canWrite;

		private bool allowGetBuffer;

		private int capacity;

		private int length;

		private byte[] internalBuffer;

		private int initialIndex;

		private bool expandable;

		private bool streamClosed;

		private int position;

		private int dirty_bytes;

		public override bool CanRead
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

		public override bool CanWrite
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		public virtual int Capacity
		{
			set
			{
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

		public MemoryStream()
		{
		}

		public MemoryStream(int capacity)
		{
		}

		public MemoryStream(byte[] buffer)
		{
		}

		private void InternalConstructor(byte[] buffer, int index, int count, bool writable, bool publicallyVisible)
		{
		}

		private void CheckIfClosedThrowDisposed()
		{
		}

		protected override void Dispose(bool disposing)
		{
		}

		public override void Flush()
		{
		}

		public virtual byte[] GetBuffer()
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public override int Read([In][Out] byte[] buffer, int offset, int count)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public override int ReadByte()
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public override long Seek(long offset, SeekOrigin loc)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		private int CalculateNewCapacity(int minimum)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		private void Expand(int newSize)
		{
		}

		public override void SetLength(long value)
		{
		}

		public virtual byte[] ToArray()
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public override void Write(byte[] buffer, int offset, int count)
		{
		}

		public override void WriteByte(byte value)
		{
		}
	}
}
