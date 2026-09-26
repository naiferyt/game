using System.Runtime.InteropServices;

namespace System.Security.Cryptography
{
	[ComVisible(true)]
	public abstract class AsymmetricAlgorithm : IDisposable
	{
		protected int KeySizeValue;

		protected KeySizes[] LegalKeySizesValue;

		public abstract string KeyExchangeAlgorithm { get; }

		public virtual int KeySize
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
			set
			{
			}
		}

		public virtual KeySizes[] LegalKeySizes
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		public abstract string SignatureAlgorithm { get; }

		void IDisposable.Dispose()
		{
		}

		public void Clear()
		{
		}

		protected abstract void Dispose(bool disposing);

		public abstract void FromXmlString(string xmlString);

		public abstract string ToXmlString(bool includePrivateParameters);

		public static AsymmetricAlgorithm Create()
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public static AsymmetricAlgorithm Create(string algName)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		internal static byte[] GetNamedParam(string xml, string param)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}
	}
}
