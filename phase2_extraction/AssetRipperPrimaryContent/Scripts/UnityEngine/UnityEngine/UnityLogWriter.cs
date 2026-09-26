using System.IO;
using System.Runtime.CompilerServices;
using System.Text;

namespace UnityEngine
{
	internal sealed class UnityLogWriter : TextWriter
	{
		public override Encoding Encoding
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		public static extern void WriteStringToUnityLog(string s);

		public static void Init()
		{
		}

		public override void Write(char value)
		{
		}

		public override void Write(string s)
		{
		}
	}
}
