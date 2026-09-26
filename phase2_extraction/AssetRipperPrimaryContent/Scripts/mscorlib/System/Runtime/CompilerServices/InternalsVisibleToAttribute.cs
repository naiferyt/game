namespace System.Runtime.CompilerServices
{
	[AttributeUsage(AttributeTargets.Assembly, AllowMultiple = true, Inherited = false)]
	public sealed class InternalsVisibleToAttribute : Attribute
	{
		private string assemblyName;

		private bool all_visible;

		public InternalsVisibleToAttribute(string assemblyName)
		{
		}
	}
}
