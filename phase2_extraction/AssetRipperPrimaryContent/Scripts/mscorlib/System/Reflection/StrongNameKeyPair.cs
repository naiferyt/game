using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Security.Cryptography;

namespace System.Reflection
{
	[Serializable]
	[ComVisible(true)]
	public class StrongNameKeyPair : IDeserializationCallback, ISerializable
	{
		private byte[] _publicKey;

		private string _keyPairContainer;

		private bool _keyPairExported;

		private byte[] _keyPairArray;

		[NonSerialized]
		private RSA _rsa;

		protected StrongNameKeyPair(SerializationInfo info, StreamingContext context)
		{
		}

		void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
		{
		}

		void IDeserializationCallback.OnDeserialization(object sender)
		{
		}
	}
}
