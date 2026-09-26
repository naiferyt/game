using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

// JSON reader/writer on Hashtable/ArrayList (the widely used "MiniJSON" of the time, with a Dictionary<string,string>
// serializer added by the original team). Used for the language file and other text data.
// Source listing: recovery/aot_listings/Assembly-CSharp-firstpass/MiniJSON.txt
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

	// RECUPERADO-AOT MiniJSON..cctor token 0x06000320 @0x000344f0 (static initializers)
	protected static int lastErrorIndex = -1;

	protected static string lastDecode = string.Empty;

	// RECUPERADO-AOT MiniJSON.jsonDecode token 0x06000321 @0x00034554
	public static object jsonDecode(string json)
	{
		lastDecode = json;
		if (json == null)
		{
			return null;
		}
		char[] chars = json.ToCharArray();
		int index = 0;
		bool success = true;
		object value = parseValue(chars, ref index, ref success);
		if (success)
		{
			lastErrorIndex = -1;
		}
		else
		{
			lastErrorIndex = index;
		}
		return value;
	}

	// RECUPERADO-AOT MiniJSON.jsonEncode token 0x06000322 @0x0003462c
	public static string jsonEncode(object json)
	{
		StringBuilder builder = new StringBuilder(BUILDER_CAPACITY);
		return serializeValue(json, builder) ? builder.ToString() : null;
	}

	// RECUPERADO-AOT MiniJSON.lastDecodeSuccessful token 0x06000323 @0x000346b0
	public static bool lastDecodeSuccessful()
	{
		return lastErrorIndex == -1;
	}

	// RECUPERADO-AOT MiniJSON.getLastErrorIndex token 0x06000324 @0x000346f8
	public static int getLastErrorIndex()
	{
		return lastErrorIndex;
	}

	// RECUPERADO-AOT MiniJSON.getLastErrorSnippet token 0x06000325 @0x00034730
	public static string getLastErrorSnippet()
	{
		if (lastErrorIndex == -1)
		{
			return string.Empty;
		}
		int start = lastErrorIndex - 5;
		int end = lastErrorIndex + 15;
		if (start < 0)
		{
			start = 0;
		}
		if (end >= lastDecode.Length)
		{
			end = lastDecode.Length - 1;
		}
		return lastDecode.Substring(start, end - start + 1);
	}

	// RECUPERADO-AOT MiniJSON.parseObject token 0x06000326 @0x00034830
	protected static Hashtable parseObject(char[] json, ref int index)
	{
		Hashtable table = new Hashtable();
		nextToken(json, ref index);
		bool done = false;
		while (!done)
		{
			int token = lookAhead(json, index);
			if (token == TOKEN_NONE)
			{
				return null;
			}
			if (token == TOKEN_COMMA)
			{
				nextToken(json, ref index);
				continue;
			}
			if (token == TOKEN_CURLY_CLOSE)
			{
				nextToken(json, ref index);
				return table;
			}
			string name = parseString(json, ref index);
			if (name == null)
			{
				return null;
			}
			token = nextToken(json, ref index);
			if (token != TOKEN_COLON)
			{
				return null;
			}
			bool success = true;
			object value = parseValue(json, ref index, ref success);
			if (!success)
			{
				return null;
			}
			table[name] = value;
		}
		return table;
	}

	// RECUPERADO-AOT MiniJSON.parseArray token 0x06000327 @0x00034994
	protected static ArrayList parseArray(char[] json, ref int index)
	{
		ArrayList array = new ArrayList();
		nextToken(json, ref index);
		bool done = false;
		while (!done)
		{
			int token = lookAhead(json, index);
			if (token == TOKEN_NONE)
			{
				return null;
			}
			if (token == TOKEN_COMMA)
			{
				nextToken(json, ref index);
				continue;
			}
			if (token == TOKEN_SQUARED_CLOSE)
			{
				nextToken(json, ref index);
				break;
			}
			bool success = true;
			object value = parseValue(json, ref index, ref success);
			if (!success)
			{
				return null;
			}
			array.Add(value);
		}
		return array;
	}

	// RECUPERADO-AOT MiniJSON.parseValue token 0x06000328 @0x00034abc
	protected static object parseValue(char[] json, ref int index, ref bool success)
	{
		switch (lookAhead(json, index))
		{
		case TOKEN_STRING:
			return parseString(json, ref index);
		case TOKEN_NUMBER:
			return parseNumber(json, ref index);
		case TOKEN_CURLY_OPEN:
			return parseObject(json, ref index);
		case TOKEN_SQUARED_OPEN:
			return parseArray(json, ref index);
		case TOKEN_TRUE:
			nextToken(json, ref index);
			return bool.Parse("TRUE");
		case TOKEN_FALSE:
			nextToken(json, ref index);
			return bool.Parse("FALSE");
		case TOKEN_NULL:
			nextToken(json, ref index);
			return null;
		}
		success = false;
		return null;
	}

	// RECUPERADO-AOT MiniJSON.parseString token 0x06000329 @0x00034c38
	protected static string parseString(char[] json, ref int index)
	{
		string s = string.Empty;
		eatWhitespace(json, ref index);
		char c = json[index++];
		bool complete = false;
		while (!complete)
		{
			if (index == json.Length)
			{
				break;
			}
			c = json[index++];
			if (c == '"')
			{
				complete = true;
				break;
			}
			if (c == '\\')
			{
				if (index == json.Length)
				{
					break;
				}
				c = json[index++];
				if (c == '"')
				{
					s += '"';
				}
				else if (c == '\\')
				{
					s += '\\';
				}
				else if (c == '/')
				{
					s += '/';
				}
				else if (c == 'b')
				{
					s += '\b';
				}
				else if (c == 'f')
				{
					s += '\f';
				}
				else if (c == 'n')
				{
					s += '\n';
				}
				else if (c == 'r')
				{
					s += '\r';
				}
				else if (c == 't')
				{
					s += '\t';
				}
				else if (c == 'u')
				{
					int remainingLength = json.Length - index;
					if (remainingLength < 4)
					{
						break;
					}
					char[] unicodeCharArray = new char[4];
					Array.Copy(json, index, unicodeCharArray, 0, 4);
					// (the original emits an HTML-style entity instead of decoding the code point)
					s = s + "&#x" + new string(unicodeCharArray) + ";";
					index += 4;
				}
			}
			else
			{
				s += c;
			}
		}
		if (!complete)
		{
			return null;
		}
		return s;
	}

	// RECUPERADO-AOT MiniJSON.parseNumber token 0x0600032a @0x0003507c
	protected static double parseNumber(char[] json, ref int index)
	{
		eatWhitespace(json, ref index);
		int lastIndex = getLastIndexOfNumber(json, index);
		int charLength = lastIndex - index + 1;
		char[] numberCharArray = new char[charLength];
		Array.Copy(json, index, numberCharArray, 0, charLength);
		index = lastIndex + 1;
		// ADAPTADO-U6: Double.Parse(string) used the device culture (always '.' decimals on the original iOS
		// builds); invariant culture keeps "1.5" meaning 1.5 on PCs with a ',' decimal locale.
		return double.Parse(new string(numberCharArray), CultureInfo.InvariantCulture);
	}

	// RECUPERADO-AOT MiniJSON.getLastIndexOfNumber token 0x0600032b @0x00035134
	protected static int getLastIndexOfNumber(char[] json, int index)
	{
		int lastIndex;
		for (lastIndex = index; lastIndex < json.Length; lastIndex++)
		{
			if ("0123456789+-.eE".IndexOf(json[lastIndex]) == -1)
			{
				break;
			}
		}
		return lastIndex - 1;
	}

	// RECUPERADO-AOT MiniJSON.eatWhitespace token 0x0600032c @0x000351cc
	protected static void eatWhitespace(char[] json, ref int index)
	{
		for (; index < json.Length; index++)
		{
			if (" \t\n\r".IndexOf(json[index]) == -1)
			{
				break;
			}
		}
	}

	// RECUPERADO-AOT MiniJSON.lookAhead token 0x0600032d @0x00035270
	protected static int lookAhead(char[] json, int index)
	{
		int saveIndex = index;
		return nextToken(json, ref saveIndex);
	}

	// RECUPERADO-AOT MiniJSON.nextToken token 0x0600032e @0x000352bc
	protected static int nextToken(char[] json, ref int index)
	{
		eatWhitespace(json, ref index);
		if (index == json.Length)
		{
			return TOKEN_NONE;
		}
		char c = json[index];
		index++;
		switch (c)
		{
		case '{':
			return TOKEN_CURLY_OPEN;
		case '}':
			return TOKEN_CURLY_CLOSE;
		case '[':
			return TOKEN_SQUARED_OPEN;
		case ']':
			return TOKEN_SQUARED_CLOSE;
		case ',':
			return TOKEN_COMMA;
		case '"':
			return TOKEN_STRING;
		case '-':
		case '0':
		case '1':
		case '2':
		case '3':
		case '4':
		case '5':
		case '6':
		case '7':
		case '8':
		case '9':
			return TOKEN_NUMBER;
		case ':':
			return TOKEN_COLON;
		}
		index--;
		int remainingLength = json.Length - index;
		if (remainingLength >= 5 && json[index] == 'f' && json[index + 1] == 'a' && json[index + 2] == 'l' && json[index + 3] == 's' && json[index + 4] == 'e')
		{
			index += 5;
			return TOKEN_FALSE;
		}
		if (remainingLength >= 4 && json[index] == 't' && json[index + 1] == 'r' && json[index + 2] == 'u' && json[index + 3] == 'e')
		{
			index += 4;
			return TOKEN_TRUE;
		}
		if (remainingLength >= 4 && json[index] == 'n' && json[index + 1] == 'u' && json[index + 2] == 'l' && json[index + 3] == 'l')
		{
			index += 4;
			return TOKEN_NULL;
		}
		return TOKEN_NONE;
	}

	// RECUPERADO-AOT MiniJSON.serializeObjectOrArray token 0x0600032f @0x000356d4
	protected static bool serializeObjectOrArray(object objectOrArray, StringBuilder builder)
	{
		if (objectOrArray is Hashtable)
		{
			return serializeObject((Hashtable)objectOrArray, builder);
		}
		if (objectOrArray is ArrayList)
		{
			return serializeArray((ArrayList)objectOrArray, builder);
		}
		return false;
	}

	// RECUPERADO-AOT MiniJSON.serializeObject token 0x06000330 @0x00035828
	protected static bool serializeObject(Hashtable anObject, StringBuilder builder)
	{
		builder.Append("{");
		IDictionaryEnumerator e = anObject.GetEnumerator();
		bool first = true;
		while (e.MoveNext())
		{
			string key = e.Key.ToString();
			object value = e.Value;
			if (!first)
			{
				builder.Append(", ");
			}
			serializeString(key, builder);
			builder.Append(":");
			if (!serializeValue(value, builder))
			{
				return false;
			}
			first = false;
		}
		builder.Append("}");
		return true;
	}

	// RECUPERADO-AOT MiniJSON.serializeDictionary token 0x06000331 @0x000359b4
	protected static bool serializeDictionary(Dictionary<string, string> dict, StringBuilder builder)
	{
		builder.Append("{");
		bool first = true;
		foreach (KeyValuePair<string, string> kv in dict)
		{
			if (!first)
			{
				builder.Append(", ");
			}
			serializeString(kv.Key, builder);
			builder.Append(":");
			serializeString(kv.Value, builder);
			first = false;
		}
		builder.Append("}");
		return true;
	}

	// RECUPERADO-AOT MiniJSON.serializeArray token 0x06000332 @0x00035be4
	protected static bool serializeArray(ArrayList anArray, StringBuilder builder)
	{
		builder.Append("[");
		bool first = true;
		for (int i = 0; i < anArray.Count; i++)
		{
			object value = anArray[i];
			if (!first)
			{
				builder.Append(", ");
			}
			if (!serializeValue(value, builder))
			{
				return false;
			}
			first = false;
		}
		builder.Append("]");
		return true;
	}

	// RECUPERADO-AOT MiniJSON.serializeValue token 0x06000333 @0x00035ce0
	protected static bool serializeValue(object value, StringBuilder builder)
	{
		if (value == null)
		{
			builder.Append("null");
		}
		else if (value.GetType().IsArray)
		{
			serializeArray(new ArrayList((ICollection)value), builder);
		}
		else if (value is string)
		{
			serializeString((string)value, builder);
		}
		else if (value is char)
		{
			serializeString(Convert.ToString((char)value), builder);
		}
		else if (value is Hashtable)
		{
			serializeObject((Hashtable)value, builder);
		}
		else if (value is Dictionary<string, string>)
		{
			serializeDictionary((Dictionary<string, string>)value, builder);
		}
		else if (value is ArrayList)
		{
			serializeArray((ArrayList)value, builder);
		}
		else if (value is bool && (bool)value)
		{
			builder.Append("true");
		}
		else if (value is bool && !(bool)value)
		{
			builder.Append("false");
		}
		else
		{
			if (!value.GetType().IsPrimitive)
			{
				return false;
			}
			serializeNumber(Convert.ToDouble(value), builder);
		}
		return true;
	}

	// RECUPERADO-AOT MiniJSON.serializeString token 0x06000334 @0x000362dc
	protected static void serializeString(string aString, StringBuilder builder)
	{
		builder.Append("\"");
		char[] charArray = aString.ToCharArray();
		for (int i = 0; i < charArray.Length; i++)
		{
			char c = charArray[i];
			if (c == '"')
			{
				builder.Append("\\\"");
			}
			else if (c == '\\')
			{
				builder.Append("\\\\");
			}
			else if (c == '\b')
			{
				builder.Append("\\b");
			}
			else if (c == '\f')
			{
				builder.Append("\\f");
			}
			else if (c == '\n')
			{
				builder.Append("\\n");
			}
			else if (c == '\r')
			{
				builder.Append("\\r");
			}
			else if (c == '\t')
			{
				builder.Append("\\t");
			}
			else
			{
				int codepoint = c;
				if (codepoint >= 32 && codepoint <= 126)
				{
					builder.Append(c);
				}
				else
				{
					builder.Append("\\u" + Convert.ToString(codepoint, 16).PadLeft(4, '0'));
				}
			}
		}
		builder.Append("\"");
	}

	// RECUPERADO-AOT MiniJSON.serializeNumber token 0x06000335 @0x00036548
	protected static void serializeNumber(double number, StringBuilder builder)
	{
		// ADAPTADO-U6: invariant culture, same reason as parseNumber.
		builder.Append(Convert.ToString(number, CultureInfo.InvariantCulture));
	}
}
