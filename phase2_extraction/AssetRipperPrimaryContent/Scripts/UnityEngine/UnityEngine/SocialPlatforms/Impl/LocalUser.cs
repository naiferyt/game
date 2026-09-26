namespace UnityEngine.SocialPlatforms.Impl
{
	public class LocalUser : UserProfile, ILocalUser, IUserProfile
	{
		private IUserProfile[] m_Friends;

		private bool m_Authenticated;

		private bool m_Underage;

		public bool authenticated
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		public void SetFriends(IUserProfile[] friends)
		{
		}

		public void SetAuthenticated(bool value)
		{
		}

		public void SetUnderage(bool value)
		{
		}
	}
}
