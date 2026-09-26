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
			RecoveryPending.Hit("FadeHelper.get_Instance");
			return default(FadeHelper);
		}
	}

	public bool IsFading(Transform startTransform)
	{
		RecoveryPending.Hit("FadeHelper.IsFading");
		return default(bool);
	}

	public bool IsFading(Renderer r)
	{
		RecoveryPending.Hit("FadeHelper.IsFading");
		return default(bool);
	}

	public void FadeRecursively(Transform startTransform, float duration, bool fadeIn)
	{
		RecoveryPending.Hit("FadeHelper.FadeRecursively");
	}

	public void SetOpacityRecursively(Transform startTransform, float opacity)
	{
		RecoveryPending.Hit("FadeHelper.SetOpacityRecursively");
	}

	public void SetOpacity(List<Transform> transformList, float opacity)
	{
		RecoveryPending.Hit("FadeHelper.SetOpacity");
	}

	public void SetOpacity(List<Renderer> renderers, float opacity)
	{
		RecoveryPending.Hit("FadeHelper.SetOpacity");
	}

	private List<Transform> GetAllChildren(Transform trans)
	{
		RecoveryPending.Hit("FadeHelper.GetAllChildren");
		return default(List<Transform>);
	}

	public void Fade(Transform t, float duration, bool fadeIn)
	{
		RecoveryPending.Hit("FadeHelper.Fade");
	}

	public void Fade(Renderer renderer, float duration, bool fadeIn)
	{
		RecoveryPending.Hit("FadeHelper.Fade");
	}

	public void Fade(List<Transform> fadeTransforms, float duration, bool fadeIn)
	{
		RecoveryPending.Hit("FadeHelper.Fade");
	}

	public void Fade(List<Renderer> fadeRenderers, float duration, bool fadeIn)
	{
		RecoveryPending.Hit("FadeHelper.Fade");
	}

	[DebuggerHidden]
	private IEnumerator Fader(List<KeyValuePair<Renderer, Color>> fades, float duration)
	{
		RecoveryPending.Hit("FadeHelper.Fader");
		yield break;
	}

	private void CleanNullEntries()
	{
		RecoveryPending.Hit("FadeHelper.CleanNullEntries");
	}
}
