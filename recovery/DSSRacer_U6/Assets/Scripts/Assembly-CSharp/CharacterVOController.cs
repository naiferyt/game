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
		RecoveryPending.Hit("CharacterVOController.PickClip");
		return default(AudioClip);
	}

	private void PlayClip(AudioClip clip)
	{
		RecoveryPending.Hit("CharacterVOController.PlayClip");
	}

	public void PlayCelebrate()
	{
		RecoveryPending.Hit("CharacterVOController.PlayCelebrate");
	}

	public void PlayPout()
	{
		RecoveryPending.Hit("CharacterVOController.PlayPout");
	}

	public void PlayCharacterSelect()
	{
		RecoveryPending.Hit("CharacterVOController.PlayCharacterSelect");
	}
}
