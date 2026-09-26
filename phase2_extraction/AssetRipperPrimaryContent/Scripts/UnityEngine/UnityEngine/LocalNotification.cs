using System;
using System.Runtime.CompilerServices;

namespace UnityEngine
{
	public sealed class LocalNotification
	{
		private IntPtr notificationWrapper;

		private static long m_NSReferenceDateTicks;

		public DateTime fireDate
		{
			set
			{
			}
		}

		public extern string alertBody
		{
			[MethodImpl(MethodImplOptions.InternalCall)]
			[WrapperlessIcall]
			set;
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		private extern void SetFireDate(double dt);

		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		private extern void Destroy();

		~LocalNotification()
		{
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		private extern void InitWrapper();
	}
}
