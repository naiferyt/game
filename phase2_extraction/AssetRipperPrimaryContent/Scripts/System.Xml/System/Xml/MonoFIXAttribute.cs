namespace System.Xml
{
	[AttributeUsage(AttributeTargets.All)]
	internal class MonoFIXAttribute : Attribute
	{
		private string comment;

		public MonoFIXAttribute(string comment)
		{
		}
	}
}
