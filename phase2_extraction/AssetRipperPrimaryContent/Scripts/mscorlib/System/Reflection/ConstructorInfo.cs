using System.Diagnostics;
using System.Globalization;
using System.Runtime.InteropServices;

namespace System.Reflection
{
	[Serializable]
	[ClassInterface(ClassInterfaceType.None)]
	[ComVisible(true)]
	[ComDefaultInterface(typeof(_ConstructorInfo))]
	public abstract class ConstructorInfo : MethodBase, _ConstructorInfo
	{
		[ComVisible(true)]
		public static readonly string ConstructorName;

		[ComVisible(true)]
		public static readonly string TypeConstructorName;

		[ComVisible(true)]
		public override MemberTypes MemberType
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		[DebuggerHidden]
		[DebuggerStepThrough]
		public object Invoke(object[] parameters)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public abstract object Invoke(BindingFlags invokeAttr, Binder binder, object[] parameters, CultureInfo culture);
	}
}
