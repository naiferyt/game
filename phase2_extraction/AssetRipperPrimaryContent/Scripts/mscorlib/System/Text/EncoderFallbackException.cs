namespace System.Text
{
	[Serializable]
	public sealed class EncoderFallbackException : ArgumentException
	{
		private const string defaultMessage = "Failed to decode the input byte sequence to Unicode characters.";

		private char char_unknown;

		private char char_unknown_high;

		private char char_unknown_low;

		private int index;

		public EncoderFallbackException()
		{
		}

		public EncoderFallbackException(string message)
		{
		}

		internal EncoderFallbackException(char charUnknown, int index)
		{
		}

		internal EncoderFallbackException(char charUnknownHigh, char charUnknownLow, int index)
		{
		}
	}
}
