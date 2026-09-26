using System.Collections;
using System.Collections.Generic;
using System.Text;

public class MiniJSON
{
	private const int TOKEN_NONE = 0;

	private const int TOKEN_CURLY_OPEN = 1;

	private const int TOKEN_CURLY_CLOSE = 2;

	private const int TOKEN_SQUARED_OPEN = 3;

	private const int TOKEN_SQUARED_CLOSE = 4;

	private const int TOKEN_COLON = 5;

	private const int TOKEN_COMMA = 6;

	private const int TOKEN_STRING = 7;

	private const int TOKEN_NUMBER = 8;

	private const int TOKEN_TRUE = 9;

	private const int TOKEN_FALSE = 10;

	private const int TOKEN_NULL = 11;

	private const int BUILDER_CAPACITY = 2000;

	protected static int lastErrorIndex;

	protected static string lastDecode;

	public static object jsonDecode(string json)
	{
		RecoveryPending.Hit("MiniJSON.jsonDecode");
		return default(object);
	}

	public static string jsonEncode(object json)
	{
		RecoveryPending.Hit("MiniJSON.jsonEncode");
		return default(string);
	}

	public static bool lastDecodeSuccessful()
	{
		RecoveryPending.Hit("MiniJSON.lastDecodeSuccessful");
		return default(bool);
	}

	public static int getLastErrorIndex()
	{
		RecoveryPending.Hit("MiniJSON.getLastErrorIndex");
		return default(int);
	}

	public static string getLastErrorSnippet()
	{
		RecoveryPending.Hit("MiniJSON.getLastErrorSnippet");
		return default(string);
	}

	protected static Hashtable parseObject(char[] json, ref int index)
	{
		RecoveryPending.Hit("MiniJSON.parseObject");
		return default(Hashtable);
	}

	protected static ArrayList parseArray(char[] json, ref int index)
	{
		RecoveryPending.Hit("MiniJSON.parseArray");
		return default(ArrayList);
	}

	protected static object parseValue(char[] json, ref int index, ref bool success)
	{
		RecoveryPending.Hit("MiniJSON.parseValue");
		return default(object);
	}

	protected static string parseString(char[] json, ref int index)
	{
		RecoveryPending.Hit("MiniJSON.parseString");
		return default(string);
	}

	protected static double parseNumber(char[] json, ref int index)
	{
		RecoveryPending.Hit("MiniJSON.parseNumber");
		return default(double);
	}

	protected static int getLastIndexOfNumber(char[] json, int index)
	{
		RecoveryPending.Hit("MiniJSON.getLastIndexOfNumber");
		return default(int);
	}

	protected static void eatWhitespace(char[] json, ref int index)
	{
		RecoveryPending.Hit("MiniJSON.eatWhitespace");
	}

	protected static int lookAhead(char[] json, int index)
	{
		RecoveryPending.Hit("MiniJSON.lookAhead");
		return default(int);
	}

	protected static int nextToken(char[] json, ref int index)
	{
		RecoveryPending.Hit("MiniJSON.nextToken");
		return default(int);
	}

	protected static bool serializeObjectOrArray(object objectOrArray, StringBuilder builder)
	{
		RecoveryPending.Hit("MiniJSON.serializeObjectOrArray");
		return default(bool);
	}

	protected static bool serializeObject(Hashtable anObject, StringBuilder builder)
	{
		RecoveryPending.Hit("MiniJSON.serializeObject");
		return default(bool);
	}

	protected static bool serializeDictionary(Dictionary<string, string> dict, StringBuilder builder)
	{
		RecoveryPending.Hit("MiniJSON.serializeDictionary");
		return default(bool);
	}

	protected static bool serializeArray(ArrayList anArray, StringBuilder builder)
	{
		RecoveryPending.Hit("MiniJSON.serializeArray");
		return default(bool);
	}

	protected static bool serializeValue(object value, StringBuilder builder)
	{
		RecoveryPending.Hit("MiniJSON.serializeValue");
		return default(bool);
	}

	protected static void serializeString(string aString, StringBuilder builder)
	{
		RecoveryPending.Hit("MiniJSON.serializeString");
	}

	protected static void serializeNumber(double number, StringBuilder builder)
	{
		RecoveryPending.Hit("MiniJSON.serializeNumber");
	}
}
