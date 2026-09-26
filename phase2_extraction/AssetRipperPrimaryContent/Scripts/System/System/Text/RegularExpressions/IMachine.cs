namespace System.Text.RegularExpressions
{
	internal interface IMachine
	{
		Match Scan(Regex regex, string text, int start, int end);
	}
}
