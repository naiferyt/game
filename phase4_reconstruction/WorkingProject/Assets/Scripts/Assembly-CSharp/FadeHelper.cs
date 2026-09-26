using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeHelper : MonoBehaviour
{
	private static FadeHelper s_Instance;

	private List<KeyValuePair<Renderer, Color>> currentFades;

	private List<Renderer> abortedFades;

	public static FadeHelper Instance
	{
		get
		{
			return default(FadeHelper);
		}
	}

	public bool IsFading(Transform startTransform)
	{
		return default(bool);
	}

	public bool IsFading(Renderer r)
	{
		return default(bool);
	}

	public void FadeRecursively(Transform startTransform, float duration, bool fadeIn)
	{
	}

	public void SetOpacityRecursively(Transform startTransform, float opacity)
	{
	}

	public void SetOpacity(List<Transform> transformList, float opacity)
	{
	}

	public void SetOpacity(List<Renderer> renderers, float opacity)
	{
	}

	private List<Transform> GetAllChildren(Transform trans)
	{
		return default(List<Transform>);
	}

	public void Fade(Transform t, float duration, bool fadeIn)
	{
	}

	public void Fade(Renderer renderer, float duration, bool fadeIn)
	{
	}

	public void Fade(List<Transform> fadeTransforms, float duration, bool fadeIn)
	{
	}

	public void Fade(List<Renderer> fadeRenderers, float duration, bool fadeIn)
	{
	}

	[System.Diagnostics.DebuggerHidden]
	private IEnumerator Fader(List<KeyValuePair<Renderer, Color>> fades, float duration)
	{
		return default(IEnumerator);
	}

	private void CleanNullEntries()
	{
	}
}
