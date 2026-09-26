using System.Collections;
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
			return default(ScreenFade);
		}
	}

	public bool IsFading
	{
		get
		{
			return default(bool);
		}
	}

	public bool IsFaded
	{
		get
		{
			return default(bool);
		}
		set
		{
		}
	}

	public float FadedAmount
	{
		get
		{
			return default(float);
		}
		set
		{
		}
	}

	public Coroutine Fade(bool toBlack)
	{
		return default(Coroutine);
	}

	public Coroutine Fade(bool toBlack, float speed)
	{
		return default(Coroutine);
	}

	public void LoadLevelWithFade(string sceneName)
	{
	}

	private void Start()
	{
	}

	[System.Diagnostics.DebuggerHidden]
	private IEnumerator FadeHelper(bool toBlack, float speed)
	{
		return default(IEnumerator);
	}

	[System.Diagnostics.DebuggerHidden]
	private IEnumerator LoadSceneHelper(string sceneName)
	{
		return default(IEnumerator);
	}
}
