using System;
using System.Runtime.CompilerServices;
using UnityEngine.Internal;

namespace UnityEngine
{
	public sealed class Texture2D : Texture
	{
		public Texture2D(int width, int height)
		{
		}

		public Texture2D(int width, int height, TextureFormat format, bool mipmap)
		{
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		private static extern void Internal_Create([Writable] Texture2D mono, int width, int height, TextureFormat format, bool mipmap, bool linear, IntPtr nativeTex);

		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		public extern void SetPixels32(Color32[] colors, [DefaultValue("0")] int miplevel);

		[ExcludeFromDocs]
		public void SetPixels32(Color32[] colors)
		{
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		public extern Color32[] GetPixels32([DefaultValue("0")] int miplevel);

		[ExcludeFromDocs]
		public Color32[] GetPixels32()
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		public extern void Apply([DefaultValue("true")] bool updateMipmaps, [DefaultValue("false")] bool makeNoLongerReadable);

		[ExcludeFromDocs]
		public void Apply()
		{
		}
	}
}
