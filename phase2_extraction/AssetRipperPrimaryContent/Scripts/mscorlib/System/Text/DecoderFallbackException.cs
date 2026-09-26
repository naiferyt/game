namespace System.Text
{
	[Serializable]
	public sealed class DecoderFallbackException : ArgumentException
	{
		private const string defaultMessage = "Failed to decode the input byte sequence to Unicode characters.";

		private byte[] bytes_unknown;

		private int index;

		public DecoderFallbackException()
		{
		}

		public DecoderFallbackException(string message)
		{
		}

		public DecoderFallbackException(string message, byte[] bytesUnknown, int index)
		{
		}
	}
}
