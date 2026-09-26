using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class CharacterVOController : MonoBehaviour
{
	public AudioClip[] celebrateClips;

	public AudioClip[] poutClips;

	public AudioClip[] characterSelectedClips;

	private List<AudioClip> celebrateQueue;

	private List<AudioClip> poutQueue;

	private List<AudioClip> characterSelectQueue;

	private AudioClip PickClip(List<AudioClip> queue, AudioClip[] clipList)
	{
		/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
	}

	private void PlayClip(AudioClip clip)
	{
	}

	public void PlayCelebrate()
	{
	}

	public void PlayPout()
	{
	}

	public void PlayCharacterSelect()
	{
	}
}
