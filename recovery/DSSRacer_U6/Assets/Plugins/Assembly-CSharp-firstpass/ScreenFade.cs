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
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}
	}

	public bool IsFading
	{
		get
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}
	}

	public bool IsFaded
	{
		get
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}
		set
		{
		}
	}

	public float FadedAmount
	{
		get
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}
		set
		{
		}
	}

	public Coroutine Fade(bool toBlack)
	{
		/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
	}

	public Coroutine Fade(bool toBlack, float speed)
	{
		/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
	}

	public void LoadLevelWithFade(string sceneName)
	{
	}

	private void Start()
	{
	}

	[DebuggerHidden]
	private IEnumerator FadeHelper(bool toBlack, float speed)
	{
		/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
	}

	[DebuggerHidden]
	private IEnumerator LoadSceneHelper(string sceneName)
	{
		/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
	}
}
