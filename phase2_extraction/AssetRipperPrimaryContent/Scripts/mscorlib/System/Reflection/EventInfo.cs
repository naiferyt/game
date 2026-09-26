using System.Runtime.InteropServices;

namespace System.Reflection
{
	[ClassInterface(ClassInterfaceType.None)]
	public abstract class EventInfo : MemberInfo, _EventInfo
	{
		private object placeholder;

		public abstract EventAttributes Attributes { get; }

		public Type EventHandlerType
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		public override MemberTypes MemberType
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		public abstract MethodInfo GetAddMethod(bool nonPublic);
	}
}
