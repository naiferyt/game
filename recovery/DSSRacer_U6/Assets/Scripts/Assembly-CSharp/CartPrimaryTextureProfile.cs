using UnityEngine;

// Global holder (EnsureGlobals) of the CompositeProfile used to build the kart texture atlas.
// Source listing: recovery/aot_listings/Assembly-CSharp/CartPrimaryTextureProfile.txt
public class CartPrimaryTextureProfile : MonoBehaviour
{
	private static CartPrimaryTextureProfile s_Instance;

	private CompositeProfile compositeProfile;

	// RECUPERADO-AOT CartPrimaryTextureProfile::get_profile token 0x06000233 @0x000e3b14
	public static CompositeProfile profile
	{
		get
		{
			if (s_Instance == null)
			{
				Debug.LogError("Could not find instance of CartPrimaryTextureProfile");
				return null;
			}
			return s_Instance.compositeProfile;
		}
	}

	// RECUPERADO-AOT CartPrimaryTextureProfile::Awake token 0x06000234 @0x000e3b90
	private void Awake()
	{
		if (s_Instance != null)
		{
			Object.Destroy(base.gameObject);
			return;
		}
		s_Instance = this;
		compositeProfile = GetComponent<CompositeProfile>();
		Object.DontDestroyOnLoad(base.gameObject);
	}
}
