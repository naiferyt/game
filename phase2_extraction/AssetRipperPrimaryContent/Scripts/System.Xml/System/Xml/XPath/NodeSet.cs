namespace System.Xml.XPath
{
	internal abstract class NodeSet : Expression
	{
		public override XPathResultType ReturnType
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		internal abstract bool Subtree { get; }
	}
}
