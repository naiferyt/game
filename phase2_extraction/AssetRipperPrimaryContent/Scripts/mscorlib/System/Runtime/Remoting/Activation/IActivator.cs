using System.Runtime.InteropServices;

namespace System.Runtime.Remoting.Activation
{
	[ComVisible(true)]
	public interface IActivator
	{
		IConstructionReturnMessage Activate(IConstructionCallMessage msg);
	}
}
