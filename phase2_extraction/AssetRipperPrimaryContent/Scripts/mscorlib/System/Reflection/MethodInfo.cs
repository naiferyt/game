using System.Runtime.InteropServices;

namespace System.Reflection
{
	[Serializable]
	[ComDefaultInterface(typeof(_MethodInfo))]
	[ClassInterface(ClassInterfaceType.None)]
	[ComVisible(true)]
	public abstract class MethodInfo : MethodBase, _MethodInfo
	{
		public override MemberTypes MemberType
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		public virtual Type ReturnType
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		public override bool IsGenericMethod
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		public override bool IsGenericMethodDefinition
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		public override bool ContainsGenericParameters
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		public abstract MethodInfo GetBaseDefinition();

		public virtual MethodInfo MakeGenericMethod(params Type[] typeArguments)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		[ComVisible(true)]
		public override Type[] GetGenericArguments()
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}
	}
}
