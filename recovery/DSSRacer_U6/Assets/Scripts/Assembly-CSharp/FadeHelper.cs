using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

// Fades the material colour alpha of renderers (or whole hierarchies) in or out over time.
// Source listing: recovery/aot_listings/Assembly-CSharp/FadeHelper.txt
public class FadeHelper : MonoBehaviour
{
	private static FadeHelper s_Instance;

	// RECUPERADO-AOT FadeHelper::.ctor token 0x06000406 @0x000fb924 (field initializers)
	private List<KeyValuePair<Renderer, Color>> currentFades = new List<KeyValuePair<Renderer, Color>>();

	private List<Renderer> abortedFades = new List<Renderer>();

	// RECUPERADO-AOT FadeHelper::get_Instance token 0x06000408 @0x000fb9dc
	// ADAPTADO-U6: FindObjectOfType -> U4Compat.
	public static FadeHelper Instance
	{
		get
		{
			if (s_Instance == null)
			{
				s_Instance = U4Compat.FindObjectOfType(typeof(FadeHelper)) as FadeHelper;
				if (s_Instance == null)
				{
					UnityEngine.Debug.LogError("Could not find FadeHelper!");
				}
			}
			return s_Instance;
		}
	}

	// RECUPERADO-AOT FadeHelper::IsFading token 0x06000409 @0x000fbadc
	// Breadth-first search for the first Renderer in the hierarchy. As compiled, the loop only ends
	// when a renderer is found (the "No renderer found" branch is unreachable): callers always pass
	// UI hierarchies that contain renderers.
	public bool IsFading(Transform startTransform)
	{
		Renderer component = startTransform.gameObject.GetComponent<Renderer>();
		if (component != null)
		{
			return IsFading(component);
		}
		Renderer renderer = null;
		List<Transform> list = new List<Transform>();
		list.Add(startTransform);
		int count = 0;
		while (list.Count != count || renderer == null)
		{
			count = list.Count;
			List<Transform> list2 = new List<Transform>();
			foreach (Transform item in list)
			{
				list2.Add(item);
			}
			foreach (Transform item2 in list2)
			{
				foreach (Transform item3 in item2)
				{
					renderer = item3.GetComponent<Renderer>();
					if (renderer != null)
					{
						return IsFading(renderer);
					}
					if (!list.Contains(item3))
					{
						list.Add(item3);
					}
				}
			}
		}
		UnityEngine.Debug.Log("No renderer found that could be fading!");
		return false;
	}

	// RECUPERADO-AOT FadeHelper::IsFading token 0x0600040a @0x000fc0ec
	// (predicate <IsFading>c__AnonStorey91::<>m__5 token 0x06000b35)
	public bool IsFading(Renderer r)
	{
		return currentFades.FindIndex((KeyValuePair<Renderer, Color> x) => x.Key == r) != -1;
	}

	// RECUPERADO-AOT FadeHelper::FadeRecursively token 0x0600040b @0x000fc1d8
	public void FadeRecursively(Transform startTransform, float duration, bool fadeIn)
	{
		List<Transform> list = new List<Transform>();
		list.Add(startTransform);
		int count = 0;
		while (list.Count != count)
		{
			count = list.Count;
			List<Transform> list2 = new List<Transform>();
			foreach (Transform item in list)
			{
				list2.Add(item);
			}
			foreach (Transform item2 in list2)
			{
				foreach (Transform item3 in item2)
				{
					if (!list.Contains(item3))
					{
						list.Add(item3);
					}
				}
			}
		}
		Fade(list, duration, fadeIn);
	}

