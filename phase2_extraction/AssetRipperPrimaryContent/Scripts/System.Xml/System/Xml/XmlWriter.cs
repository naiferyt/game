namespace System.Xml
{
	public abstract class XmlWriter : IDisposable
	{
		private XmlWriterSettings settings;

		public virtual string XmlLang
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		public virtual XmlSpace XmlSpace
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		void IDisposable.Dispose()
		{
		}

		public abstract void Close();

		protected virtual void Dispose(bool disposing)
		{
		}

		public abstract string LookupPrefix(string ns);

		private void WriteAttribute(XmlReader reader, bool defattr)
		{
		}

		public abstract void WriteCData(string text);

		public abstract void WriteComment(string text);

		public abstract void WriteDocType(string name, string pubid, string sysid, string subset);

		public abstract void WriteEndAttribute();

		public abstract void WriteEndElement();

		public abstract void WriteEntityRef(string name);

		public abstract void WriteFullEndElement();

		public virtual void WriteNode(XmlReader reader, bool defattr)
		{
		}

		public abstract void WriteProcessingInstruction(string name, string text);

		public abstract void WriteStartAttribute(string prefix, string localName, string ns);

		public abstract void WriteStartElement(string prefix, string localName, string ns);

		public abstract void WriteString(string text);

		public abstract void WriteWhitespace(string ws);
	}
}
