using System;
using System.Collections.Generic;

public static class Messenger
{
	private static Dictionary<string, Delegate> eventTable;

	public static void AddListener(string eventType, Callback handler)
	{
		RecoveryPending.Hit("Messenger.AddListener");
	}

	public static void RemoveListener(string eventType, Callback handler)
	{
		RecoveryPending.Hit("Messenger.RemoveListener");
	}

	public static void Broadcast(string eventType)
	{
		RecoveryPending.Hit("Messenger.Broadcast");
	}

	public static void Broadcast(string eventType, MessengerMode mode)
	{
		RecoveryPending.Hit("Messenger.Broadcast");
	}
}
public static class Messenger<T>
{
	private static Dictionary<string, Delegate> eventTable;

	public static void AddListener(string eventType, Callback<T> handler)
	{
		RecoveryPending.Hit("Messenger.AddListener");
	}

	public static void RemoveListener(string eventType, Callback<T> handler)
	{
		RecoveryPending.Hit("Messenger.RemoveListener");
	}

	public static void Broadcast(string eventType, T arg1)
	{
		RecoveryPending.Hit("Messenger.Broadcast");
	}

	public static void Broadcast(string eventType, T arg1, MessengerMode mode)
	{
		RecoveryPending.Hit("Messenger.Broadcast");
	}
}
public static class Messenger<T, U>
{
	private static Dictionary<string, Delegate> eventTable;

	public static void AddListener(string eventType, Callback<T, U> handler)
	{
		RecoveryPending.Hit("Messenger.AddListener");
	}

	public static void RemoveListener(string eventType, Callback<T, U> handler)
	{
		RecoveryPending.Hit("Messenger.RemoveListener");
	}

	public static void Broadcast(string eventType, T arg1, U arg2)
	{
		RecoveryPending.Hit("Messenger.Broadcast");
	}

	public static void Broadcast(string eventType, T arg1, U arg2, MessengerMode mode)
	{
		RecoveryPending.Hit("Messenger.Broadcast");
	}
}
public static class Messenger<T, U, V>
{
	private static Dictionary<string, Delegate> eventTable;

	public static void AddListener(string eventType, Callback<T, U, V> handler)
	{
		RecoveryPending.Hit("Messenger.AddListener");
	}

	public static void RemoveListener(string eventType, Callback<T, U, V> handler)
	{
		RecoveryPending.Hit("Messenger.RemoveListener");
	}

	public static void Broadcast(string eventType, T arg1, U arg2, V arg3)
	{
		RecoveryPending.Hit("Messenger.Broadcast");
	}

	public static void Broadcast(string eventType, T arg1, U arg2, V arg3, MessengerMode mode)
	{
		RecoveryPending.Hit("Messenger.Broadcast");
	}
}
