using System;
using System.Collections.Generic;

internal static class MessengerInternal
{
	public class BroadcastException : Exception
	{
		public BroadcastException(string msg)
		{
		}
	}

	public class ListenerException : Exception
	{
		public ListenerException(string msg)
		{
		}
	}

	public static Dictionary<string, Delegate> eventTable;

	public static readonly MessengerMode DEFAULT_MODE;

	public static void OnListenerAdding(string eventType, Delegate listenerBeingAdded)
	{
	}

	public static void OnListenerRemoving(string eventType, Delegate listenerBeingRemoved)
	{
	}

	public static void OnListenerRemoved(string eventType)
	{
	}

	public static void OnBroadcasting(string eventType, MessengerMode mode)
	{
	}

	public static BroadcastException CreateBroadcastSignatureException(string eventType)
	{
		/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
	}
}
