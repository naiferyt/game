using System;
using System.Security.Cryptography;

namespace Mono.Security.Cryptography
{
	internal abstract class SymmetricTransform : IDisposable, ICryptoTransform
	{
		protected SymmetricAlgorithm algo;

		protected bool encrypt;

		private int BlockSizeByte;

		private byte[] temp;

		private byte[] temp2;

		private byte[] workBuff;

		private byte[] workout;

		private int FeedBackByte;

		private int FeedBackIter;

		private bool m_disposed;

		private bool lastBlock;

		private RandomNumberGenerator _rng;

		public virtual bool CanTransformMultipleBlocks
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

		public virtual int InputBlockSize
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		public virtual int OutputBlockSize
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		private bool KeepLastBlock
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		public SymmetricTransform(SymmetricAlgorithm symmAlgo, bool encryption, byte[] rgbIV)
		{
		}

		void IDisposable.Dispose()
		{
		}

		~SymmetricTransform()
		{
		}

		protected virtual void Dispose(bool disposing)
		{
		}

		protected virtual void Transform(byte[] input, byte[] output)
		{
		}

		protected abstract void ECB(byte[] input, byte[] output);

		protected virtual void CBC(byte[] input, byte[] output)
		{
		}

		protected virtual void CFB(byte[] input, byte[] output)
		{
		}

		protected virtual void OFB(byte[] input, byte[] output)
		{
		}

		protected virtual void CTS(byte[] input, byte[] output)
		{
		}

		private void CheckInput(byte[] inputBuffer, int inputOffset, int inputCount)
		{
		}

		public virtual int TransformBlock(byte[] inputBuffer, int inputOffset, int inputCount, byte[] outputBuffer, int outputOffset)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		private int InternalTransformBlock(byte[] inputBuffer, int inputOffset, int inputCount, byte[] outputBuffer, int outputOffset)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		private void Random(byte[] buffer, int start, int length)
		{
		}

		private void ThrowBadPaddingException(PaddingMode padding, int length, int position)
		{
		}

		private byte[] FinalEncrypt(byte[] inputBuffer, int inputOffset, int inputCount)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		private byte[] FinalDecrypt(byte[] inputBuffer, int inputOffset, int inputCount)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public virtual byte[] TransformFinalBlock(byte[] inputBuffer, int inputOffset, int inputCount)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}
	}
}
