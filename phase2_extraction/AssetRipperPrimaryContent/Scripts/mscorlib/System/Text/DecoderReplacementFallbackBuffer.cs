namespace System.Text
{
	public sealed class DecoderReplacementFallbackBuffer : DecoderFallbackBuffer
	{
		private bool fallback_assigned;

		private int current;

		private string replacement;

		public override int Remaining
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		public DecoderReplacementFallbackBuffer(DecoderReplacementFallback fallback)
		{
		}

		public override bool Fallback(byte[] bytesUnknown, int index)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public override char GetNextChar()
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public override void Reset()
		{
		}
	}
}
