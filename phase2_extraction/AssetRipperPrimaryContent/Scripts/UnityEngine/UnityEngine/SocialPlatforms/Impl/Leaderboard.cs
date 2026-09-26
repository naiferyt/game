using System.Runtime.CompilerServices;

namespace UnityEngine.SocialPlatforms.Impl
{
	public class Leaderboard : ILeaderboard
	{
		private bool m_Loading;

		private IScore m_LocalUserScore;

		private uint m_MaxRange;

		private IScore[] m_Scores;

		private string m_Title;

		private string[] m_UserIDs;

		public string id
		{
			[CompilerGenerated]
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
			[CompilerGenerated]
			set
			{
			}
		}

		public UserScope userScope
		{
			[CompilerGenerated]
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
			[CompilerGenerated]
			set
			{
			}
		}

		public Range range
		{
			[CompilerGenerated]
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
			[CompilerGenerated]
			set
			{
			}
		}

		public TimeScope timeScope
		{
			[CompilerGenerated]
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
			[CompilerGenerated]
			set
			{
			}
		}

		public override string ToString()
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public void SetLocalUserScore(IScore score)
		{
		}

		public void SetMaxRange(uint maxRange)
		{
		}

		public void SetScores(IScore[] scores)
		{
		}

		public void SetTitle(string title)
		{
		}

		public string[] GetUserFilter()
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}
	}
}
