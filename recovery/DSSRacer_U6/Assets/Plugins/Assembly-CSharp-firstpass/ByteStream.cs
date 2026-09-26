using System.IO;
using UnityEngine;

public class ByteStream
{
	private const int kDefaultMemoryStreamSize = 256;

	private MemoryStream ms;

	private BinaryWriter bw;

	private BinaryReader br;

	private bool isWriting;

	public byte[] Bytes
	{
		get
		{
			RecoveryPending.Hit("ByteStream.get_Bytes");
			return default(byte[]);
		}
	}

	public ByteStream()
	{
		RecoveryPending.Hit("ByteStream..ctor");
	}

	public ByteStream(byte[] bytes)
	{
		RecoveryPending.Hit("ByteStream..ctor");
	}

	public void Serialize(ref float a)
	{
		RecoveryPending.Hit("ByteStream.Serialize");
	}

	public void Serialize(ref bool a)
	{
		RecoveryPending.Hit("ByteStream.Serialize");
	}

	public void Serialize(ref uint a)
	{
		RecoveryPending.Hit("ByteStream.Serialize");
	}

	public void Serialize(ref int a)
	{
		RecoveryPending.Hit("ByteStream.Serialize");
	}

	public void Serialize(ref long a)
	{
		RecoveryPending.Hit("ByteStream.Serialize");
	}

	public void Serialize(ref ulong a)
	{
		RecoveryPending.Hit("ByteStream.Serialize");
	}

	public void Serialize(ref Vector3 a)
	{
		RecoveryPending.Hit("ByteStream.Serialize");
	}

	public void Serialize(ref Quaternion a)
	{
		RecoveryPending.Hit("ByteStream.Serialize");
	}

	public void Serialize(ref string a)
	{
		RecoveryPending.Hit("ByteStream.Serialize");
	}

	public void Serialize<T>(T a) where T : struct
	{
	}
}
