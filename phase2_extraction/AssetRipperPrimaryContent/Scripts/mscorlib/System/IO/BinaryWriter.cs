using System.Runtime.InteropServices;
using System.Text;

namespace System.IO
{
	[Serializable]
	[ComVisible(true)]
	public class BinaryWriter : IDisposable
	{
		public static readonly BinaryWriter Null;

		protected Stream OutStream;

		private Encoding m_encoding;

		private byte[] buffer;

		private bool disposed;

		private byte[] stringBuffer;

		private int maxCharsPerRound;

		protected BinaryWriter()
		{
		}

		public BinaryWriter(Stream output)
		{
		}

		public BinaryWriter(Stream output, Encoding encoding)
		{
		}

		void IDisposable.Dispose()
		{
		}

		protected virtual void Dispose(bool disposing)
		{
		}

		public virtual void Flush()
		{
		}

		public virtual void Write(bool value)
		{
		}

		public virtual void Write(byte value)
		{
		}

		public virtual void Write(byte[] buffer)
		{
		}

		public virtual void Write(byte[] buffer, int index, int count)
		{
		}

		public virtual void Write(char ch)
		{
		}

		public virtual void Write(char[] chars)
		{
		}

		public virtual void Write(decimal value)
		{
		}

		public virtual void Write(double value)
		{
		}

		public virtual void Write(short value)
		{
		}

		public virtual void Write(int value)
		{
		}

		public virtual void Write(long value)
		{
		}

		[CLSCompliant(false)]
		public virtual void Write(sbyte value)
		{
		}

		public virtual void Write(float value)
		{
		}

		public virtual void Write(string value)
		{
		}

		[CLSCompliant(false)]
		public virtual void Write(ushort value)
		{
		}

		[CLSCompliant(false)]
		public virtual void Write(uint value)
		{
		}

		[CLSCompliant(false)]
		public virtual void Write(ulong value)
		{
		}

		protected void Write7BitEncodedInt(int value)
		{
		}
	}
}
