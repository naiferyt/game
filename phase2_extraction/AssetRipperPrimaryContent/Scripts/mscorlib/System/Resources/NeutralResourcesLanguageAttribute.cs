using System.Runtime.InteropServices;

namespace System.Resources
{
	[ComVisible(true)]
	[AttributeUsage(AttributeTargets.Assembly)]
	public sealed class NeutralResourcesLanguageAttribute : Attribute
	{
		private string culture;

		private UltimateResourceFallbackLocation loc;

		public NeutralResourcesLanguageAttribute(string cultureName)
		{
		}
	}
}
