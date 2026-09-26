using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace System
{
	[Serializable]
	[ComVisible(true)]
	public class RankException : SystemException
	{
		private const int Result = -2146233065;

		public RankException()
		{
		}

		public RankException(string message)
		{
		}

		protected RankException(SerializationInfo info, StreamingContext context)
		{
		}
	}
}
