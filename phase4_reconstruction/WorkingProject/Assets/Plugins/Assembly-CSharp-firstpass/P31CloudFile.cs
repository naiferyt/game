public class P31CloudFile
{
	internal class LocalFileManager
	{
		protected string basePath;

		public LocalFileManager(string basePath)
		{
			this.basePath = basePath;
		}

		public bool exists(string file)
		{
			return default(bool);
		}

		public bool delete(string file)
		{
			return default(bool);
		}

		public virtual bool writeAllBytes(string file, byte[] bytes)
		{
			return default(bool);
		}

		public virtual bool writeAllText(string file, string text)
		{
			return default(bool);
		}

		public byte[] readAllBytes(string file)
		{
			return default(byte[]);
		}

		public string[] readAllLines(string file)
		{
			return default(string[]);
		}

		public string[] listAllFiles()
		{
			return default(string[]);
		}
	}

	internal class CloudFileManager : LocalFileManager
	{
		public CloudFileManager(string basePath)
			: base(basePath)
		{
		}

		public override bool writeAllBytes(string file, byte[] bytes)
		{
			return default(bool);
		}

		public override bool writeAllText(string file, string text)
		{
			return default(bool);
		}
	}

	private static LocalFileManager _file;

	static P31CloudFile()
	{
	}

	public static bool exists(string file)
	{
		return default(bool);
	}

	public static bool delete(string file)
	{
		return default(bool);
	}

	public static bool writeAllBytes(string file, byte[] bytes)
	{
		return default(bool);
	}

	public static bool writeAllText(string file, string text)
	{
		return default(bool);
	}

	public static string[] readAllLines(string file)
	{
		return default(string[]);
	}

	public static byte[] readAllBytes(string file)
	{
		return default(byte[]);
	}

	public static string[] listAllFiles()
	{
		return default(string[]);
	}
}
