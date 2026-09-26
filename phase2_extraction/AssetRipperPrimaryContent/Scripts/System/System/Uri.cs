using System.ComponentModel;
using System.Runtime.Serialization;

namespace System
{
	[Serializable]
	[TypeConverter(typeof(UriTypeConverter))]
	public class Uri : ISerializable
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

		private const int MaxUriLength = 32766;

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

		private bool isAbsoluteUri;

		private string[] segments;

		private bool userEscaped;

		private string cachedAbsoluteUri;

		private string cachedToString;

		private string cachedLocalPath;

		private int cachedHashCode;

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

		public static readonly string UriSchemeNetPipe;

		public static readonly string UriSchemeNetTcp;

		private static UriScheme[] schemes;

		[NonSerialized]
		private UriParser parser;

		public string AbsolutePath
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		public string AbsoluteUri
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

		public string Scheme
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		public bool IsAbsoluteUri
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		private UriParser Parser
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		public Uri(string uriString)
		{
		}

		protected Uri(SerializationInfo serializationInfo, StreamingContext streamingContext)
		{
		}

		public Uri(string uriString, UriKind uriKind)
		{
		}

		[Obsolete]
		public Uri(string uriString, bool dontEscape)
		{
		}

		public Uri(Uri baseUri, string relativeUri)
		{
		}

		void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
		{
		}

		private void Merge(Uri baseUri, string relativeUri)
		{
		}

		public static UriHostNameType CheckHostName(string name)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		internal static bool IsIPv4Address(string name)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		internal static bool IsDomainAddress(string name)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public static bool CheckSchemeName(string schemeName)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		private static bool IsAlpha(char c)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public override bool Equals(object comparant)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		private bool InternalEquals(Uri uri)
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

		public static bool IsHexDigit(char digit)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public static bool IsHexEncoding(string pattern, int index)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		private void AppendQueryAndFragment(ref string result)
		{
		}

		public override string ToString()
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		[Obsolete]
		protected static string EscapeString(string str)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		internal static string EscapeString(string str, bool escapeReserved, bool escapeHex, bool escapeBrackets)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		private void ParseUri(UriKind kind)
		{
		}

		[Obsolete]
		protected virtual string Unescape(string str)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		internal static string Unescape(string str, bool excludeSpecial)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		private void ParseAsWindowsUNC(string uriString)
		{
		}

		private string ParseAsWindowsAbsoluteFilePath(string uriString)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		private void ParseAsUnixAbsoluteFilePath(string uriString)
		{
		}

		private void Parse(UriKind kind, string uriString)
		{
		}

		private string ParseNoExceptions(UriKind kind, string uriString)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		private static bool CompactEscaped(string scheme)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		private static string Reduce(string path, bool compact_escaped)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		private static char HexUnescapeMultiByte(string pattern, ref int index, out char surrogate)
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

		private void EnsureAbsoluteUri()
		{
		}

		public static bool operator ==(Uri u1, Uri u2)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public static bool operator !=(Uri u1, Uri u2)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}
	}
}
