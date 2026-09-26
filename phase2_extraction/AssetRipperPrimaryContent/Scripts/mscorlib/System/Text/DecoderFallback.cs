namespace System.Text
{
	[Serializable]
	public abstract class DecoderFallback
	{
		private static DecoderFallback exception_fallback;

		private static DecoderFallback replacement_fallback;

		private static DecoderFallback standard_safe_fallback;

		public static DecoderFallback ExceptionFallback
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		public static DecoderFallback ReplacementFallback
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		internal static DecoderFallback StandardSafeFallback
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		public abstract DecoderFallbackBuffer CreateFallbackBuffer();
	}
}
