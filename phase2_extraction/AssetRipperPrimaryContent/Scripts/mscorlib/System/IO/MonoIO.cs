using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace System.IO
{
	internal sealed class MonoIO
	{
		public static readonly FileAttributes InvalidFileAttributes;

		public static readonly IntPtr InvalidHandle;

		public static extern IntPtr ConsoleOutput
		{
			[MethodImpl(MethodImplOptions.InternalCall)]
			get;
		}

		public static extern IntPtr ConsoleInput
		{
			[MethodImpl(MethodImplOptions.InternalCall)]
			get;
		}

		public static extern IntPtr ConsoleError
		{
			[MethodImpl(MethodImplOptions.InternalCall)]
			get;
		}

		public static extern char VolumeSeparatorChar
		{
			[MethodImpl(MethodImplOptions.InternalCall)]
			get;
		}

		public static extern char DirectorySeparatorChar
		{
			[MethodImpl(MethodImplOptions.InternalCall)]
			get;
		}

		public static extern char AltDirectorySeparatorChar
		{
			[MethodImpl(MethodImplOptions.InternalCall)]
			get;
		}

		public static extern char PathSeparator
		{
			[MethodImpl(MethodImplOptions.InternalCall)]
			get;
		}

		public static Exception GetException(MonoIOError error)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public static Exception GetException(string path, MonoIOError error)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern bool CreateDirectory(string path, out MonoIOError error);

		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern bool RemoveDirectory(string path, out MonoIOError error);

		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern string[] GetFileSystemEntries(string path, string path_with_pattern, int attrs, int mask, out MonoIOError error);

		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern string GetCurrentDirectory(out MonoIOError error);

		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern bool SetCurrentDirectory(string path, out MonoIOError error);

		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern bool MoveFile(string path, string dest, out MonoIOError error);

		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern bool CopyFile(string path, string dest, bool overwrite, out MonoIOError error);

		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern bool DeleteFile(string path, out MonoIOError error);

		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern FileAttributes GetFileAttributes(string path, out MonoIOError error);

		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern MonoFileType GetFileType(IntPtr handle, out MonoIOError error);

		public static bool Exists(string path, out MonoIOError error)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public static bool ExistsFile(string path, out MonoIOError error)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public static bool ExistsDirectory(string path, out MonoIOError error)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		public static bool ExistsSymlink(string path, out MonoIOError error)
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern bool GetFileStat(string path, out MonoIOStat stat, out MonoIOError error);

		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern IntPtr Open(string filename, FileMode mode, FileAccess access, FileShare share, FileOptions options, out MonoIOError error);

		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern bool Close(IntPtr handle, out MonoIOError error);

		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern int Read(IntPtr handle, byte[] dest, int dest_offset, int count, out MonoIOError error);

		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern int Write(IntPtr handle, [In] byte[] src, int src_offset, int count, out MonoIOError error);

		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern long Seek(IntPtr handle, long offset, SeekOrigin origin, out MonoIOError error);

		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern long GetLength(IntPtr handle, out MonoIOError error);

		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern bool SetLength(IntPtr handle, long length, out MonoIOError error);
	}
}
