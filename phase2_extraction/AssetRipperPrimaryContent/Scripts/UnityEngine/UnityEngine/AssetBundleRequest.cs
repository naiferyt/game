using System;
using System.Runtime.InteropServices;

namespace UnityEngine
{
	[StructLayout((LayoutKind)0)]
	public sealed class AssetBundleRequest : AsyncOperation
	{
		internal AssetBundle m_AssetBundle;

		internal string m_Path;

		internal Type m_Type;
	}
}
