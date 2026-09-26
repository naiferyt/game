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
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public override string ToString()
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}
	}

	public static event Action<ArrayList> keyValueStoreDidChangeEvent
	{
		[MethodImpl((MethodImplOptions)32)]
		add
		{
		}
		[MethodImpl((MethodImplOptions)32)]
		remove
		{
		}
	}

	public static event Action entitlementsMissingEvent
	{
		[MethodImpl((MethodImplOptions)32)]
		add
		{
		}
		[MethodImpl((MethodImplOptions)32)]
		remove
		{
		}
	}

	public static event Action<List<iCloudDocument>> documentStoreUpdatedEvent
	{
		[MethodImpl((MethodImplOptions)32)]
		add
		{
		}
		[MethodImpl((MethodImplOptions)32)]
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
