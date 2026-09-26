using System.Runtime.InteropServices;

namespace System.Reflection
{
	[Serializable]
	[ComDefaultInterface(typeof(_MemberInfo))]
	[ComVisible(true)]
	[ClassInterface(ClassInterfaceType.None)]
	public abstract class MemberInfo : ICustomAttributeProvider, _MemberInfo
	{
		public abstract Type DeclaringType { get; }

		public abstract MemberTypes MemberType { get; }

		public abstract string Name { get; }

		public abstract Type ReflectedType { get; }

		public virtual Module Module
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		public abstract bool IsDefined(Type attributeType, bool inherit);

		public abstract object[] GetCustomAttributes(bool inherit);

		public abstract object[] GetCustomAttributes(Type attributeType, bool inherit);
	}
}
