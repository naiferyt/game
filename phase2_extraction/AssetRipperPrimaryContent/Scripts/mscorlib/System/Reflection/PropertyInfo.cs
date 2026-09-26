using System.Diagnostics;
using System.Globalization;
using System.Runtime.InteropServices;

namespace System.Reflection
{
	[Serializable]
	[ComDefaultInterface(typeof(_PropertyInfo))]
	[ClassInterface(ClassInterfaceType.None)]
	[ComVisible(true)]
	public abstract class PropertyInfo : MemberInfo, _PropertyInfo
	{
		public abstract PropertyAttributes Attributes { get; }

		public override MemberTypes MemberType
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		public abstract Type PropertyType { get; }

		public abstract MethodInfo GetGetMethod(bool nonPublic);

		public abstract ParameterInfo[] GetIndexParameters();

		public abstract MethodInfo GetSetMethod(bool nonPublic);

		[DebuggerStepThrough]
		[DebuggerHidden]
		public virtual void SetValue(object obj, object value, object[] index)
		{
		}

		public abstract void SetValue(object obj, object value, BindingFlags invokeAttr, Binder binder, object[] index, CultureInfo culture);
	}
}
