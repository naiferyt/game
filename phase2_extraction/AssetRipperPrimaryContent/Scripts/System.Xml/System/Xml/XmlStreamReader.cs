using System.IO;
using System.Runtime.InteropServices;

namespace System.Xml
{
	internal class XmlStreamReader : NonBlockingStreamReader
	{
		private XmlInputStream input;

		private static XmlException invalidDataException;

		private XmlStreamReader(XmlInputStream input)
		{
		}

		public XmlStreamReader(Stream input)
		{
		}

		public override void Close()
		{
		}

		public override int Read([In][Out] char[] dest_buffer, int index, int count)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		protected override void Dispose(bool disposing)
		{
		}
	}
}
