using System.Collections;
using System.Diagnostics;
using UnityEngine;

public class ScreenFade : MonoBehaviour
{
	private static ScreenFade s_Instance;

	public bool startFaded;

	public GameObject inputBlocker;

	private bool isFading;

	private bool initialized;

	private Renderer myRenderer;

	private Material myMaterial;

	private Color myColor;

	private float fadedAmount;

	public static ScreenFade Instance
	{
		get
		{
			RecoveryPending.Hit("ScreenFade.get_Instance");
			return default(ScreenFade);
		}
	}

	public bool IsFading
	{
		get
		{
			RecoveryPending.Hit("ScreenFade.get_IsFading");
			return default(bool);
		}
	}

	public bool IsFaded
	{
		get
		{
			RecoveryPending.Hit("ScreenFade.get_IsFaded");
			return default(bool);
		}
		set
		{
			RecoveryPending.Hit("ScreenFade.set_IsFaded");
		}
	}

	public float FadedAmount
	{
		get
		{
			RecoveryPending.Hit("ScreenFade.get_FadedAmount");
			return default(float);
		}
		set
		{
			RecoveryPending.Hit("ScreenFade.set_FadedAmount");
		}
	}

	public Coroutine Fade(bool toBlack)
	{
		RecoveryPending.Hit("ScreenFade.Fade");
		return default(Coroutine);
	}

	public Coroutine Fade(bool toBlack, float speed)
	{
		RecoveryPending.Hit("ScreenFade.Fade");
		return default(Coroutine);
	}

	public void LoadLevelWithFade(string sceneName)
	{
		RecoveryPending.Hit("ScreenFade.LoadLevelWithFade");
	}

	private void Start()
	{
		RecoveryPending.Hit("ScreenFade.Start");
	}

	[DebuggerHidden]
	private IEnumerator FadeHelper(bool toBlack, float speed)
	{
		RecoveryPending.Hit("ScreenFade.FadeHelper");
		yield break;
	}

	[DebuggerHidden]
	private IEnumerator LoadSceneHelper(string sceneName)
	{
		RecoveryPending.Hit("ScreenFade.LoadSceneHelper");
		yield break;
	}
}
