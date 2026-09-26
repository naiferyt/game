using System.IO;
using System.Runtime.InteropServices;

namespace System.Security.Cryptography
{
	[ComVisible(true)]
	public class CryptoStream : Stream
	{
		private Stream _stream;

		private ICryptoTransform _transform;

		private CryptoStreamMode _mode;

		private byte[] _currentBlock;

		private bool _disposed;

		private bool _flushedFinalBlock;

		private int _partialCount;

		private bool _endOfStream;

		private byte[] _waitingBlock;

		private int _waitingCount;

		private byte[] _transformedBlock;

		private int _transformedPos;

		private int _transformedCount;

		private byte[] _workingBlock;

		private int _workingCount;

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

		public CryptoStream(Stream stream, ICryptoTransform transform, CryptoStreamMode mode)
		{
		}

		~CryptoStream()
		{
		}

		public void Clear()
		{
		}

		public override void Close()
		{
		}

		public override int Read([In][Out] byte[] buffer, int offset, int count)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public override void Write(byte[] buffer, int offset, int count)
		{
		}

		public override void Flush()
		{
		}

		public void FlushFinalBlock()
		{
		}

		public override long Seek(long offset, SeekOrigin origin)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public override void SetLength(long value)
		{
		}

		protected override void Dispose(bool disposing)
		{
		}
	}
}
