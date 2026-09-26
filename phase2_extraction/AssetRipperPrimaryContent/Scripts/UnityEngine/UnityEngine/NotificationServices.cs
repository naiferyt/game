using System.Runtime.CompilerServices;

namespace UnityEngine
{
	public sealed class NotificationServices
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		public static extern void ScheduleLocalNotification(LocalNotification notification);

		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		public static extern void CancelAllLocalNotifications();
	}
}
