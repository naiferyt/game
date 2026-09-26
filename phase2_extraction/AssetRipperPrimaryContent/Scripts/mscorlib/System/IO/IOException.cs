using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace System.IO
{
	[Serializable]
	[ComVisible(true)]
	public class IOException : SystemException
	{
		public IOException()
		{
		}

		public IOException(string message)
		{
		}

		protected IOException(SerializationInfo info, StreamingContext context)
		{
		}

		public IOException(string message, int hresult)
		{
		}
	}
}
