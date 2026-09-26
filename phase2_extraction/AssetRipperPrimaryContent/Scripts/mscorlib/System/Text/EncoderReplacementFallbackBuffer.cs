namespace System.Text
{
	public sealed class EncoderReplacementFallbackBuffer : EncoderFallbackBuffer
	{
		private string replacement;

		private int current;

		private bool fallback_assigned;

		public override int Remaining
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		public EncoderReplacementFallbackBuffer(EncoderReplacementFallback fallback)
		{
		}

		public override bool Fallback(char charUnknown, int index)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public override bool Fallback(char charUnknownHigh, char charUnknownLow, int index)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		private bool Fallback(int index)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public override char GetNextChar()
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}
	}
}
