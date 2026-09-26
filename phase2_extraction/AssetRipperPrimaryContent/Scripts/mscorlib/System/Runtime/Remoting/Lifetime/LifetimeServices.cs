using System.Runtime.InteropServices;

namespace System.Runtime.Remoting.Lifetime
{
	[ComVisible(true)]
	public sealed class LifetimeServices
	{
		private static TimeSpan _leaseManagerPollTime;

		private static TimeSpan _leaseTime;

		private static TimeSpan _renewOnCallTime;

		private static TimeSpan _sponsorshipTimeout;

		private static LeaseManager _leaseManager;

		public static TimeSpan LeaseManagerPollTime
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		public static TimeSpan LeaseTime
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		public static TimeSpan RenewOnCallTime
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		public static TimeSpan SponsorshipTimeout
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		static LifetimeServices()
		{
		}

		internal static void TrackLifetime(ServerIdentity identity)
		{
		}

		internal static void StopTrackingLifetime(ServerIdentity identity)
		{
		}
	}
}
