using System;
using System.Collections;
using System.Diagnostics;
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
			RecoveryPending.Hit("ExternalPersistentArchive.get_TextData");
			return default(string);
		}
		set
		{
			RecoveryPending.Hit("ExternalPersistentArchive.set_TextData");
		}
	}

	private void Serialize()
	{
		RecoveryPending.Hit("ExternalPersistentArchive.Serialize");
	}

	private byte[] Encode()
	{
		RecoveryPending.Hit("ExternalPersistentArchive.Encode");
		return default(byte[]);
	}

	private void Decode(byte[] buffer)
	{
		RecoveryPending.Hit("ExternalPersistentArchive.Decode");
	}

	[DebuggerHidden]
	private IEnumerator LoadFromWebCoroutine(string url)
	{
		RecoveryPending.Hit("ExternalPersistentArchive.LoadFromWebCoroutine");
		yield break;
	}

	[DebuggerHidden]
	private IEnumerator ExternalPersistanceCoroutine()
	{
		RecoveryPending.Hit("ExternalPersistentArchive.ExternalPersistanceCoroutine");
		yield break;
	}

	private void DecryptLocal()
	{
		RecoveryPending.Hit("ExternalPersistentArchive.DecryptLocal");
	}

	private void Start()
	{
		RecoveryPending.Hit("ExternalPersistentArchive.Start");
	}
}
