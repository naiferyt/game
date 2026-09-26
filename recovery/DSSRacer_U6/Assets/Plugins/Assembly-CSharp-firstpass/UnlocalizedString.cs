using System;

[Serializable]
public class UnlocalizedString
{
	public string baseText;

	public string Text
	{
		get
		{
			RecoveryPending.Hit("UnlocalizedString.get_Text");
			return default(string);
		}
	}

	public UnlocalizedString()
	{
		RecoveryPending.Hit("UnlocalizedString..ctor");
	}

	public UnlocalizedString(string text)
	{
		RecoveryPending.Hit("UnlocalizedString..ctor");
	}

	public static string UnlocalizedStringMarker(string text)
	{
		RecoveryPending.Hit("UnlocalizedString.UnlocalizedStringMarker");
		return default(string);
	}

	public override string ToString()
	{
		RecoveryPending.Hit("UnlocalizedString.ToString");
		return default(string);
	}

	public static implicit operator UnlocalizedString(string text)
	{
		RecoveryPending.Hit("UnlocalizedString.op_Conversion");
		return default(UnlocalizedString);
	}

	public static implicit operator string(UnlocalizedString unloc)
	{
		RecoveryPending.Hit("UnlocalizedString.op_Conversion");
		return default(string);
	}

	public static string operator +(UnlocalizedString a, string b)
	{
		RecoveryPending.Hit("UnlocalizedString.op_+");
		return default(string);
	}
}
