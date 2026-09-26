using System.Collections;
using System.Reflection;

namespace Mono.Security
{
	[DefaultMember("Item")]
	internal class ASN1
	{
		private byte m_nTag;

		private byte[] m_aValue;

		private ArrayList elist;

		public int Count
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		public byte[] Value
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		public ASN1(byte tag)
		{
		}

		public ASN1(byte tag, byte[] data)
		{
		}

		public ASN1(byte[] data)
		{
		}

		public ASN1 Add(ASN1 asn1)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public virtual byte[] GetBytes()
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		protected void Decode(byte[] asn1, ref int anPos, int anLength)
		{
		}

		protected void DecodeTLV(byte[] asn1, ref int pos, out byte tag, out int length, out byte[] content)
		{
		}

		public override string ToString()
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}
	}
}
