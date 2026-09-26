using System;
using System.Collections;
using System.IO;
using System.Xml.XPath;
using System.Xml.Xsl;
using Mono.Xml.XPath.yyParser;
using Mono.Xml.XPath.yydebug;

namespace Mono.Xml.XPath
{
	internal class XPathParser
	{
		private class YYRules : MarshalByRefObject
		{
			public static string[] yyRule;

			public static string getRule(int index)
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		internal IStaticXsltContext Context;

		private static int yacc_verbose_flag;

		public TextWriter ErrorOutput;

		public int eof_token;

		internal yyDebug debug;

		protected static int yyFinal;

		protected static string[] yyNames;

		private int yyExpectingState;

		protected int yyMax;

		private static short[] yyLhs;

		private static short[] yyLen;

		private static short[] yyDefRed;

		protected static short[] yyDgoto;

		protected static short[] yySindex;

		protected static short[] yyRindex;

		protected static short[] yyGindex;

		protected static short[] yyTable;

		protected static short[] yyCheck;

		internal XPathParser(IStaticXsltContext context)
		{
		}

		internal Expression Compile(string xpath)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		private NodeSet CreateNodeTest(Axes axis, object nodeTest, ArrayList plist)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		private NodeTest CreateNodeTest(Axes axis, object test)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public static string yyname(int token)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		protected object yyDefault(object first)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		internal object yyparse(yyInput yyLex)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}
	}
}
