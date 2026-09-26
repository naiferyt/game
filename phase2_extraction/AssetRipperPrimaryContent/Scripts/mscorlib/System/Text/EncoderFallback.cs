namespace System.Text
{
	[Serializable]
	public abstract class EncoderFallback
	{
		private static EncoderFallback exception_fallback;

		private static EncoderFallback replacement_fallback;

		private static EncoderFallback standard_safe_fallback;

		public static EncoderFallback ReplacementFallback
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		internal static EncoderFallback StandardSafeFallback
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		public abstract EncoderFallbackBuffer CreateFallbackBuffer();
	}
}
