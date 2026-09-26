using System.Collections;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.SceneManagement;

// Persistent full-screen UghSprite that fades out before a level load and back in after it.
// Source listing: recovery/aot_listings/Assembly-CSharp/ScreenFader.txt
public class ScreenFader : MonoBehaviour
{
	private bool loadingLevel;

	private bool fadeComplete;

	// RECUPERADO-AOT ScreenFader::.ctor token 0x060007b2 @0x00140450 (field initializers)
	private string levelToLoad = string.Empty;

	private int levelIndexToLoad = -1;

	private UghSprite spriteToUse;

	[HideInInspector]
	public bool debugStrap;

	private static ScreenFader s_Instance;

	// RECUPERADO-AOT ScreenFader::get_Instance token 0x060007b4 @0x001404c8
	// ADAPTADO-U6: FindObjectOfType -> U4Compat.
	public static ScreenFader Instance
	{
		get
		{
			if (s_Instance == null)
			{
				s_Instance = U4Compat.FindObjectOfType(typeof(ScreenFader)) as ScreenFader;
				if (s_Instance == null)
				{
					UnityEngine.Debug.LogWarning("There needs to be a ScreenFade Object in the scene");
				}
			}
			return s_Instance;
		}
	}

	// RECUPERADO-AOT ScreenFader::CreateScreenFader token 0x060007b5 @0x001405c0
	// ADAPTADO-U6: AddComponent("ScreenFader") -> AddComponent<ScreenFader>().
	public static void CreateScreenFader()
	{
		if (s_Instance == null)
		{
			GameObject gameObject = new GameObject("ScreenFader");
			s_Instance = gameObject.AddComponent<ScreenFader>();
			s_Instance.debugStrap = true;
			UnityEngine.Debug.LogWarning("Creating a ScreenFader for the scene");
		}
	}

	// RECUPERADO-AOT ScreenFader::Start token 0x060007b6 @0x001406e8
	private void Start()
	{
		spriteToUse = GetComponent<UghSprite>();
		if (spriteToUse == null)
		{
			UnityEngine.Debug.Log("ScreenFader is not attached to an UghSprite!!");
		}
		base.gameObject.transform.localPosition = new Vector3(0f, 0f, -9f);
		if (s_Instance != null && !debugStrap)
		{
			UnityEngine.Debug.Log("Destroying ScreenFader Stuff");
			if (spriteToUse != null)
			{
				Object.Destroy(spriteToUse.gameObject);
			}
			Object.Destroy(base.gameObject);
			return;
		}
		Object.DontDestroyOnLoad(base.gameObject);
		if (spriteToUse != null)
		{
			Object.DontDestroyOnLoad(spriteToUse.gameObject);
			Color color = spriteToUse.normal.material.color;
			color.a = 1f;
			spriteToUse.normal.material.color = color;
			spriteToUse.gameObject.SetActive(true);
			FadeIn();
		}
	}

	// RECUPERADO-AOT ScreenFader::Update token 0x060007b7 @0x00140994
	// ADAPTADO-U6: Application.LoadLevel -> SceneManager.LoadScene.
	private void Update()
	{
		if (loadingLevel && fadeComplete)
		{
			if (levelToLoad == string.Empty)
			{
				SceneManager.LoadScene(levelIndexToLoad);
			}
			else
			{
				SceneManager.LoadScene(levelToLoad);
			}
			loadingLevel = false;
		}
	}

	// RECUPERADO-AOT ScreenFader::LoadLevel token 0x060007b8 @0x00140a18
	public void LoadLevel(string levelName)
	{
		levelToLoad = levelName;
		fadeComplete = false;
		loadingLevel = true;
		StartCoroutine(FadeOutHelper());
	}

	// RECUPERADO-AOT ScreenFader::LoadLevel token 0x060007b9 @0x00140a84
	public void LoadLevel(int levelIndex)
	{
		levelIndexToLoad = levelIndex;
		LoadLevel(string.Empty);
	}

	// RECUPERADO-AOT ScreenFader::FadeInHelper token 0x060007ba @0x00140ad8
	// (iterator <FadeInHelper>c__Iterator8C MoveNext token 0x06000b24 @0x00165e6c)
	[DebuggerHidden]
	private IEnumerator FadeInHelper()
	{
		if (spriteToUse != null)
		{
			Color alpha = spriteToUse.normal.material.color;
			alpha.a = 1f;
			while (alpha.a > 0f)
			{
				alpha = spriteToUse.normal.material.color;
				alpha.a -= Time.deltaTime;
				spriteToUse.normal.material.color = alpha;
				yield return new WaitForFixedUpdate();
			}
		}
		fadeComplete = true;
		yield return 0;
	}

	// RECUPERADO-AOT ScreenFader::FadeOutHelper token 0x060007bb @0x00140b20
	// (iterator <FadeOutHelper>c__Iterator8D MoveNext token 0x06000b2a @0x001661c8)
	[DebuggerHidden]
	private IEnumerator FadeOutHelper()
	{
		if (spriteToUse != null)
		{
			Color alpha = spriteToUse.normal.material.color;
			alpha.a = 0f;
			while (alpha.a < 1f)
			{
				alpha.a += Time.deltaTime;
				spriteToUse.normal.material.color = alpha;
				yield return new WaitForFixedUpdate();
			}
		}
		fadeComplete = true;
		yield return 0;
	}

	// RECUPERADO-AOT ScreenFader::FadeIn token 0x060007bc @0x00140b68
	public void FadeIn()
	{
		fadeComplete = false;
		loadingLevel = false;
		StartCoroutine(FadeInHelper());
	}

	// RECUPERADO-AOT ScreenFader::FadeOut token 0x060007bd @0x00140bc8
	public void FadeOut()
	{
		fadeComplete = false;
		loadingLevel = false;
		StartCoroutine(FadeOutHelper());
	}

	// RECUPERADO-AOT ScreenFader::OnLevelWasLoaded token 0x060007be @0x00140c28
	// ADAPTADO-U6: OnLevelWasLoaded no longer exists; U4Compat's sceneLoaded bridge sends OnLevelWasLoadedU6.
	private void OnLevelWasLoadedU6(int level)
	{
		fadeComplete = false;
		StartCoroutine(FadeInHelper());
	}
}
