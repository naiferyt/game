using System;
using System.Collections;
using System.Diagnostics;
using UnityEngine;

public class ExternalPersistentArchive : MonoBehaviour
{
	public enum ExternalPersistanceType
	{
		None,
		Web,
		Resource,
		File
	}

	public string archiveName;

	public ExternalPersistanceType externalLocationType;

	public string externalURI;

	public Action<ExternalPersistentArchive> OnExternalAchiveRead;

	private string textData;

	private static byte[] rijKey;

	public string TextData
	{
		get
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}
		set
		{
		}
	}

	private void Serialize()
	{
	}

	private byte[] Encode()
	{
		/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
	}

	private void Decode(byte[] buffer)
	{
	}

	[DebuggerHidden]
	private IEnumerator LoadFromWebCoroutine(string url)
	{
		/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
	}

	[DebuggerHidden]
	private IEnumerator ExternalPersistanceCoroutine()
	{
		/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
	}

	private void DecryptLocal()
	{
	}

	private void Start()
	{
	}
}
