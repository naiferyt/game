using System;
using System.Collections.Generic;

internal static class MessengerInternal
{
	public class BroadcastException : Exception
	{
		public BroadcastException(string msg)
		{
			RecoveryPending.Hit("MessengerInternal.BroadcastException..ctor");
		}
	}

	public class ListenerException : Exception
	{
		public ListenerException(string msg)
		{
			RecoveryPending.Hit("MessengerInternal.ListenerException..ctor");
		}
	}

	public static Dictionary<string, Delegate> eventTable;

	public static readonly MessengerMode DEFAULT_MODE;

	public static void OnListenerAdding(string eventType, Delegate listenerBeingAdded)
	{
		RecoveryPending.Hit("MessengerInternal.OnListenerAdding");
	}

	public static void OnListenerRemoving(string eventType, Delegate listenerBeingRemoved)
	{
		RecoveryPending.Hit("MessengerInternal.OnListenerRemoving");
	}

	public static void OnListenerRemoved(string eventType)
	{
		RecoveryPending.Hit("MessengerInternal.OnListenerRemoved");
	}

	public static void OnBroadcasting(string eventType, MessengerMode mode)
	{
		RecoveryPending.Hit("MessengerInternal.OnBroadcasting");
	}

	public static BroadcastException CreateBroadcastSignatureException(string eventType)
	{
		RecoveryPending.Hit("MessengerInternal.CreateBroadcastSignatureException");
		return default(BroadcastException);
	}
}
