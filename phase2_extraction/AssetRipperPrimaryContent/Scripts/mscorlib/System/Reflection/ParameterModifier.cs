using System.Runtime.InteropServices;

namespace System.Reflection
{
	[Serializable]
	[ComVisible(true)]
	[DefaultMember("Item")]
	public struct ParameterModifier
	{
		private bool[] _byref;
	}
}
