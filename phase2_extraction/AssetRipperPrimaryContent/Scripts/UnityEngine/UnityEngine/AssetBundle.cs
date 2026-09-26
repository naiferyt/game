using System;
using System.Runtime.CompilerServices;

namespace UnityEngine
{
	public sealed class AssetBundle : Object
	{
		public extern Object mainAsset
		{
			[MethodImpl(MethodImplOptions.InternalCall)]
			[WrapperlessIcall]
			get;
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		public extern Object[] LoadAll(Type type);

		public Object[] LoadAll()
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		public extern void Unload(bool unloadAllLoadedObjects);
	}
}
