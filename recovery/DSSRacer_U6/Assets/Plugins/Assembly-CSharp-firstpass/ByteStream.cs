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
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}
	}

	public ByteStream()
	{
	}

	public ByteStream(byte[] bytes)
	{
	}

	public void Serialize(ref float a)
	{
	}

	public void Serialize(ref bool a)
	{
	}

	public void Serialize(ref uint a)
	{
	}

	public void Serialize(ref int a)
	{
	}

	public void Serialize(ref long a)
	{
	}

	public void Serialize(ref ulong a)
	{
	}

	public void Serialize(ref Vector3 a)
	{
	}

	public void Serialize(ref Quaternion a)
	{
	}

	public void Serialize(ref string a)
	{
	}

	public void Serialize<T>(T a) where T : struct
	{
	}
}
