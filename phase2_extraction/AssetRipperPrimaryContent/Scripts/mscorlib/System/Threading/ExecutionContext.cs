using System.Runtime.Serialization;

namespace System.Threading
{
	[Serializable]
	public sealed class ExecutionContext : ISerializable
	{
		private bool _suppressFlow;

		private bool _capture;

		internal ExecutionContext()
		{
		}

		[MonoTODO]
		internal ExecutionContext(SerializationInfo info, StreamingContext context)
		{
		}

		[MonoTODO]
		public void GetObjectData(SerializationInfo info, StreamingContext context)
		{
		}
	}
}
