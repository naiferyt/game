using System;
using System.Collections;
using UnityEngine;

public class ExternalPersistentArchive : MonoBehaviour
{
	public enum ExternalPersistanceType
	{
		None = 0,
		Web = 1,
		Resource = 2,
		File = 3
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
			return default(string);
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
		return default(byte[]);
	}

	private void Decode(byte[] buffer)
	{
	}

	[System.Diagnostics.DebuggerHidden]
	private IEnumerator LoadFromWebCoroutine(string url)
	{
		return default(IEnumerator);
	}

	[System.Diagnostics.DebuggerHidden]
	private IEnumerator ExternalPersistanceCoroutine()
	{
		return default(IEnumerator);
	}

	private void DecryptLocal()
	{
	}

	private void Start()
	{
	}
}
