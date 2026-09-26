using System;
using System.Collections;
using UnityEngine;

public class Script : MonoBehaviour
{
	public delegate void AnimationDelegate(float alpha);

	public void AddAnimation(float duration, AnimationDelegate d)
	{
	}

	public void AddAnimation(float duration, AnimationDelegate d, float wait)
	{
	}

	[System.Diagnostics.DebuggerHidden]
	private IEnumerator AnimationHelper(float duration, AnimationDelegate d, float wait)
	{
		return default(IEnumerator);
	}

	public void AddDelayed(float wait, Action delayed)
	{
	}

	[System.Diagnostics.DebuggerHidden]
	private IEnumerator DelayedHelper(float wait, Action delayed)
	{
		return default(IEnumerator);
	}

	public static T GetComponentFrom<T>(GameObject g) where T : Component
	{
		return default(T);
	}

	public static T GetComponentFrom<T>(Component c) where T : Component
	{
		return default(T);
	}

	public static T[] GetComponentsFrom<T>(GameObject g) where T : Component
	{
		return default(T[]);
	}

	public static T[] GetComponentsInChildrenFrom<T>(GameObject g) where T : Component
	{
		return default(T[]);
	}

	public static T[] GetComponentsInChildrenFrom<T>(Component c) where T : Component
	{
		return default(T[]);
	}

	public T AddComponent<T>() where T : Component
	{
		return default(T);
	}

	public static T AddComponentTo<T>(GameObject g) where T : Component
	{
		return default(T);
	}

	public static T AddComponentTo<T>(Component c) where T : Component
	{
		return default(T);
	}

	public static T[] ConvertObjectArray<T>(UnityEngine.Object[] objects) where T : UnityEngine.Object
	{
		return default(T[]);
	}

	public T GetComponentUpwards<T>() where T : Component
	{
		return default(T);
	}

	public static T GetComponentUpwardsFrom<T>(GameObject g) where T : Component
	{
		return default(T);
	}

	public static T GetComponentUpwardsFrom<T>(Component c) where T : Component
	{
		return default(T);
	}

	public static T Instantiate<T>(T original, Vector3 position, Quaternion rotation) where T : UnityEngine.Object
	{
		return default(T);
	}

	public static T Instantiate<T>(T original) where T : UnityEngine.Object
	{
		return default(T);
	}

	public static GameObject InstantiateIfNotPresent(GameObject prefab)
	{
		return default(GameObject);
	}

	public static T InstantiateIfNotPresent<T>(T prefab) where T : Component
	{
		return default(T);
	}

	public static void SendMessageToObjectsOfType<T>(string messageName) where T : Component
	{
	}

	public static void SendMessageToObjectsOfType<T>(string messageName, UnityEngine.Object data) where T : Component
	{
	}

	public static void SendMessageToGameObjects(string messageName)
	{
	}

	public static void SendMessageToGameObjects(string messageName, UnityEngine.Object data)
	{
	}

	public AudioSource CreateLoop(AudioClip clip)
	{
		return default(AudioSource);
	}

	public AudioSource CreateLoop(AudioCrumb crumb)
	{
		return default(AudioSource);
	}

	public AudioSource CreateLoop(AudioClip clip, float volume)
	{
		return default(AudioSource);
	}

	public Transform FindNameRecursive(string name)
	{
		return default(Transform);
	}

	private Transform FindNameRecursive(Transform t, string name)
	{
		return default(Transform);
	}
}
