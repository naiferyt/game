using System;
using UnityEngine;

[AddComponentMenu("")]
public class JCloudDocument : MonoBehaviour
{
	public static bool AcceptJailbrokenDevices;

	protected static int NewCloudDocument(string path, bool isDirectory)
	{
		return default(int);
	}

	protected static void DismissCloudDocument(int uid)
	{
	}

	public static bool FileExists(string path)
	{
		return default(bool);
	}

	public static bool FileDelete(string path)
	{
		return default(bool);
	}

	public static bool FileWriteAllBytes(string path, byte[] bytes)
	{
		return default(bool);
	}

	public static byte[] FileReadAllBytes(string path)
	{
		return default(byte[]);
	}

	public static bool FileModificationDate(string path, out DateTime modificationDate)
	{
		modificationDate = default(DateTime);
		return default(bool);
	}

	public static bool FileCopy(string sourcePath, string destinationPath, bool overwrite)
	{
		return default(bool);
	}

	public static bool FileMove(string sourcePath, string destinationPath, bool overwrite)
	{
		return default(bool);
	}

	public static bool DirectoryCreate(string path)
	{
		return default(bool);
	}

	public static bool DirectoryExists(string path)
	{
		return default(bool);
	}

	public static bool DirectoryDelete(string path)
	{
		return default(bool);
	}

	public static string[] DirectoryGetFiles(string path)
	{
		return default(string[]);
	}

	public static string[] DirectoryGetDirectories(string path)
	{
		return default(string[]);
	}

	public static bool DirectoryModificationDate(string path, out DateTime modificationDate)
	{
		modificationDate = default(DateTime);
		return default(bool);
	}

	public static bool DirectoryCopy(string sourcePath, string destinationPath, bool overwrite)
	{
		return default(bool);
	}

	public static bool DirectoryMove(string sourcePath, string destinationPath, bool overwrite)
	{
		return default(bool);
	}

	public static bool PollCloudDocumentAvailability()
	{
		return default(bool);
	}
}
