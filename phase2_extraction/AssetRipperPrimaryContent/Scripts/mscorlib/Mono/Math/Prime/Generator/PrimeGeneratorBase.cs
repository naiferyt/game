namespace Mono.Math.Prime.Generator
{
	internal abstract class PrimeGeneratorBase
	{
		public virtual ConfidenceFactor Confidence
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		public virtual PrimalityTest PrimalityTest
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		public virtual int TrialDivisionBounds
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		public abstract BigInteger GenerateNewPrime(int bits);
	}
}
