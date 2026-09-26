using System.Runtime.InteropServices;

namespace System.ComponentModel
{
	[AttributeUsage(AttributeTargets.All)]
	[ComVisible(true)]
	public sealed class TypeConverterAttribute : Attribute
	{
		public static readonly TypeConverterAttribute Default;

		private string converter_type;

		public string ConverterTypeName
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		public TypeConverterAttribute()
		{
		}

		public TypeConverterAttribute(Type type)
		{
		}

		public override bool Equals(object obj)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public override int GetHashCode()
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}
	}
}
