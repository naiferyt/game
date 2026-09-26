using System.Runtime.InteropServices;

namespace UnityEngine
{
	[StructLayout((LayoutKind)0)]
	public sealed class WaitForSeconds : YieldInstruction
	{
		internal float m_Seconds;

		public WaitForSeconds(float seconds)
		{
		}
	}
}
