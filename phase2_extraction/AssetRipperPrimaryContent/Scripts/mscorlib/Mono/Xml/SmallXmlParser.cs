using System;
using System.Collections;
using System.IO;
using System.Text;

namespace Mono.Xml
{
	internal class SmallXmlParser
	{
		private class AttrListImpl : IAttrList
		{
			private ArrayList attrNames;

			private ArrayList attrValues;

			public string[] Names
			{
				get
				{
					/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
				}
			}

			public string[] Values
			{
				get
				{
					/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
				}
			}

			internal void Clear()
			{
			}

			internal void Add(string name, string value)
			{
			}
		}

		public interface IAttrList
		{
			string[] Names { get; }

			string[] Values { get; }
		}

		public interface IContentHandler
		{
			void OnStartParsing(SmallXmlParser parser);

			void OnEndParsing(SmallXmlParser parser);

			void OnStartElement(string name, IAttrList attrs);

			void OnEndElement(string name);

			void OnProcessingInstruction(string name, string text);

			void OnChars(string text);

			void OnIgnorableWhitespace(string text);
		}

		private IContentHandler handler;

		private TextReader reader;

		private Stack elementNames;

		private Stack xmlSpaces;

		private string xmlSpace;

		private StringBuilder buffer;

		private char[] nameBuffer;

		private bool isWhitespace;

		private AttrListImpl attributes;

		private int line;

		private int column;

		private bool resetColumn;

		private Exception Error(string msg)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		private Exception UnexpectedEndError()
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		private bool IsNameChar(char c, bool start)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		private bool IsWhitespace(int c)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public void SkipWhitespaces()
		{
		}

		private void HandleWhitespaces()
		{
		}

		public void SkipWhitespaces(bool expected)
		{
		}

		private int Peek()
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		private int Read()
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public void Expect(int c)
		{
		}

		private string ReadUntil(char until, bool handleReferences)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public string ReadName()
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public void Parse(TextReader input, IContentHandler handler)
		{
		}

		private void Cleanup()
		{
		}

		public void ReadContent()
		{
		}

		private void HandleBufferedContent()
		{
		}

		private void ReadCharacters()
		{
		}

		private void ReadReference()
		{
		}

		private int ReadCharacterReference()
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		private void ReadAttribute(AttrListImpl a)
		{
		}

		private void ReadCDATASection()
		{
		}

		private void ReadComment()
		{
		}
	}
}
