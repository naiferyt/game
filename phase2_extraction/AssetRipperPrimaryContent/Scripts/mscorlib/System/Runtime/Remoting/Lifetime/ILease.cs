using System.Runtime.InteropServices;

namespace System.Runtime.Remoting.Lifetime
{
	[ComVisible(true)]
	public interface ILease
	{
		TimeSpan CurrentLeaseTime { get; }

		LeaseState CurrentState { get; }

		TimeSpan InitialLeaseTime { set; }

		TimeSpan RenewOnCallTime { set; }

		TimeSpan SponsorshipTimeout { set; }

		TimeSpan Renew(TimeSpan renewalTime);

		void Unregister(ISponsor obj);
	}
}
