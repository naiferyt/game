using System.Collections.Generic;
using UnityEngine;

// A character's voice lines (celebrate, pout, selected), each played from a shuffled queue so lines don't repeat
// until all have been heard.
// Source listing: recovery/aot_listings/Assembly-CSharp/CharacterVOController.txt
[RequireComponent(typeof(AudioSource))]
public class CharacterVOController : MonoBehaviour
{
	public AudioClip[] celebrateClips;

	public AudioClip[] poutClips;

	public AudioClip[] characterSelectedClips;

	// RECUPERADO-AOT CharacterVOController::.ctor token 0x060002ec @0x000ecd04 (field initializers)
	private List<AudioClip> celebrateQueue = new List<AudioClip>();

	private List<AudioClip> poutQueue = new List<AudioClip>();

	private List<AudioClip> characterSelectQueue = new List<AudioClip>();

	// RECUPERADO-AOT CharacterVOController::PickClip token 0x060002ed @0x000ecdc8
	// Refills and shuffles the queue when empty (the original Fisher-Yates loop stops before i = 1, skipping its
	// last swap; kept as is).
	private AudioClip PickClip(List<AudioClip> queue, AudioClip[] clipList)
	{
		if (clipList == null || clipList.Length == 0)
		{
			return null;
		}
		if (clipList.Length == 1)
		{
			return clipList[0];
		}
		if (queue.Count == 0)
		{
			queue.AddRange(clipList);
			for (int num = queue.Count - 1; num > 1; num--)
			{
				int index = Random.Range(0, num + 1);
				AudioClip value = queue[num];
				queue[num] = queue[index];
				queue[index] = value;
			}
		}
		AudioClip result = queue[0];
		queue.RemoveAt(0);
		return result;
	}

	// RECUPERADO-AOT CharacterVOController::PlayClip token 0x060002ee @0x000ecf18
	// ADAPTADO-U6: Component.audio -> GetComponent<AudioSource>().
	private void PlayClip(AudioClip clip)
	{
		AudioSource component = GetComponent<AudioSource>();
		if (!component.isPlaying)
		{
			component.volume = DataUtility.Instance.localOptions.sfxVolumeLevel;
			component.PlayOneShot(clip);
		}
	}

	// RECUPERADO-AOT CharacterVOController::PlayCelebrate token 0x060002ef @0x000ecfb4
	public void PlayCelebrate()
	{
		PlayClip(PickClip(celebrateQueue, celebrateClips));
	}

	// RECUPERADO-AOT CharacterVOController::PlayPout token 0x060002f0 @0x000ecffc
	public void PlayPout()
	{
		PlayClip(PickClip(poutQueue, poutClips));
	}

	// RECUPERADO-AOT CharacterVOController::PlayCharacterSelect token 0x060002f1 @0x000ed044
	public void PlayCharacterSelect()
	{
		PlayClip(PickClip(characterSelectQueue, characterSelectedClips));
	}
}
