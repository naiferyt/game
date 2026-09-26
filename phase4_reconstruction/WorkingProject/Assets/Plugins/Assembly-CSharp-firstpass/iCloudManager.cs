using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class iCloudManager : MonoBehaviour
{
	public class iCloudDocument
	{
		public string filename;

		public bool isDownloaded;

		public iCloudDocument(Hashtable ht)
		{
		}

		public static List<iCloudDocument> fromJSON(string json)
		{
			return default(List<iCloudDocument>);
		}

		public override string ToString()
		{
			return default(string);
		}
	}

	public static event Action<ArrayList> keyValueStoreDidChangeEvent
	{
		[MethodImpl(MethodImplOptions.Synchronized)]
		add
		{
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		remove
		{
		}
	}

	public static event Action entitlementsMissingEvent
	{
		[MethodImpl(MethodImplOptions.Synchronized)]
		add
		{
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		remove
		{
		}
	}

	public static event Action<List<iCloudDocument>> documentStoreUpdatedEvent
	{
		[MethodImpl(MethodImplOptions.Synchronized)]
		add
		{
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		remove
		{
		}
	}

	private void Awake()
	{
	}

	private void keyValueStoreDidChange(string param)
	{
	}

	private void entitlementsMissing(string empty)
	{
	}

	private void documentStoreUpdated(string json)
	{
	}
}
