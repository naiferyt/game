using System.Globalization;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace System.Collections
{
	[Serializable]
	[ComVisible(true)]
	public sealed class Comparer : IComparer, ISerializable
	{
		public static readonly Comparer Default;

		public static readonly Comparer DefaultInvariant;

		private CompareInfo m_compareInfo;

		private Comparer()
		{
		}

		public Comparer(CultureInfo culture)
		{
		}

		public int Compare(object a, object b)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public void GetObjectData(SerializationInfo info, StreamingContext context)
		{
		}
	}
}
