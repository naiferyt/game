using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using UnityEngine;

// Text document fetched from an external location (web, Resources or file) and cached locally, AES-encrypted,
// in <persistentDataPath>/<archiveName>. Listeners get OnExternalAchiveRead once the external read finishes.
// Source listing: recovery/aot_listings/Assembly-CSharp-firstpass/ExternalPersistentArchive.txt
public class ExternalPersistentArchive : MonoBehaviour
{
	public enum ExternalPersistanceType
	{
		None = 0,
		Web = 1,
		Resource = 2,
		File = 3
	}

	// RECUPERADO-AOT ExternalPersistentArchive::.ctor token 0x060000f1 @0x00014e98 (field initializers)
	public string archiveName = "[Your Local Archive File Name Here]";

	public ExternalPersistanceType externalLocationType;

	public string externalURI = "[External URL, Resource, or File Name Here]";

	public Action<ExternalPersistentArchive> OnExternalAchiveRead;

	private string textData;

	// RECUPERADO-AOT ExternalPersistentArchive::.cctor token 0x060000f2 @0x00014ef4
	// (32-byte key: static array data <PrivateImplementationDetails>.$$field-0 of Assembly-CSharp-firstpass.dll)
	private static byte[] rijKey = new byte[32]
	{
		211, 158, 200, 150, 86, 121, 9, 214, 207, 86, 201, 253, 88, 176, 120, 179,
		216, 47, 240, 149, 104, 4, 7, 156, 185, 65, 68, 67, 245, 209, 101, 141
	};

	// RECUPERADO-AOT ExternalPersistentArchive::get_TextData token 0x060000f3 @0x00014f6c
	// RECUPERADO-AOT ExternalPersistentArchive::set_TextData token 0x060000f4 @0x00014fa0
	public string TextData
	{
		get
		{
			return textData;
		}
		set
		{
			textData = value;
			Serialize();
		}
	}

	// RECUPERADO-AOT ExternalPersistentArchive::Serialize token 0x060000f5 @0x00014fe0
	// ADAPTADO-U6: the Application.isWebPlayer guard ("Can't serialize local persistant archives in web builds.")
	// is gone with the web player.
	private void Serialize()
	{
		byte[] array = Encode();
		if (array != null)
		{
			string path = Application.persistentDataPath + "/" + archiveName;
			if (File.Exists(path))
			{
				File.Delete(path);
			}
			FileStream fileStream = File.Create(path);
			fileStream.Write(array, 0, array.Length);
			fileStream.Close();
		}
	}

	// RECUPERADO-AOT ExternalPersistentArchive::Encode token 0x060000f6 @0x000150b8
	// Output layout: IV followed by the AES (Rijndael, CBC, PKCS7) ciphertext of textData.
	private byte[] Encode()
	{
		if (textData == null)
		{
			return null;
		}
		RijndaelManaged rijndaelManaged = new RijndaelManaged();
		rijndaelManaged.Padding = PaddingMode.PKCS7;
		rijndaelManaged.Key = rijKey;
		rijndaelManaged.GenerateIV();
		ICryptoTransform transform = rijndaelManaged.CreateEncryptor(rijndaelManaged.Key, rijndaelManaged.IV);
		MemoryStream memoryStream = new MemoryStream();
		CryptoStream stream = new CryptoStream(memoryStream, transform, CryptoStreamMode.Write);
		StreamWriter streamWriter = new StreamWriter(stream);
		streamWriter.Write(textData);
		streamWriter.Close();
		List<byte> list = new List<byte>();
		list.AddRange(rijndaelManaged.IV);
		list.AddRange(memoryStream.ToArray());
		return list.ToArray();
	}

