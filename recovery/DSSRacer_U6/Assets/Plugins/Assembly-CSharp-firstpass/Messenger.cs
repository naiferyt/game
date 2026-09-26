using System;
using System.Collections.Generic;

public static class Messenger
{
	private static Dictionary<string, Delegate> eventTable;

	public static void AddListener(string eventType, Callback handler)
	{
	}

	public static void RemoveListener(string eventType, Callback handler)
	{
	}

	public static void Broadcast(string eventType)
	{
	}

	public static void Broadcast(string eventType, MessengerMode mode)
	{
	}
}
public static class Messenger<T>
{
	private static Dictionary<string, Delegate> eventTable;

	public static void AddListener(string eventType, Callback<T> handler)
	{
	}

	public static void RemoveListener(string eventType, Callback<T> handler)
	{
	}

	public static void Broadcast(string eventType, T arg1)
	{
	}

	public static void Broadcast(string eventType, T arg1, MessengerMode mode)
	{
	}
}
public static class Messenger<T, U>
{
	private static Dictionary<string, Delegate> eventTable;

	public static void AddListener(string eventType, Callback<T, U> handler)
	{
	}

	public static void RemoveListener(string eventType, Callback<T, U> handler)
	{
	}

	public static void Broadcast(string eventType, T arg1, U arg2)
	{
	}

	public static void Broadcast(string eventType, T arg1, U arg2, MessengerMode mode)
	{
	}
}
public static class Messenger<T, U, V>
{
	private static Dictionary<string, Delegate> eventTable;

	public static void AddListener(string eventType, Callback<T, U, V> handler)
	{
	}

	public static void RemoveListener(string eventType, Callback<T, U, V> handler)
	{
	}

	public static void Broadcast(string eventType, T arg1, U arg2, V arg3)
	{
	}

	public static void Broadcast(string eventType, T arg1, U arg2, V arg3, MessengerMode mode)
	{
	}
}