	// RECUPERADO-AOT FadeHelper::SetOpacityRecursively token 0x0600040c @0x000fc744
	public void SetOpacityRecursively(Transform startTransform, float opacity)
	{
		List<Transform> list = new List<Transform>();
		list.Add(startTransform);
		int count = 0;
		while (list.Count != count)
		{
			count = list.Count;
			List<Transform> list2 = new List<Transform>();
			foreach (Transform item in list)
			{
				list2.Add(item);
			}
			foreach (Transform item2 in list2)
			{
				foreach (Transform item3 in item2)
				{
					if (!list.Contains(item3))
					{
						list.Add(item3);
					}
				}
			}
		}
		SetOpacity(list, opacity);
	}

	// RECUPERADO-AOT FadeHelper::SetOpacity token 0x0600040d @0x000fcca8
	public void SetOpacity(List<Transform> transformList, float opacity)
	{
		List<Renderer> list = new List<Renderer>();
		foreach (Transform transform in transformList)
		{
			Renderer component = transform.gameObject.GetComponent<Renderer>();
			if (component != null)
			{
				list.Add(component);
			}
		}
		SetOpacity(list, opacity);
	}

	// RECUPERADO-AOT FadeHelper::SetOpacity token 0x0600040e @0x000fce78
	public void SetOpacity(List<Renderer> renderers, float opacity)
	{
		foreach (Renderer renderer in renderers)
		{
			if (renderer.material.HasProperty("_Color"))
			{
				Color color = renderer.material.color;
				renderer.material.color = new Color(color.r, color.g, color.b, opacity);
			}
		}
	}

	// RECUPERADO-AOT FadeHelper::GetAllChildren token 0x0600040f @0x000fd0f0
	private List<Transform> GetAllChildren(Transform trans)
	{
		List<Transform> list = new List<Transform>();
		if (trans.childCount == 0)
		{
			return list;
		}
		foreach (Transform tran in trans)
		{
			list.Add(tran);
		}
		return list;
	}

	// RECUPERADO-AOT FadeHelper::Fade token 0x06000410 @0x000fd3b4
	public void Fade(Transform t, float duration, bool fadeIn)
	{
		Renderer component = t.gameObject.GetComponent<Renderer>();
		if (component == null)
		{
			UnityEngine.Debug.LogWarning("No Renderer for the FadeIn");
			return;
		}
		List<Renderer> list = new List<Renderer>();
		list.Add(component);
		Fade(list, duration, fadeIn);
	}

	// RECUPERADO-AOT FadeHelper::Fade token 0x06000411 @0x000fd4a8
	public void Fade(Renderer renderer, float duration, bool fadeIn)
	{
		List<Renderer> list = new List<Renderer>();
		list.Add(renderer);
		Fade(list, duration, fadeIn);
	}

	// RECUPERADO-AOT FadeHelper::Fade token 0x06000412 @0x000fd54c
	public void Fade(List<Transform> fadeTransforms, float duration, bool fadeIn)
	{
		List<Renderer> list = new List<Renderer>();
		foreach (Transform fadeTransform in fadeTransforms)
		{
			Renderer component = fadeTransform.GetComponent<Renderer>();
			if (component != null)
			{
				list.Add(component);
			}
		}
		Fade(list, duration, fadeIn);
	}

	// RECUPERADO-AOT FadeHelper::Fade token 0x06000413 @0x000fd718
	// (predicates <Fade>c__AnonStorey92::<>m__6/<>m__7 tokens 0x06000b37/0x06000b38)
	public void Fade(List<Renderer> fadeRenderers, float duration, bool fadeIn)
	{
		List<KeyValuePair<Renderer, Color>> list = new List<KeyValuePair<Renderer, Color>>();
		foreach (Renderer fadeRenderer in fadeRenderers)
		{
			Renderer r = fadeRenderer;
			if (r.material.HasProperty("_Color"))
			{
				Color color = r.material.color;
				Color value = new Color(color.r, color.g, color.b, (!fadeIn) ? 0f : 1f);
				if (list.FindIndex((KeyValuePair<Renderer, Color> x) => x.Key == r) == -1)
				{
					list.Add(new KeyValuePair<Renderer, Color>(r, value));
				}
				int num = currentFades.FindIndex((KeyValuePair<Renderer, Color> x) => x.Key == r);
				if (num != -1)
				{
					UnityEngine.Debug.LogWarning("This fade is already fading -- you might get messed up results.  You have been warned.");
					abortedFades.Add(currentFades[num].Key);
				}
			}
			else
			{
				UnityEngine.Debug.Log("The Shader \"" + r.material.name + "\" on " + r.gameObject.name + "has no color property.");
			}
		}
		CleanNullEntries();
		StartCoroutine(Fader(list, duration));
	}

