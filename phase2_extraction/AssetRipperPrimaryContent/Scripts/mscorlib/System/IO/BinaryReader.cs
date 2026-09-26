using System.Runtime.InteropServices;
using System.Text;

namespace System.IO
{
	[ComVisible(true)]
	public class BinaryReader : IDisposable
	{
		private const int MaxBufferSize = 128;

		private Stream m_stream;

		private Encoding m_encoding;

		private byte[] m_buffer;

		private Decoder decoder;

		private char[] charBuffer;

		private bool m_disposed;

		public BinaryReader(Stream input)
		{
		}

		public BinaryReader(Stream input, Encoding encoding)
		{
		}

		void IDisposable.Dispose()
		{
		}

		protected virtual void Dispose(bool disposing)
		{
		}

		protected virtual void FillBuffer(int numBytes)
		{
		}

		public virtual int Read()
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public virtual int Read(byte[] buffer, int index, int count)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public virtual int Read(char[] buffer, int index, int count)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		private int ReadCharBytes(char[] buffer, int index, int count, out int bytes_read)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		protected int Read7BitEncodedInt()
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public virtual bool ReadBoolean()
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public virtual byte ReadByte()
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public virtual byte[] ReadBytes(int count)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public virtual char ReadChar()
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public virtual decimal ReadDecimal()
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public virtual double ReadDouble()
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public virtual short ReadInt16()
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public virtual int ReadInt32()
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public virtual long ReadInt64()
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		[CLSCompliant(false)]
		public virtual sbyte ReadSByte()
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public virtual string ReadString()
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public virtual float ReadSingle()
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		[CLSCompliant(false)]
		public virtual ushort ReadUInt16()
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		[CLSCompliant(false)]
		public virtual uint ReadUInt32()
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		[CLSCompliant(false)]
		public virtual ulong ReadUInt64()
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		private void CheckBuffer(int length)
		{
		}
	}
}
