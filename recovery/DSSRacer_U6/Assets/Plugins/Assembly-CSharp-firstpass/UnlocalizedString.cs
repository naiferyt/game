using System;

// A literal string that is deliberately NOT translated (same shape as LocalizedString).
// Source listing: recovery/aot_listings/Assembly-CSharp-firstpass/UnlocalizedString.txt
[Serializable]
public class UnlocalizedString
{
	public string baseText = string.Empty;

	public string Text
	{
		// RECUPERADO-AOT UnlocalizedString.get_Text token 0x06000221 @0x0002ad80
		get
		{
			return baseText;
		}
	}

	// RECUPERADO-AOT UnlocalizedString..ctor token 0x0600021e @0x0002acb4
	public UnlocalizedString()
	{
	}

	// RECUPERADO-AOT UnlocalizedString..ctor token 0x0600021f @0x0002acfc
	public UnlocalizedString(string text)
	{
		baseText = text;
	}

	// RECUPERADO-AOT UnlocalizedString.UnlocalizedStringMarker token 0x06000220 @0x0002ad50
	public static string UnlocalizedStringMarker(string text)
	{
		return text;
	}

	// RECUPERADO-AOT UnlocalizedString.ToString token 0x06000222 @0x0002adb4
	public override string ToString()
	{
		return baseText;
	}

	// RECUPERADO-AOT UnlocalizedString.op_Implicit token 0x06000223 @0x0002ade8
	public static implicit operator UnlocalizedString(string text)
	{
		return new UnlocalizedString(text);
	}

	// RECUPERADO-AOT UnlocalizedString.op_Implicit token 0x06000224 @0x0002ae38
	public static implicit operator string(UnlocalizedString unloc)
	{
		return unloc.baseText;
	}

	// RECUPERADO-AOT UnlocalizedString.op_Addition token 0x06000225 @0x0002ae6c
	// (the original assigns rather than concatenates; kept as compiled)
	public static string operator +(UnlocalizedString a, string b)
	{
		return a.baseText = b;
	}
}
