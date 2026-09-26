using System;
using System.Collections;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.SceneManagement;

// Intermediate scene between a race and the garage: frees streamed assets and memory, then loads FrontEndTest.
// Source listing: recovery/aot_listings/Assembly-CSharp/PreFrontEndHoop.txt
public class PreFrontEndHoop : MonoBehaviour
{
	// RECUPERADO-AOT PreFrontEndHoop::Start token 0x06000793 @0x0013dc88
	// (iterator <Start>c__Iterator86 MoveNext token 0x06000b00 @0x00163874)
	// ADAPTADO-U6: Application.LoadLevel -> SceneManager.LoadScene.
	[DebuggerHidden]
	private IEnumerator Start()
	{
		yield return new WaitForSeconds(0.5f);
		StreamManager.Cleanup();
		yield return new WaitForSeconds(0.5f);
		GC.Collect();
		yield return new WaitForSeconds(0.5f);
		SceneManager.LoadScene("FrontEndTest");
	}
}
