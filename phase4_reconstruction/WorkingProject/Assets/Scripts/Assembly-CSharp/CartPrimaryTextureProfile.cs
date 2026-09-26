using UnityEngine;

public class CartPrimaryTextureProfile : MonoBehaviour
{
	private static CartPrimaryTextureProfile s_Instance;

	private CompositeProfile compositeProfile;

	public static CompositeProfile profile
	{
		get
		{
			return default(CompositeProfile);
		}
	}

	private void Awake()
	{
	}
}
