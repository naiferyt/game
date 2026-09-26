using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine.SocialPlatforms.Impl;

namespace UnityEngine.SocialPlatforms.GameCenter
{
	public sealed class GameCenterPlatform : ISocialPlatform
	{
		private static Action<bool> s_AuthenticateCallback;

		private static Action<bool> s_FriendsCallback;

		private static Action<IAchievementDescription[]> s_AchievementDescriptionLoaderCallback;

		private static Action<IAchievement[]> s_AchievementLoaderCallback;

		private static Action<bool> s_ProgressCallback;

		private static Action<bool> s_ScoreCallback;

		private static Action<IScore[]> s_ScoreLoaderCallback;

		private static Action<bool> s_LeaderboardCallback;

		private static Action<IUserProfile[]> s_UsersCallback;

		private static AchievementDescription[] s_adCache;

		private static UserProfile[] s_friends;

		private static UserProfile[] s_users;

		private static Action<bool> s_ResetAchievements;

		private static LocalUser m_LocalUser;

		private static List<GcLeaderboard> m_GcBoards;

		public ILocalUser localUser
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		void ISocialPlatform.LoadFriends(ILocalUser user, Action<bool> callback)
		{
		}

		void ISocialPlatform.Authenticate(ILocalUser user, Action<bool> callback)
		{
		}

		private static void ClearAchievementDescriptions(int size)
		{
		}

		private static void SetAchievementDescription(GcAchievementDescriptionData data, int number)
		{
		}

		private static void SetAchievementDescriptionImage(Texture2D texture, int number)
		{
		}

		private static void TriggerAchievementDescriptionCallback()
		{
		}

		private static void AuthenticateCallbackWrapper(int result)
		{
		}

		private static void ClearFriends(int size)
		{
		}

		private static void SetFriends(GcUserProfileData data, int number)
		{
		}

		private static void SetFriendImage(Texture2D texture, int number)
		{
		}

		private static void TriggerFriendsCallbackWrapper(int result)
		{
		}

		private static void AchievementCallbackWrapper(GcAchievementData[] result)
		{
		}

		private static void ProgressCallbackWrapper(bool success)
		{
		}

		private static void ScoreCallbackWrapper(bool success)
		{
		}

		private static void ScoreLoaderCallbackWrapper(GcScoreData[] result)
		{
		}

		private static void PopulateLocalUser()
		{
		}

		public void LoadAchievementDescriptions(Action<IAchievementDescription[]> callback)
		{
		}

		public void ReportProgress(string id, double progress, Action<bool> callback)
		{
		}

		public void LoadAchievements(Action<IAchievement[]> callback)
		{
		}

		public void ReportScore(long score, string board, Action<bool> callback)
		{
		}

		public void LoadScores(string category, Action<IScore[]> callback)
		{
		}

		public void LoadScores(ILeaderboard board, Action<bool> callback)
		{
		}

		private static void LeaderboardCallbackWrapper(bool success)
		{
		}

		public bool GetLoading(ILeaderboard board)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		private bool VerifyAuthentication()
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public void ShowAchievementsUI()
		{
		}

		public void ShowLeaderboardUI()
		{
		}

		private static void ClearUsers(int size)
		{
		}

		private static void SetUser(GcUserProfileData data, int number)
		{
		}

		private static void SetUserImage(Texture2D texture, int number)
		{
		}

		private static void TriggerUsersCallbackWrapper()
		{
		}

		public void LoadUsers(string[] userIds, Action<IUserProfile[]> callback)
		{
		}

		private static void SafeSetUserImage(ref UserProfile[] array, Texture2D texture, int number)
		{
		}

		private static void SafeClearArray(ref UserProfile[] array, int size)
		{
		}

		public ILeaderboard CreateLeaderboard()
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public IAchievement CreateAchievement()
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		private static void TriggerResetAchievementCallback(bool result)
		{
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		internal static extern void Internal_Authenticate();

		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		internal static extern bool Internal_Authenticated();

		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		internal static extern string Internal_UserName();

		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		internal static extern string Internal_UserID();

		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		internal static extern bool Internal_Underage();

		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		internal static extern Texture2D Internal_UserImage();

		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		internal static extern void Internal_LoadFriends();

		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		internal static extern void Internal_LoadAchievementDescriptions();

		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		internal static extern void Internal_LoadAchievements();

		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		internal static extern void Internal_ReportProgress(string id, double progress);

		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		internal static extern void Internal_ReportScore(long score, string category);

		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		internal static extern void Internal_LoadScores(string category);

		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		internal static extern void Internal_ShowAchievementsUI();

		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		internal static extern void Internal_ShowLeaderboardUI();

		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		internal static extern void Internal_LoadUsers(string[] userIds);

		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		internal static extern void Internal_ResetAllAchievements();

		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		internal static extern void Internal_ShowDefaultAchievementBanner(bool value);

		public static void ResetAllAchievements(Action<bool> callback)
		{
		}

		public static void ShowDefaultAchievementCompletionBanner(bool value)
		{
		}

		public static void ShowLeaderboardUI(string leaderboardID, TimeScope timeScope)
		{
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		internal static extern void Internal_ShowSpecificLeaderboardUI(string leaderboardID, int timeScope);
	}
}
