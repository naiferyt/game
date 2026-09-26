using UnityEngine;

public class CartPrimaryTextureProfile : MonoBehaviour
{
	private static CartPrimaryTextureProfile s_Instance;

	private CompositeProfile compositeProfile;

	public static CompositeProfile profile
	{
		get
		{
			RecoveryPending.Hit("CartPrimaryTextureProfile.get_profile");
			return default(CompositeProfile);
		}
	}

	private void Awake()
	{
		RecoveryPending.Hit("CartPrimaryTextureProfile.Awake");
	}
}
