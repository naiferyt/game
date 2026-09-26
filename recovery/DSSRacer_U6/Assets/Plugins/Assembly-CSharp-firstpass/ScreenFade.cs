using System.Collections;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.SceneManagement;

// Full-screen black quad that fades in/out; blocks input while fading.
// Source listing: recovery/aot_listings/Assembly-CSharp-firstpass/ScreenFade.txt
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

	// RECUPERADO-AOT ScreenFade::get_Instance token 0x06000404 @0x0003f924
	// ADAPTADO-U6: FindObjectOfType -> U4Compat.
	public static ScreenFade Instance
	{
		get
		{
			if (s_Instance == null)
			{
				s_Instance = U4Compat.FindObjectOfType(typeof(ScreenFade)) as ScreenFade;
				if (s_Instance == null)
				{
					UnityEngine.Debug.Log("Error: There needs to be exactly one ScreenFade in the scene.");
				}
			}
			return s_Instance;
		}
	}

	// RECUPERADO-AOT ScreenFade::get_IsFading token 0x06000405 @0x0003fa1c
	public bool IsFading
	{
		get
		{
			return isFading;
		}
	}

	// RECUPERADO-AOT ScreenFade::get_IsFaded token 0x06000406 @0x0003fa50
	// RECUPERADO-AOT ScreenFade::set_IsFaded token 0x06000407 @0x0003fab4
	public bool IsFaded
	{
		get
		{
			return fadedAmount != 0f;
		}
		set
		{
			if (fadedAmount == 0f && value)
			{
				Fade(true);
			}
			else if (fadedAmount != 1f && !value)
			{
				Fade(false);
			}
		}
	}

	// RECUPERADO-AOT ScreenFade::get_FadedAmount token 0x06000408 @0x0003fb60
	// RECUPERADO-AOT ScreenFade::set_FadedAmount token 0x06000409 @0x0003fba0
	public float FadedAmount
	{
		get
		{
			return fadedAmount;
		}
		set
		{
			fadedAmount = value;
			if (!initialized)
			{
				myRenderer = GetComponent<Renderer>();
				myMaterial = myRenderer.material;
				myColor = myMaterial.color;
				initialized = true;
			}
			if (fadedAmount > 0f)
			{
				myRenderer.enabled = true;
				myColor.a = Mathf.Clamp01(value);
				myMaterial.color = myColor;
			}
			else
			{
				myRenderer.enabled = false;
			}
		}
	}

	// RECUPERADO-AOT ScreenFade::Fade token 0x0600040a @0x0003fd20
	public Coroutine Fade(bool toBlack)
	{
		return Fade(toBlack, 0.2f);
	}

	// RECUPERADO-AOT ScreenFade::Fade token 0x0600040b @0x0003fd78
	public Coroutine Fade(bool toBlack, float speed)
	{
		return StartCoroutine(FadeHelper(toBlack, speed));
	}

	// RECUPERADO-AOT ScreenFade::LoadLevelWithFade token 0x0600040c @0x0003fdd8
	public void LoadLevelWithFade(string sceneName)
	{
		StartCoroutine(LoadSceneHelper(sceneName));
	}

	// RECUPERADO-AOT ScreenFade::Start token 0x0600040d @0x0003fe20
	private void Start()
	{
		FadedAmount = ((!startFaded) ? 0f : 1f);
	}

	// RECUPERADO-AOT ScreenFade::FadeHelper token 0x0600040e @0x0003fe9c
	// (iterator <FadeHelper>c__Iterator MoveNext token 0x06000606 @0x0005e2f8)
	[DebuggerHidden]
	private IEnumerator FadeHelper(bool toBlack, float speed)
	{
		GameObject blocker = Object.Instantiate(inputBlocker, new Vector3(0f, 0f, -9f), Quaternion.identity) as GameObject;
		float startValue = fadedAmount;
		float length = speed;
		float timer = 0f;
		isFading = true;
		while (timer < length)
		{
			timer += Time.deltaTime;
			FadedAmount = Mathfx.Hermite(startValue, (!toBlack) ? 0f : 1f, Mathf.Clamp01(timer / length));
			yield return 0;
		}
		isFading = false;
		Object.Destroy(blocker);
	}

	// RECUPERADO-AOT ScreenFade::LoadSceneHelper token 0x0600040f @0x0003ff18
	// (iterator MoveNext token 0x0600060c @0x0005e748)
	// ADAPTADO-U6: Application.LoadLevel -> SceneManager.LoadScene.
	[DebuggerHidden]
	private IEnumerator LoadSceneHelper(string sceneName)
	{
		yield return Instance.Fade(true);
		SceneManager.LoadScene(sceneName);
	}
}
