using System.Runtime.InteropServices;

namespace System.IO
{
	[Serializable]
	[ComVisible(true)]
	public abstract class Stream : IDisposable
	{
		public static readonly Stream Null;

		public abstract bool CanRead { get; }

		public abstract bool CanSeek { get; }

		public abstract bool CanWrite { get; }

		public abstract long Length { get; }

		public abstract long Position { get; set; }

		public void Dispose()
		{
		}

		protected virtual void Dispose(bool disposing)
		{
		}

		public virtual void Close()
		{
		}

		public abstract void Flush();

		public abstract int Read([In][Out] byte[] buffer, int offset, int count);

		public virtual int ReadByte()
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public abstract long Seek(long offset, SeekOrigin origin);

		public abstract void SetLength(long value);

		public abstract void Write(byte[] buffer, int offset, int count);

		public virtual void WriteByte(byte value)
		{
		}

		public virtual IAsyncResult BeginRead(byte[] buffer, int offset, int count, AsyncCallback callback, object state)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public virtual IAsyncResult BeginWrite(byte[] buffer, int offset, int count, AsyncCallback callback, object state)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public virtual int EndRead(IAsyncResult asyncResult)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public virtual void EndWrite(IAsyncResult asyncResult)
		{
		}
	}
}
