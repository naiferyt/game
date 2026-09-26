using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace System.IO
{
	[Serializable]
	[ComVisible(true)]
	public sealed class DirectoryInfo : FileSystemInfo
	{
		private string current;

		private string parent;

		public override bool Exists
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		public DirectoryInfo Parent
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		public DirectoryInfo(string path)
		{
		}

		internal DirectoryInfo(string path, bool simpleOriginalPath)
		{
		}

		private DirectoryInfo(SerializationInfo info, StreamingContext context)
		{
		}

		private void Initialize()
		{
		}

		public void Create()
		{
		}

		public override string ToString()
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}
	}
}
