using System.Runtime.InteropServices;
using System.Threading;

namespace System
{
	[ComVisible(true)]
	public interface IAsyncResult
	{
		WaitHandle AsyncWaitHandle { get; }
	}
}
