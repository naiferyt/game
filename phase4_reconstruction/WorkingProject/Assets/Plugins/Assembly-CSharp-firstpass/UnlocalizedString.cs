using System;

[Serializable]
public class UnlocalizedString
{
	public string baseText;

	public string Text
	{
		get
		{
			return default(string);
		}
	}

	public UnlocalizedString()
	{
	}

	public UnlocalizedString(string text)
	{
	}

	public static string UnlocalizedStringMarker(string text)
	{
		return default(string);
	}

	public override string ToString()
	{
		return default(string);
	}

	public static implicit operator UnlocalizedString(string text)
	{
		return default(UnlocalizedString);
	}

	public static implicit operator string(UnlocalizedString unloc)
	{
		return default(string);
	}

	public static string operator +(UnlocalizedString a, string b)
	{
		return default(string);
	}
}
