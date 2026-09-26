using System.Collections;
using System.Text.RegularExpressions;

namespace System
{
	public abstract class UriParser
	{
		private static object lock_object;

		private static Hashtable table;

		internal string scheme_name;

		private int default_port;

		private static readonly Regex uri_regex;

		private static readonly Regex auth_regex;

		internal string SchemeName
		{
			set
			{
			}
		}

		internal int DefaultPort
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
			set
			{
			}
		}

		protected internal virtual void InitializeAndValidate(Uri uri, out UriFormatException parsingError)
		{
		}

		[System.MonoTODO]
		protected virtual void OnRegister(string schemeName, int defaultPort)
		{
		}

		private static void CreateDefaults()
		{
		}

		private static void InternalRegister(Hashtable table, UriParser uriParser, string schemeName, int defaultPort)
		{
		}

		internal static UriParser GetParser(string schemeName)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}
	}
}
