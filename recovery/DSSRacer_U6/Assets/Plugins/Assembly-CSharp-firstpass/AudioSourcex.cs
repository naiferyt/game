using UnityEngine;

// One-shot sounds on temporary GameObjects that destroy themselves when the clip ends.
// Source listing: recovery/aot_listings/Assembly-CSharp-firstpass/AudioSourcex.txt
public class AudioSourcex
{
	// RECUPERADO-AOT AudioSourcex::PlayClipAtTransform token 0x060000ff @0x0001593c
	// ADAPTADO-U6: AddComponent(typeof(AudioSource)) + GameObject.audio -> GetComponent<AudioSource>().
	public static AudioSource PlayClipAtTransform(AudioClip clip, Transform transform, float volume, float pitch)
	{
		GameObject gameObject = new GameObject(clip.name + " Instantiation");
		gameObject.AddComponent(typeof(AudioSource));
		gameObject.GetComponent<AudioSource>().clip = clip;
		gameObject.transform.position = transform.position;
		gameObject.transform.parent = transform;
		gameObject.GetComponent<AudioSource>().volume = volume * AudioManager.instance.SoundEffectsVolume;
		if (pitch != 1f)
		{
			gameObject.GetComponent<AudioSource>().pitch = pitch;
		}
		gameObject.GetComponent<AudioSource>().Play();
		Object.DontDestroyOnLoad(gameObject);
		Object.Destroy(gameObject, clip.length / pitch + 0.2f);
		return gameObject.GetComponent<AudioSource>();
	}

	// RECUPERADO-AOT AudioSourcex::PlayClipAtTransform token 0x06000100 @0x00015b74
	public static AudioSource PlayClipAtTransform(AudioClip clip, Transform transform, float volume)
	{
		return PlayClipAtTransform(clip, transform, volume, 1f);
	}

	// RECUPERADO-AOT AudioSourcex::PlayCrumbAtTransform token 0x06000101 @0x00015be4
	// The crumb's playbackSpeed is not used, as compiled.
	public static AudioSource PlayCrumbAtTransform(AudioCrumb crumb, Transform transform)
	{
		return PlayClipAtTransform(crumb.clip, transform, crumb.volume);
	}

	// RECUPERADO-AOT AudioSourcex::PlayClipAtPosition token 0x06000102 @0x00015c38
	public static AudioSource PlayClipAtPosition(AudioClip clip, Vector3 position, float volume, float pitch)
	{
		GameObject gameObject = new GameObject(clip.name + " Instantiation");
		gameObject.AddComponent(typeof(AudioSource));
		gameObject.GetComponent<AudioSource>().clip = clip;
		gameObject.transform.position = position;
		gameObject.GetComponent<AudioSource>().volume = volume * AudioManager.instance.SoundEffectsVolume;
		if (pitch != 1f)
		{
			gameObject.GetComponent<AudioSource>().pitch = pitch;
		}
		gameObject.GetComponent<AudioSource>().Play();
		Object.DontDestroyOnLoad(gameObject);
		Object.Destroy(gameObject, clip.length / pitch + 0.2f);
		return gameObject.GetComponent<AudioSource>();
	}
}
