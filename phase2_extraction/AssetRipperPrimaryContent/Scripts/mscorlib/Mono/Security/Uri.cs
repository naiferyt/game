namespace Mono.Security
{
	internal class Uri
	{
		private struct UriScheme
		{
			public string scheme;

			public string delimiter;

			public int defaultPort;

			public UriScheme(string s, string d, int p)
			{
			}
		}

		private bool isUnixFilePath;

		private string source;

		private string scheme;

		private string host;

		private int port;

		private string path;

		private string query;

		private string fragment;

		private string userinfo;

		private bool isUnc;

		private bool isOpaquePart;

		private string[] segments;

		private bool userEscaped;

		private string cachedAbsoluteUri;

		private string cachedToString;

		private string cachedLocalPath;

		private int cachedHashCode;

		private bool reduce;

		private static readonly string hexUpperChars;

		public static readonly string SchemeDelimiter;

		public static readonly string UriSchemeFile;

		public static readonly string UriSchemeFtp;

		public static readonly string UriSchemeGopher;

		public static readonly string UriSchemeHttp;

		public static readonly string UriSchemeHttps;

		public static readonly string UriSchemeMailto;

		public static readonly string UriSchemeNews;

		public static readonly string UriSchemeNntp;

		private static UriScheme[] schemes;

		public string AbsolutePath
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		public bool IsFile
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		public bool IsUnc
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		public string LocalPath
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		public Uri(string uriString)
		{
		}

		public Uri(string uriString, bool dontEscape)
		{
		}

		public override bool Equals(object comparant)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public override int GetHashCode()
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public string GetLeftPart(UriPartial part)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public static int FromHex(char digit)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public static string HexEscape(char character)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public static char HexUnescape(string pattern, ref int index)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public static bool IsHexDigit(char digit)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public static bool IsHexEncoding(string pattern, int index)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public override string ToString()
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		protected static string EscapeString(string str)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		internal static string EscapeString(string str, bool escapeReserved, bool escapeHex, bool escapeBrackets)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		protected void Parse()
		{
		}

		protected string Unescape(string str)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		internal string Unescape(string str, bool excludeSharp)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		private void ParseAsWindowsUNC(string uriString)
		{
		}

		private void ParseAsWindowsAbsoluteFilePath(string uriString)
		{
		}

		private void ParseAsUnixAbsoluteFilePath(string uriString)
		{
		}

		private void Parse(string uriString)
		{
		}

		private static string Reduce(string path)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		internal static string GetSchemeDelimiter(string scheme)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		internal static int GetDefaultPort(string scheme)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		private string GetOpaqueWiseSchemeDelimiter()
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		private static bool IsPredefinedScheme(string scheme)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}
	}
}
