using System;

// A string key that resolves through Localize.Get when read.
// Source listing: recovery/aot_listings/Assembly-CSharp-firstpass/LocalizedString.txt
[Serializable]
public class LocalizedString
{
	public string baseText = string.Empty;

	public virtual string Text
	{
		// RECUPERADO-AOT LocalizedString.get_Text token 0x0600021c @0x0002ac3c
		get
		{
			return Localize.Get(baseText);
		}
	}

	// RECUPERADO-AOT LocalizedString..ctor token 0x0600021a @0x0002aba0
	public LocalizedString()
	{
	}

	// RECUPERADO-AOT LocalizedString..ctor token 0x0600021b @0x0002abe8
	public LocalizedString(string text)
	{
		baseText = text;
	}

	// RECUPERADO-AOT LocalizedString.ToString token 0x0600021d @0x0002ac74
	public override string ToString()
	{
		return Text;
	}
}
