namespace System.Xml
{
	public abstract class XmlResolver
	{
		public abstract object GetEntity(Uri absoluteUri, string role, Type type);

		public virtual Uri ResolveUri(Uri baseUri, string relativeUri)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		private string EscapeRelativeUriBody(string src)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}
	}
}
