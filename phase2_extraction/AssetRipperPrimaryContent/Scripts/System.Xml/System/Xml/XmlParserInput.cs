using System.Collections;
using System.IO;
using Mono.Xml;

namespace System.Xml
{
	internal class XmlParserInput
	{
		private class XmlParserInputSource
		{
			public readonly string BaseURI;

			private readonly TextReader reader;

			public int state;

			public bool isPE;

			private int line;

			private int column;

			public int LineNumber
			{
				get
				{
					/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
				}
			}

			public int LinePosition
			{
				get
				{
					/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
				}
			}

			public XmlParserInputSource(TextReader reader, string baseUri, bool pe, int line, int column)
			{
			}

			public void Close()
			{
			}

			public int Read()
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		private Stack sourceStack;

		private XmlParserInputSource source;

		private bool has_peek;

		private int peek_char;

		private bool allowTextDecl;

		public string BaseURI
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		public bool HasPEBuffer
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		public int LineNumber
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		public int LinePosition
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		public bool AllowTextDecl
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
			set
			{
			}
		}

		public XmlParserInput(TextReader reader, string baseURI)
		{
		}

		public XmlParserInput(TextReader reader, string baseURI, int line, int column)
		{
		}

		public void Close()
		{
		}

		public void PushPEBuffer(DTDParameterEntityDeclaration pe)
		{
		}

		private int ReadSourceChar()
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public int PeekChar()
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public int ReadChar()
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}
	}
}
