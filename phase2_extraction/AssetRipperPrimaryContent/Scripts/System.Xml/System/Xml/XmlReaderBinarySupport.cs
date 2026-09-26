using System.Text;

namespace System.Xml
{
	internal class XmlReaderBinarySupport
	{
		public delegate int CharGetter(char[] buffer, int offset, int length);

		public enum CommandState
		{
			None = 0,
			ReadElementContentAsBase64 = 1,
			ReadContentAsBase64 = 2,
			ReadElementContentAsBinHex = 3,
			ReadContentAsBinHex = 4
		}

		private XmlReader reader;

		private CharGetter getter;

		private byte[] base64Cache;

		private int base64CacheStartsAt;

		private CommandState state;

		private StringBuilder textCache;

		private bool hasCache;

		private bool dontReset;

		public void Reset()
		{
		}
	}
}
