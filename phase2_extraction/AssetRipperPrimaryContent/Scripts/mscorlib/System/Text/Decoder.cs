using System.Runtime.InteropServices;

namespace System.Text
{
	[Serializable]
	[ComVisible(true)]
	public abstract class Decoder
	{
		private DecoderFallback fallback;

		private DecoderFallbackBuffer fallback_buffer;

		[ComVisible(false)]
		public DecoderFallback Fallback
		{
			set
			{
			}
		}

		[ComVisible(false)]
		public DecoderFallbackBuffer FallbackBuffer
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		public abstract int GetChars(byte[] bytes, int byteIndex, int byteCount, char[] chars, int charIndex);
	}
}
