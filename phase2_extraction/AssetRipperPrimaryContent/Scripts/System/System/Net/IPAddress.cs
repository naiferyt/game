using System.Net.Sockets;

namespace System.Net
{
	[Serializable]
	public class IPAddress
	{
		private long m_Address;

		private AddressFamily m_Family;

		private ushort[] m_Numbers;

		private long m_ScopeId;

		public static readonly IPAddress Any;

		public static readonly IPAddress Broadcast;

		public static readonly IPAddress Loopback;

		public static readonly IPAddress None;

		public static readonly IPAddress IPv6Any;

		public static readonly IPAddress IPv6Loopback;

		public static readonly IPAddress IPv6None;

		private int m_HashCode;

		internal long InternalIPv4Address
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		public long ScopeId
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		public AddressFamily AddressFamily
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		public IPAddress(long addr)
		{
		}

		internal IPAddress(ushort[] address, long scopeId)
		{
		}

		private static short SwapShort(short number)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public static short HostToNetworkOrder(short host)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public static short NetworkToHostOrder(short network)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public static IPAddress Parse(string ipString)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public static bool TryParse(string ipString, out IPAddress address)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		private static IPAddress ParseIPV4(string ip)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		private static IPAddress ParseIPV6(string ip)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public override string ToString()
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		private static string ToString(long addr)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public override bool Equals(object other)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public override int GetHashCode()
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		private static int Hash(int i, int j, int k, int l)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}
	}
}
