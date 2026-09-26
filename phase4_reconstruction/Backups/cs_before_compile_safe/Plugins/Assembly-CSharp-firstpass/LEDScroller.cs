using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text;
using UnityEngine;

[RequireComponent(typeof(UghText))]
public class LEDScroller : MonoBehaviour
{
	[Serializable]
	public class TextString
	{
		public string text;

		public bool scroll;

		public bool flash;

		public string Text
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
			set
			{
			}
		}

		public bool Scroll
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
			set
			{
			}
		}

		public bool Flash
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
			set
			{
			}
		}

		public TextString(string text, bool scroll, bool flash)
		{
		}
	}

	public delegate void NewTextCheckHandler();

	private UghText ughText;

	public int maxCharacterWidth;

	public float scrollSpeed;

	public float flashSpeed;

	public int toggleFactor;

	public float staticTextTime;

	private float time;

	public List<TextString> textStrings;

	public bool cycleThroughTextstrings;

	private string tempCurrentString;

	private StringBuilder current;

	private int currentString;

	private int currentStringLength;

	private int padValue;

	private int index;

	private bool endofSentence;

	private int flashCount;

	public int CurrentString
	{
		get
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}
		set
		{
		}
	}

	public bool EndofSentence
	{
		get
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}
		set
		{
		}
	}

	public static event NewTextCheckHandler HandleNewTextCheck
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

	private void OnNewTextCheck()
	{
	}

	private void OnEnable()
	{
	}

	private void OnDisable()
	{
	}

	private void CheckForNewText()
	{
	}

	private void Start()
	{
	}

	private void SetUpNewStringForDisplayHelper()
	{
	}

	public void OnResetScroller()
	{
	}

	private void OnScroll()
	{
	}

	private void OnFlash()
	{
	}

	[DebuggerHidden]
	private IEnumerator OnScrollHelper()
	{
		/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
	}

	[DebuggerHidden]
	private IEnumerator OnFlashHelper()
	{
		/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
	}

	private void OnStaticText()
	{
	}

	private void Update()
	{
	}

	public void AddText(string text, bool scroll, bool flash)
	{
	}

	public void RemoveText(int index)
	{
	}

	public void ReplaceText(string text, int index, bool scroll, bool flash)
	{
	}

	public void ClearText()
	{
	}

	public int TextStringCount()
	{
		/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
	}
}
