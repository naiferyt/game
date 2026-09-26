using System.Runtime.InteropServices;

namespace System.Security.Cryptography
{
	[ComVisible(true)]
	public class FromBase64Transform : IDisposable, ICryptoTransform
	{
		private const byte TerminatorByte = 61;

		private FromBase64TransformMode mode;

		private byte[] accumulator;

		private int accPtr;

		private bool m_disposed;

		private byte[] lookupTable;

		public bool CanTransformMultipleBlocks
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		public virtual bool CanReuseTransform
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		public int InputBlockSize
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		public int OutputBlockSize
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		public FromBase64Transform()
		{
		}

		public FromBase64Transform(FromBase64TransformMode whitespaces)
		{
		}

		void IDisposable.Dispose()
		{
		}

		~FromBase64Transform()
		{
		}

		public void Clear()
		{
		}

		protected virtual void Dispose(bool disposing)
		{
		}

		private byte lookup(byte input)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		private int ProcessBlock(byte[] output, int offset)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		private void CheckInputParameters(byte[] inputBuffer, int inputOffset, int inputCount)
		{
		}

		public int TransformBlock(byte[] inputBuffer, int inputOffset, int inputCount, byte[] outputBuffer, int outputOffset)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public byte[] TransformFinalBlock(byte[] inputBuffer, int inputOffset, int inputCount)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}
	}
}
