using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
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
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}
	}

	public bool IsFading(Transform startTransform)
	{
		/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
	}

	public bool IsFading(Renderer r)
	{
		/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
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
		/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
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

	[DebuggerHidden]
	private IEnumerator Fader(List<KeyValuePair<Renderer, Color>> fades, float duration)
	{
		/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
	}

	private void CleanNullEntries()
	{
	}
}
