using System;
using System.Collections;
using UnityEngine;

// Base class of most game components: coroutine helpers, typed component lookups and message broadcasting.
// Source listing: recovery/aot_listings/Assembly-CSharp-firstpass/Script.txt
public class Script : MonoBehaviour
{
	public delegate void AnimationDelegate(float alpha);

	// RECUPERADO-AOT Script.AddAnimation token 0x0600023f @0x0002c810
	public void AddAnimation(float duration, AnimationDelegate d)
	{
		StartCoroutine(AnimationHelper(duration, d, 0f));
	}

	// RECUPERADO-AOT Script.AddAnimation token 0x06000240 @0x0002c88c
	public void AddAnimation(float duration, AnimationDelegate d, float wait)
	{
		StartCoroutine(AnimationHelper(duration, d, wait));
	}

	// RECUPERADO-AOT Script.AnimationHelper token 0x06000241 @0x0002c904
	// (body: <AnimationHelper>c__Iterator0.MoveNext token 0x06000516 @0x000509fc)
	private IEnumerator AnimationHelper(float duration, AnimationDelegate d, float wait)
	{
		yield return new WaitForSeconds(wait);
		float startTime = Time.time;
		float elapsed = 0f;
		while (elapsed < duration)
		{
			d(elapsed / duration);
			yield return null;
			elapsed = Time.time - startTime;
		}
		d(1f);
	}

	// RECUPERADO-AOT Script.AddDelayed token 0x06000242 @0x0002c99c
	public void AddDelayed(float wait, Action delayed)
	{
		StartCoroutine(DelayedHelper(wait, delayed));
	}

	// RECUPERADO-AOT Script.DelayedHelper token 0x06000243 @0x0002c9fc
	// (body: <DelayedHelper>c__Iterator1.MoveNext token 0x0600051c @0x00050cac)
	private IEnumerator DelayedHelper(float wait, Action delayed)
	{
		yield return new WaitForSeconds(wait);
		delayed();
	}

	// RECUPERADO-AOT Script.GetComponentFrom token 0x06000244 @0x0002ca70
	public static T GetComponentFrom<T>(GameObject g) where T : Component
	{
		return (T)g.GetComponent(typeof(T));
	}

	// RECUPERADO-AOT Script.GetComponentFrom token 0x06000245 @0x0002cad0
	public static T GetComponentFrom<T>(Component c) where T : Component
	{
		return (T)c.GetComponent(typeof(T));
	}

	// RECUPERADO-AOT Script.GetComponentsFrom token 0x06000246 @0x0002cb30
	public static T[] GetComponentsFrom<T>(GameObject g) where T : Component
	{
		return ConvertObjectArray<T>(g.GetComponents(typeof(T)));
	}

	// RECUPERADO-AOT Script.GetComponentsInChildrenFrom token 0x06000247 @0x0002cb90
	public static T[] GetComponentsInChildrenFrom<T>(GameObject g) where T : Component
	{
		return ConvertObjectArray<T>(g.GetComponentsInChildren(typeof(T)));
	}

	// RECUPERADO-AOT Script.GetComponentsInChildrenFrom token 0x06000248 @0x0002cbf0
	public static T[] GetComponentsInChildrenFrom<T>(Component c) where T : Component
	{
		return ConvertObjectArray<T>(c.GetComponentsInChildren(typeof(T)));
	}

	// RECUPERADO-AOT Script.AddComponent token 0x06000249 @0x0002cc50
	public T AddComponent<T>() where T : Component
	{
		return (T)gameObject.AddComponent(typeof(T));
	}

	// RECUPERADO-AOT Script.AddComponentTo token 0x0600024a @0x0002ccc0
	public static T AddComponentTo<T>(GameObject g) where T : Component
	{
		return (T)g.AddComponent(typeof(T));
	}

	// RECUPERADO-AOT Script.AddComponentTo token 0x0600024b @0x0002cd20
	public static T AddComponentTo<T>(Component c) where T : Component
	{
		return (T)c.gameObject.AddComponent(typeof(T));
	}

	// RECUPERADO-AOT Script.ConvertObjectArray token 0x0600024c @0x0002cd94
	// RECUPERADO-AOT Script.<ConvertObjectArray`1>m__3 token 0x0600025d @0x0002d994
	public static T[] ConvertObjectArray<T>(UnityEngine.Object[] objects) where T : UnityEngine.Object
	{
		return Array.ConvertAll<UnityEngine.Object, T>(objects, o => (T)o);
	}

	// RECUPERADO-AOT Script.GetComponentUpwards token 0x0600024d @0x0002ce08
	public T GetComponentUpwards<T>() where T : Component
	{
		return GetComponentUpwardsFrom<T>(gameObject);
	}

	// RECUPERADO-AOT Script.GetComponentUpwardsFrom token 0x0600024e @0x0002ce58
	public static T GetComponentUpwardsFrom<T>(GameObject g) where T : Component
	{
		Transform t = g.transform;
		T found;
		do
		{
			found = GetComponentFrom<T>(t);
			if (found != null)
			{
				break;
			}
			t = t.parent;
		}
		while (t != null);
		return found;
	}

