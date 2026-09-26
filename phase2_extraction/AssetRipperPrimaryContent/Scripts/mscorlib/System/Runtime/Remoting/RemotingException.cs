using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace System.Runtime.Remoting
{
	[Serializable]
	[ComVisible(true)]
	public class RemotingException : SystemException
	{
		public RemotingException()
		{
		}

		public RemotingException(string message)
		{
		}

		protected RemotingException(SerializationInfo info, StreamingContext context)
		{
		}
	}
}
