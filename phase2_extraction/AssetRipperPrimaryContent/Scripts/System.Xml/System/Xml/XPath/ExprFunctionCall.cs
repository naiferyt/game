using System.Collections;
using System.Xml.Xsl;

namespace System.Xml.XPath
{
	internal class ExprFunctionCall : Expression
	{
		protected readonly XmlQualifiedName _name;

		protected readonly bool resolvedName;

		protected readonly ArrayList _args;

		public override XPathResultType ReturnType
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		internal override bool Peer
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		public ExprFunctionCall(XmlQualifiedName name, FunctionArguments args, IStaticXsltContext ctx)
		{
		}

		public static Expression Factory(XmlQualifiedName name, FunctionArguments args, IStaticXsltContext ctx)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public override string ToString()
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public override XPathResultType GetReturnType(BaseIterator iter)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		private XPathResultType[] GetArgTypes(BaseIterator iter)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public override object Evaluate(BaseIterator iter)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}
	}
}
