using System.Runtime.InteropServices;
using System.Text;

namespace System.IO
{
	[ComVisible(true)]
	public static class File
	{
		private static DateTime? defaultLocalFileTime;

		private static DateTime DefaultLocalFileTime
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		public static void Copy(string sourceFileName, string destFileName)
		{
		}

		public static void Copy(string sourceFileName, string destFileName, bool overwrite)
		{
		}

		public static FileStream Create(string path)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public static FileStream Create(string path, int bufferSize)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public static void Delete(string path)
		{
		}

		public static bool Exists(string path)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public static FileAttributes GetAttributes(string path)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public static DateTime GetLastWriteTime(string path)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public static void Move(string sourceFileName, string destFileName)
		{
		}

		public static FileStream Open(string path, FileMode mode)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public static FileStream OpenRead(string path)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public static StreamReader OpenText(string path)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		private static void CheckPathExceptions(string path)
		{
		}

		public static byte[] ReadAllBytes(string path)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public static string[] ReadAllLines(string path)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		private static string[] ReadAllLines(StreamReader reader)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public static void WriteAllBytes(string path, byte[] bytes)
		{
		}

		public static void WriteAllText(string path, string contents)
		{
		}

		public static void WriteAllText(string path, string contents, Encoding encoding)
		{
		}
	}
}
