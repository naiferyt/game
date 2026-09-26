using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace System.Text
{
	[Serializable]
	public abstract class Encoding : ICloneable
	{
		private sealed class ForwardingDecoder : Decoder
		{
			private Encoding encoding;

			public ForwardingDecoder(Encoding enc)
			{
			}

			public override int GetChars(byte[] bytes, int byteIndex, int byteCount, char[] chars, int charIndex)
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		internal int codePage;

		internal int windows_code_page;

		private bool is_readonly;

		private DecoderFallback decoder_fallback;

		private EncoderFallback encoder_fallback;

		private static Assembly i18nAssembly;

		private static bool i18nDisabled;

		private static EncodingInfo[] encoding_infos;

		private static readonly object[] encodings;

		internal string body_name;

		internal string encoding_name;

		internal string header_name;

		internal bool is_mail_news_display;

		internal bool is_mail_news_save;

		internal bool is_browser_save;

		internal bool is_browser_display;

		internal string web_name;

		private static volatile Encoding asciiEncoding;

		private static volatile Encoding bigEndianEncoding;

		private static volatile Encoding defaultEncoding;

		private static volatile Encoding utf7Encoding;

		private static volatile Encoding utf8EncodingWithMarkers;

		private static volatile Encoding utf8EncodingWithoutMarkers;

		private static volatile Encoding unicodeEncoding;

		private static volatile Encoding isoLatin1Encoding;

		private static volatile Encoding utf8EncodingUnsafe;

		private static volatile Encoding utf32Encoding;

		private static volatile Encoding bigEndianUTF32Encoding;

		private static readonly object lockobj;

		[ComVisible(false)]
		public bool IsReadOnly
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		[ComVisible(false)]
		public DecoderFallback DecoderFallback
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
			set
			{
			}
		}

		[ComVisible(false)]
		public EncoderFallback EncoderFallback
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		public virtual string WebName
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		public static Encoding ASCII
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		public static Encoding BigEndianUnicode
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		public static Encoding Default
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		private static Encoding ISOLatin1
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		public static Encoding UTF8
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		internal static Encoding UTF8Unmarked
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		internal static Encoding UTF8UnmarkedUnsafe
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		public static Encoding Unicode
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		protected Encoding()
		{
		}

		protected Encoding(int codePage)
		{
		}

		internal static string _(string arg)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		internal void SetFallbackInternal(EncoderFallback e, DecoderFallback d)
		{
		}

		public override bool Equals(object value)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public abstract int GetByteCount(char[] chars, int index, int count);

		public virtual int GetByteCount(string s)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public virtual int GetByteCount(char[] chars)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public abstract int GetBytes(char[] chars, int charIndex, int charCount, byte[] bytes, int byteIndex);

		public virtual int GetBytes(string s, int charIndex, int charCount, byte[] bytes, int byteIndex)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public virtual byte[] GetBytes(string s)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public virtual byte[] GetBytes(char[] chars, int index, int count)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public virtual byte[] GetBytes(char[] chars)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public abstract int GetCharCount(byte[] bytes, int index, int count);

		public abstract int GetChars(byte[] bytes, int byteIndex, int byteCount, char[] chars, int charIndex);

		public virtual char[] GetChars(byte[] bytes, int index, int count)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public virtual Decoder GetDecoder()
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		private static object InvokeI18N(string name, params object[] args)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public static Encoding GetEncoding(int codepage)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		[ComVisible(false)]
		public virtual object Clone()
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public static Encoding GetEncoding(string name)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public override int GetHashCode()
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public abstract int GetMaxByteCount(int charCount);

		public abstract int GetMaxCharCount(int byteCount);

		public virtual byte[] GetPreamble()
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public virtual string GetString(byte[] bytes, int index, int count)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public virtual string GetString(byte[] bytes)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		internal static extern string InternalCodePage(ref int code_page);

		[ComVisible(false)]
		[CLSCompliant(false)]
		public unsafe virtual int GetByteCount(char* chars, int count)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		[ComVisible(false)]
		[CLSCompliant(false)]
		public unsafe virtual int GetBytes(char* chars, int charCount, byte* bytes, int byteCount)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}
	}
}
