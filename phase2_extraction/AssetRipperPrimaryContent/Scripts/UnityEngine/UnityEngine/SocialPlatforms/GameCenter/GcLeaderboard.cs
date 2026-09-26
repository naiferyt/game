using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnityEngine.SocialPlatforms.Impl;

namespace UnityEngine.SocialPlatforms.GameCenter
{
	[StructLayout((LayoutKind)0)]
	internal sealed class GcLeaderboard
	{
		private IntPtr m_InternalLeaderboard;

		private Leaderboard m_GenericLeaderboard;

		internal GcLeaderboard(Leaderboard board)
		{
		}

		~GcLeaderboard()
		{
		}

		internal bool Contains(Leaderboard board)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		internal void SetScores(GcScoreData[] scoreDatas)
		{
		}

		internal void SetLocalScore(GcScoreData scoreData)
		{
		}

		internal void SetMaxRange(uint maxRange)
		{
		}

		internal void SetTitle(string title)
		{
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		internal extern void Internal_LoadScores(string category, int from, int count, int playerScope, int timeScope);

		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		internal extern void Internal_LoadScoresWithUsers(string category, int timeScope, string[] userIDs);

		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		internal extern bool Loading();

		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		internal extern void Dispose();
	}
}
