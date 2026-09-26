using UnityEngine.SocialPlatforms.Impl;

namespace UnityEngine.SocialPlatforms.GameCenter
{
	internal struct GcUserProfileData
	{
		public string userName;

		public string userID;

		public int isFriend;

		public Texture2D image;

		public UserProfile ToUserProfile()
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public void AddToArray(ref UserProfile[] array, int number)
		{
		}
	}
}
