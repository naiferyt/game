using System;
using System.Collections;
using System.Runtime.CompilerServices;

public class JCloudRoutine
{
	private bool cancel;

	public IEnumerator enumerator;

	private static JCloudRoutine own;

	public event Action Cancelled
	{
		[MethodImpl(MethodImplOptions.Synchronized)]
		add
		{
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		remove
		{
		}
	}

	public event Action Finished
	{
		[MethodImpl(MethodImplOptions.Synchronized)]
		add
		{
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		remove
		{
		}
	}

	public void Cancel()
	{
	}

	public static IEnumerator Run(IEnumerator extendedCoRoutine)
	{
		return default(IEnumerator);
	}

	public static JCloudRoutine Create(IEnumerator extendedCoRoutine)
	{
		return default(JCloudRoutine);
	}

	[System.Diagnostics.DebuggerHidden]
	private IEnumerator Execute(IEnumerator extendedCoRoutine)
	{
		return default(IEnumerator);
	}
}