	// RECUPERADO-AOT Script.GetComponentUpwardsFrom token 0x0600024f @0x0002cee4
	public static T GetComponentUpwardsFrom<T>(Component c) where T : Component
	{
		return GetComponentUpwardsFrom<T>(c.gameObject);
	}

	// RECUPERADO-AOT Script.Instantiate token 0x06000250 @0x0002cf38
	public static T Instantiate<T>(T original, Vector3 position, Quaternion rotation) where T : UnityEngine.Object
	{
		return (T)UnityEngine.Object.Instantiate((UnityEngine.Object)original, position, rotation);
	}

	// RECUPERADO-AOT Script.Instantiate token 0x06000251 @0x0002cfe0
	public static T Instantiate<T>(T original) where T : UnityEngine.Object
	{
		return (T)UnityEngine.Object.Instantiate((UnityEngine.Object)original);
	}

	// RECUPERADO-AOT Script.InstantiateIfNotPresent token 0x06000252 @0x0002d030
	public static GameObject InstantiateIfNotPresent(GameObject prefab)
	{
		GameObject go = GameObject.Find(prefab.name + " *");
		if (go == null)
		{
			go = Instantiate<GameObject>(prefab);
			go.name = prefab.name + " *";
			Debug.Log("creating a new of " + prefab.name + ".");
		}
		else
		{
			Debug.Log("Instance of " + prefab.name + " was found.");
		}
		return go;
	}

	// RECUPERADO-AOT Script.InstantiateIfNotPresent token 0x06000253 @0x0002d170
	public static T InstantiateIfNotPresent<T>(T prefab) where T : Component
	{
		T result = null;
		GameObject go = GameObject.Find(prefab.name + " *");
		if (go == null)
		{
			result = Instantiate<T>(prefab);
			result.name = prefab.name + " *";
		}
		else
		{
			result = GetComponentFrom<T>(go);
		}
		return result;
	}

	// RECUPERADO-AOT Script.SendMessageToObjectsOfType token 0x06000254 @0x0002d274
	public static void SendMessageToObjectsOfType<T>(string messageName) where T : Component
	{
		SendMessageToObjectsOfType<T>(messageName, null);
	}

	// RECUPERADO-AOT Script.SendMessageToObjectsOfType token 0x06000255 @0x0002d2bc
	public static void SendMessageToObjectsOfType<T>(string messageName, UnityEngine.Object data) where T : Component
	{
		// ADAPTADO-U6: Object.FindObjectsOfType -> U4Compat (FindObjectsByType)
		UnityEngine.Object[] objects = U4Compat.FindObjectsOfType(typeof(T));
		for (int i = 0; i < objects.Length; i++)
		{
			T c = (T)objects[i];
			c.SendMessage(messageName, data, SendMessageOptions.DontRequireReceiver);
		}
	}

	// RECUPERADO-AOT Script.SendMessageToGameObjects token 0x06000256 @0x0002d380
	public static void SendMessageToGameObjects(string messageName)
	{
		SendMessageToGameObjects(messageName, null);
	}

	// RECUPERADO-AOT Script.SendMessageToGameObjects token 0x06000257 @0x0002d3b8
	public static void SendMessageToGameObjects(string messageName, UnityEngine.Object data)
	{
		// ADAPTADO-U6: Object.FindObjectsOfType -> U4Compat (FindObjectsByType)
		UnityEngine.Object[] objects = U4Compat.FindObjectsOfType(typeof(GameObject));
		for (int i = 0; i < objects.Length; i++)
		{
			GameObject go = (GameObject)objects[i];
			go.SendMessage(messageName, data, SendMessageOptions.DontRequireReceiver);
		}
	}

	// RECUPERADO-AOT Script.CreateLoop token 0x06000258 @0x0002d4a0
	public AudioSource CreateLoop(AudioClip clip)
	{
		return CreateLoop(clip, 1f);
	}

	// RECUPERADO-AOT Script.CreateLoop token 0x06000259 @0x0002d4f8
	public AudioSource CreateLoop(AudioCrumb crumb)
	{
		return CreateLoop(crumb.clip, crumb.volume);
	}

	// RECUPERADO-AOT Script.CreateLoop token 0x0600025a @0x0002d54c
	public AudioSource CreateLoop(AudioClip clip, float volume)
	{
		AudioSource source = gameObject.AddComponent<AudioSource>();
		source.volume = volume;
		source.rolloffMode = AudioRolloffMode.Linear;
		source.clip = clip;
		source.loop = true;
		return source;
	}

	// RECUPERADO-AOT Script.FindNameRecursive token 0x0600025b @0x0002d618
	public Transform FindNameRecursive(string name)
	{
		if (gameObject.name == name)
		{
			return transform;
		}
		return FindNameRecursive(transform, name);
	}

	// RECUPERADO-AOT Script.FindNameRecursive token 0x0600025c @0x0002d690
	private Transform FindNameRecursive(Transform t, string name)
	{
		if (!t.gameObject.activeInHierarchy)
		{
			return null;
		}
		foreach (Transform child in t)
		{
			if (string.Compare(child.gameObject.name, name, true) == 0)
			{
				return child;
			}
			Transform found = FindNameRecursive(child, name);
			if (found != null)
			{
				return found;
			}
		}
		return null;
	}
}
