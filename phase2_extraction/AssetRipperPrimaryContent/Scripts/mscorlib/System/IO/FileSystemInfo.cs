using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace System.IO
{
	[Serializable]
	[ComVisible(true)]
	public abstract class FileSystemInfo
	{
		protected string FullPath;

		protected string OriginalPath;

		internal MonoIOStat stat;

		internal bool valid;

		public abstract bool Exists { get; }

		public virtual string FullName
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		protected FileSystemInfo()
		{
		}

		protected FileSystemInfo(SerializationInfo info, StreamingContext context)
		{
		}

		internal void Refresh(bool force)
		{
		}

		internal virtual void InternalRefresh()
		{
		}

		internal void CheckPath(string path)
		{
		}
	}
}
