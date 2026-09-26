namespace System.Runtime.CompilerServices
{
	[AttributeUsage(AttributeTargets.Assembly, AllowMultiple = true, Inherited = false)]
	public sealed class TypeForwardedToAttribute : Attribute
	{
		private readonly Type _003CDestination_003Ek__BackingField;

		public Type Destination
		{
			get
			{
				return _003CDestination_003Ek__BackingField;
			}
		}

		public TypeForwardedToAttribute(Type destination)
		{
			_003CDestination_003Ek__BackingField = destination;
		}
	}
}
