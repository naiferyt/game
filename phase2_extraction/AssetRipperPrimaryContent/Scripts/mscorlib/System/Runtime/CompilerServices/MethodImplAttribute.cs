namespace System.Runtime.CompilerServices
{
	[AttributeUsage(AttributeTargets.Constructor | AttributeTargets.Method, Inherited = false)]
	public sealed class MethodImplAttribute : Attribute
	{
		public MethodCodeType MethodCodeType;

		private readonly MethodImplOptions _003CValue_003Ek__BackingField;

		public MethodImplOptions Value
		{
			get
			{
				return _003CValue_003Ek__BackingField;
			}
		}

		public MethodImplAttribute(MethodImplOptions methodImplOptions)
		{
			_003CValue_003Ek__BackingField = methodImplOptions;
		}

		public MethodImplAttribute(short value)
		{
			_003CValue_003Ek__BackingField = (MethodImplOptions)value;
		}

		public MethodImplAttribute()
		{
		}
	}
}