	// RECUPERADO-AOT ExternalPersistentArchive::Decode token 0x060000f7 @0x000152e8
	private void Decode(byte[] buffer)
	{
		RijndaelManaged rijndaelManaged = new RijndaelManaged();
		rijndaelManaged.Padding = PaddingMode.PKCS7;
		rijndaelManaged.Key = rijKey;
		byte[] array = new byte[rijndaelManaged.IV.Length];
		Array.Copy(buffer, array, rijndaelManaged.IV.Length);
		rijndaelManaged.IV = array;
		byte[] array2 = new byte[buffer.Length - rijndaelManaged.IV.Length];
		Array.Copy(buffer, rijndaelManaged.IV.Length, array2, 0, array2.Length);
		MemoryStream stream = new MemoryStream(array2);
		ICryptoTransform transform = rijndaelManaged.CreateDecryptor(rijndaelManaged.Key, rijndaelManaged.IV);
		CryptoStream stream2 = new CryptoStream(stream, transform, CryptoStreamMode.Read);
		StreamReader streamReader = new StreamReader(stream2);
		textData = streamReader.ReadToEnd();
	}

	// RECUPERADO-AOT ExternalPersistentArchive::LoadFromWebCoroutine token 0x060000f8 @0x00015560
	// (iterator <LoadFromWebCoroutine>c__Iterator5 MoveNext token 0x06000534 @0x0005175c)
	// ADAPTADO-U6: WWW -> U4Compat.WebRequest. Not reached: the Web case is ELIMINADO below.
	[DebuggerHidden]
	private IEnumerator LoadFromWebCoroutine(string url)
	{
		U4Compat.WebRequest web = new U4Compat.WebRequest(url);
		while (!web.isDone)
		{
			yield return null;
		}
		if (web == null)
		{
			UnityEngine.Debug.LogWarning("Error downloading archive.");
		}
		else if (web.error != null && web.error.Length > 0)
		{
			UnityEngine.Debug.LogWarning("Error downloading archive " + archiveName + " : " + web.error);
		}
		else if (web.text == null || web.text.Length < 1)
		{
			UnityEngine.Debug.LogWarning("Downloaded archive appears to be empty or corrupt.");
		}
		else
		{
			textData = web.text;
		}
	}

	// RECUPERADO-AOT ExternalPersistentArchive::ExternalPersistanceCoroutine token 0x060000f9 @0x000155b8
	// (iterator <ExternalPersistanceCoroutine>c__Iterator6 MoveNext token 0x0600053a @0x00051a5c)
	[DebuggerHidden]
	private IEnumerator ExternalPersistanceCoroutine()
	{
		switch (externalLocationType)
		{
		case ExternalPersistanceType.Web:
			// ELIMINADO (contenido remoto muerto, RECOVERY_REPORT.md 11.2): yield return
			// StartCoroutine(LoadFromWebCoroutine(externalURI)); the only archive (CartPartList's PartCosts.epa)
			// pointed to a.dolimg.com. The locally cached copy read by DecryptLocal is kept.
			break;
		case ExternalPersistanceType.Resource:
		{
			TextAsset config = (TextAsset)Resources.Load(externalURI);
			if (config != null)
			{
				textData = config.text;
				Resources.UnloadAsset(config);
			}
			break;
		}
		case ExternalPersistanceType.File:
			if (File.Exists(externalURI))
			{
				FileStream file = new FileStream(externalURI, FileMode.Open);
				byte[] buffer = new byte[file.Length];
				file.Read(buffer, 0, buffer.Length);
				file.Close();
				textData = Encoding.ASCII.GetString(buffer);
			}
			break;
		}
		Serialize();
		if (OnExternalAchiveRead != null)
		{
			OnExternalAchiveRead(this);
		}
		yield break;
	}

	// RECUPERADO-AOT ExternalPersistentArchive::DecryptLocal token 0x060000fa @0x00015600
	// ADAPTADO-U6: the Application.isWebPlayer guard ("Local archives are not available in web builds.") is gone.
	private void DecryptLocal()
	{
		string text = Application.persistentDataPath + "/" + archiveName;
		if (File.Exists(text))
		{
			FileStream fileStream = File.OpenRead(text);
			byte[] array = new byte[fileStream.Length];
			fileStream.Read(array, 0, (int)fileStream.Length);
			fileStream.Close();
			Decode(array);
		}
		else
		{
			UnityEngine.Debug.Log("No local archive exists at " + text);
		}
	}

	// RECUPERADO-AOT ExternalPersistentArchive::Start token 0x060000fb @0x00015768
	private void Start()
	{
		DecryptLocal();
		StartCoroutine(ExternalPersistanceCoroutine());
	}
}
