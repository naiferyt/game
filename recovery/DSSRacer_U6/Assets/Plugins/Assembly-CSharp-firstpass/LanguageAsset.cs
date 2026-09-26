using System;
using UnityEngine;

// One optional translation: a Resources text file and/or a URL (relative to the data folder) for a language.
// Source listing: recovery/aot_listings/Assembly-CSharp-firstpass/LanguageAsset.txt
[Serializable]
public class LanguageAsset
{
	public SystemLanguage language;

	// RECUPERADO-AOT LanguageAsset..ctor token 0x06000226 @0x0002aea8 (field initializers)
	public string webAssetURL = string.Empty;

	public string resourceName = string.Empty;
}
