using System.Globalization;

namespace System.Xml
{
	public class XmlConvert
	{
		private const string encodedColon = "_x003A_";

		private const NumberStyles floatStyle = default(NumberStyles);

		private const NumberStyles integerStyle = default(NumberStyles);

		private static readonly string[] datetimeFormats;

		private static readonly string[] defaultDateTimeFormats;

		private static readonly string[] roundtripDateTimeFormats;

		private static readonly string[] localDateTimeFormats;

		private static readonly string[] utcDateTimeFormats;

		private static readonly string[] unspecifiedDateTimeFormats;

		private static DateTimeStyles _defaultStyle;

		static XmlConvert()
		{
		}

		public static string VerifyName(string name)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}
	}
}
