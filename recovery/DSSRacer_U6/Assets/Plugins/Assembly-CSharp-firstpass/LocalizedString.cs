using System;

[Serializable]
public class LocalizedString
{
	public string baseText;

	public virtual string Text
	{
		get
		{
			RecoveryPending.Hit("LocalizedString.get_Text");
			return default(string);
		}
	}

	public LocalizedString()
	{
		RecoveryPending.Hit("LocalizedString..ctor");
	}

	public LocalizedString(string text)
	{
		RecoveryPending.Hit("LocalizedString..ctor");
	}

	public override string ToString()
	{
		RecoveryPending.Hit("LocalizedString.ToString");
		return default(string);
	}
}
