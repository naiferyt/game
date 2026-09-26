using System;
using UnityEngine;

// Per-component Vector3 versions of the Mathfx interpolations, plus small helpers.
// Source listing: recovery/aot_listings/Assembly-CSharp-firstpass/Vector3x.txt
public class Vector3x
{
	// RECUPERADO-AOT Vector3x::.cctor token 0x060001ea @0x00028750
	public static Vector3 tiny = new Vector3(0.001f, 0.001f, 0.001f);

	// RECUPERADO-AOT Vector3x::Sinerp token 0x060001eb @0x0002882c
	public static Vector3 Sinerp(Vector3 start, Vector3 end, float value)
	{
		return new Vector3(Mathfx.Sinerp(start.x, end.x, value), Mathfx.Sinerp(start.y, end.y, value), Mathfx.Sinerp(start.z, end.z, value));
	}

	// RECUPERADO-AOT Vector3x::Coserp token 0x060001ec @0x000289e4
	public static Vector3 Coserp(Vector3 start, Vector3 end, float value)
	{
		return new Vector3(Mathfx.Coserp(start.x, end.x, value), Mathfx.Coserp(start.y, end.y, value), Mathfx.Coserp(start.z, end.z, value));
	}

	// RECUPERADO-AOT Vector3x::Hermite token 0x060001ed @0x00028b9c
	public static Vector3 Hermite(Vector3 start, Vector3 end, float value)
	{
		return new Vector3(Mathfx.Hermite(start.x, end.x, value), Mathfx.Hermite(start.y, end.y, value), Mathfx.Hermite(start.z, end.z, value));
	}

	// RECUPERADO-AOT Vector3x::Berp token 0x060001ee @0x00028d54
	public static Vector3 Berp(Vector3 start, Vector3 end, float value)
	{
		return new Vector3(Mathfx.Berp(start.x, end.x, value), Mathfx.Berp(start.y, end.y, value), Mathfx.Berp(start.z, end.z, value));
	}

	// RECUPERADO-AOT Vector3x::Inverse token 0x060001ef @0x00028f0c
	public static Vector3 Inverse(Vector3 a)
	{
		return new Vector3(1f / a.x, 1f / a.y, 1f / a.z);
	}

	// RECUPERADO-AOT Vector3x::FromString token 0x060001f0 @0x00029018
	// Parses "(x, y, z)" (Vector3.ToString format).
	public static Vector3 FromString(string vectorString)
	{
		char[] separator = new char[1] { ',' };
		string[] array = vectorString.Trim('(', ' ', ')').Split(separator);
		Vector3 zero = Vector3.zero;
		zero.x = Convert.ToSingle(array[0]);
		zero.y = Convert.ToSingle(array[1]);
		zero.z = Convert.ToSingle(array[2]);
		return zero;
	}
}
