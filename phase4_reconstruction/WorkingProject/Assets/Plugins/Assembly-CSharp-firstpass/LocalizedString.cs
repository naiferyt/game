using System;

[Serializable]
public class LocalizedString
{
	public string baseText;

	public virtual string Text
	{
		get
		{
			return default(string);
		}
	}

	public LocalizedString()
	{
	}

	public LocalizedString(string text)
	{
	}

	public override string ToString()
	{
		return default(string);
	}
}