	// RECUPERADO-AOT FadeHelper::Fader token 0x06000414 @0x000fdd5c
	// (iterator <Fader>c__Iterator29 MoveNext token 0x060008c6 @0x00148e78; predicates <>m__A..<>m__D)
	[DebuggerHidden]
	private IEnumerator Fader(List<KeyValuePair<Renderer, Color>> fades, float duration)
	{
		if (duration == 0f)
		{
			yield break;
		}
		foreach (KeyValuePair<Renderer, Color> fade in fades)
		{
			if (currentFades.FindIndex((KeyValuePair<Renderer, Color> x) => x.Key == fade.Key) == -1)
			{
				currentFades.Add(fade);
			}
		}
		List<KeyValuePair<Renderer, Color>> startColors = new List<KeyValuePair<Renderer, Color>>();
		foreach (KeyValuePair<Renderer, Color> fade2 in fades)
		{
			if (fade2.Key.material.HasProperty("_Color"))
			{
				startColors.Add(new KeyValuePair<Renderer, Color>(fade2.Key, fade2.Key.material.color));
			}
		}
		float timer = 0f;
		while (timer < duration)
		{
			if (abortedFades.Count > 0)
			{
				List<Renderer> abortedFadesClone = new List<Renderer>();
				foreach (Renderer abortedFade in abortedFades)
				{
					abortedFadesClone.Add(abortedFade);
				}
				foreach (Renderer fade3 in abortedFadesClone)
				{
					int index = fades.FindIndex((KeyValuePair<Renderer, Color> x) => x.Key == fade3);
					if (index != -1)
					{
						fades.RemoveAt(index);
						abortedFades.Remove(fade3);
					}
				}
			}
			foreach (KeyValuePair<Renderer, Color> fade4 in fades)
			{
				if (fade4.Key != null && fade4.Key.material.HasProperty("_Color"))
				{
					int index2 = startColors.FindIndex((KeyValuePair<Renderer, Color> x) => x.Key == fade4.Key);
					Color startColor = startColors[index2].Value;
					fade4.Key.material.color = Color.Lerp(startColor, fade4.Value, timer / duration);
				}
			}
			timer += Time.deltaTime;
			yield return null;
		}
		foreach (KeyValuePair<Renderer, Color> fade5 in fades)
		{
			if (fade5.Key != null && fade5.Key.material.HasProperty("_Color"))
			{
				fade5.Key.material.color = fade5.Value;
			}
		}
		foreach (KeyValuePair<Renderer, Color> fade6 in fades)
		{
			int index3 = currentFades.FindIndex((KeyValuePair<Renderer, Color> x) => x.Key == fade6.Key);
			if (index3 != -1)
			{
				currentFades.RemoveAt(index3);
			}
		}
		CleanNullEntries();
	}

	// RECUPERADO-AOT FadeHelper::CleanNullEntries token 0x06000415 @0x000fddd8
	// (predicates <CleanNullEntries>m__8/m__9 tokens 0x06000416/0x06000417)
	private void CleanNullEntries()
	{
		int num = currentFades.FindIndex((KeyValuePair<Renderer, Color> x) => x.Key == null);
		while (num != -1)
		{
			currentFades.RemoveAt(num);
			num = currentFades.FindIndex((KeyValuePair<Renderer, Color> x) => x.Key == null);
		}
	}
}
