using System;
using System.Collections;
using System.Diagnostics;
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
		/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
	}

	public static JCloudRoutine Create(IEnumerator extendedCoRoutine)
	{
		/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
	}

	[DebuggerHidden]
	private IEnumerator Execute(IEnumerator extendedCoRoutine)
	{
		/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
	}
}
