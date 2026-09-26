using System.Runtime.InteropServices;

namespace System.Text
{
	[Serializable]
	[MonoTODO("Serialization format not compatible with .NET")]
	[MonoTODO("EncoderFallback is not handled")]
	[ComVisible(true)]
	public class UTF8Encoding : Encoding
	{
		[Serializable]
		private class UTF8Decoder : Decoder
		{
			private uint leftOverBits;

			private uint leftOverCount;

			public UTF8Decoder(DecoderFallback fallback)
			{
			}

			public override int GetChars(byte[] bytes, int byteIndex, int byteCount, char[] chars, int charIndex)
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		internal const int UTF8_CODE_PAGE = 65001;

		private bool emitIdentifier;

		public UTF8Encoding()
		{
		}

		public UTF8Encoding(bool encoderShouldEmitUTF8Identifier)
		{
		}

		public UTF8Encoding(bool encoderShouldEmitUTF8Identifier, bool throwOnInvalidBytes)
		{
		}

		private static int InternalGetByteCount(char[] chars, int index, int count, ref char leftOver, bool flush)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		private unsafe static int InternalGetByteCount(char* chars, int count, ref char leftOver, bool flush)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public override int GetByteCount(char[] chars, int index, int count)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		[CLSCompliant(false)]
		[ComVisible(false)]
		public unsafe override int GetByteCount(char* chars, int count)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		private static int InternalGetBytes(char[] chars, int charIndex, int charCount, byte[] bytes, int byteIndex, ref char leftOver, bool flush)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		private unsafe static int InternalGetBytes(char* chars, int count, byte* bytes, int bcount, ref char leftOver, bool flush)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public override int GetBytes(char[] chars, int charIndex, int charCount, byte[] bytes, int byteIndex)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public override int GetBytes(string s, int charIndex, int charCount, byte[] bytes, int byteIndex)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		[ComVisible(false)]
		[CLSCompliant(false)]
		public unsafe override int GetBytes(char* chars, int charCount, byte* bytes, int byteCount)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		private static int InternalGetCharCount(byte[] bytes, int index, int count, uint leftOverBits, uint leftOverCount, object provider, ref DecoderFallbackBuffer fallbackBuffer, ref byte[] bufferArg, bool flush)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		private unsafe static int InternalGetCharCount(byte* bytes, int count, uint leftOverBits, uint leftOverCount, object provider, ref DecoderFallbackBuffer fallbackBuffer, ref byte[] bufferArg, bool flush)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		private unsafe static int Fallback(object provider, ref DecoderFallbackBuffer buffer, ref byte[] bufferArg, byte* bytes, long index, uint size)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		private unsafe static void Fallback(object provider, ref DecoderFallbackBuffer buffer, ref byte[] bufferArg, byte* bytes, long byteIndex, uint size, char* chars, ref int charIndex)
		{
		}

		public override int GetCharCount(byte[] bytes, int index, int count)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		private static int InternalGetChars(byte[] bytes, int byteIndex, int byteCount, char[] chars, int charIndex, ref uint leftOverBits, ref uint leftOverCount, object provider, ref DecoderFallbackBuffer fallbackBuffer, ref byte[] bufferArg, bool flush)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		private unsafe static int InternalGetChars(byte* bytes, int byteCount, char* chars, int charCount, ref uint leftOverBits, ref uint leftOverCount, object provider, ref DecoderFallbackBuffer fallbackBuffer, ref byte[] bufferArg, bool flush)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public override int GetChars(byte[] bytes, int byteIndex, int byteCount, char[] chars, int charIndex)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public override int GetMaxByteCount(int charCount)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public override int GetMaxCharCount(int byteCount)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public override Decoder GetDecoder()
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public override byte[] GetPreamble()
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public override bool Equals(object value)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public override int GetHashCode()
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public override int GetByteCount(string chars)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		[ComVisible(false)]
		public override string GetString(byte[] bytes, int index, int count)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}
	}
}
