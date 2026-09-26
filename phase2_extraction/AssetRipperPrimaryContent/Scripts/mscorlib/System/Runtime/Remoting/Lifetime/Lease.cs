using System.Collections;

namespace System.Runtime.Remoting.Lifetime
{
	internal class Lease : MarshalByRefObject, ILease
	{
		private delegate TimeSpan RenewalDelegate(ILease lease);

		private DateTime _leaseExpireTime;

		private LeaseState _currentState;

		private TimeSpan _initialLeaseTime;

		private TimeSpan _renewOnCallTime;

		private TimeSpan _sponsorshipTimeout;

		private ArrayList _sponsors;

		private Queue _renewingSponsors;

		private RenewalDelegate _renewalDelegate;

		public TimeSpan CurrentLeaseTime
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		public LeaseState CurrentState
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		public TimeSpan InitialLeaseTime
		{
			set
			{
			}
		}

		public TimeSpan RenewOnCallTime
		{
			set
			{
			}
		}

		public TimeSpan SponsorshipTimeout
		{
			set
			{
			}
		}

		public void Activate()
		{
		}

		public TimeSpan Renew(TimeSpan renewalTime)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public void Unregister(ISponsor obj)
		{
		}

		internal void UpdateState()
		{
		}

		private void CheckNextSponsor()
		{
		}

		private void ProcessSponsorResponse(object state, bool timedOut)
		{
		}
	}
}
