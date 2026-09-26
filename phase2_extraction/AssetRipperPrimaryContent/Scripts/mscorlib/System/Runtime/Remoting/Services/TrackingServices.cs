using System.Collections;
using System.Runtime.InteropServices;

namespace System.Runtime.Remoting.Services
{
	[ComVisible(true)]
	public class TrackingServices
	{
		private static ArrayList _handlers;

		internal static void NotifyMarshaledObject(object obj, ObjRef or)
		{
		}

		internal static void NotifyUnmarshaledObject(object obj, ObjRef or)
		{
		}

		internal static void NotifyDisconnectedObject(object obj)
		{
		}
	}
}
