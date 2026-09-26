using System;
using System.Runtime.CompilerServices;

namespace UnityEngine.SocialPlatforms.Impl
{
	public class Score : IScore
	{
		private DateTime m_Date;

		private string m_FormattedValue;

		private string m_UserID;

		private int m_Rank;

		public string leaderboardID
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

		public long value
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

		public Score(string leaderboardID, long value)
		{
		}

		public Score(string leaderboardID, long value, string userID, DateTime date, string formattedValue, int rank)
		{
		}

		public override string ToString()
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}
	}
}
