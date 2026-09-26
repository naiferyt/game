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
				RecoveryPending.Hit("LEDScroller.TextString.get_Text");
				return default(string);
			}
			set
			{
				RecoveryPending.Hit("LEDScroller.TextString.set_Text");
			}
		}

		public bool Scroll
		{
			get
			{
				RecoveryPending.Hit("LEDScroller.TextString.get_Scroll");
				return default(bool);
			}
			set
			{
				RecoveryPending.Hit("LEDScroller.TextString.set_Scroll");
			}
		}

		public bool Flash
		{
			get
			{
				RecoveryPending.Hit("LEDScroller.TextString.get_Flash");
				return default(bool);
			}
			set
			{
				RecoveryPending.Hit("LEDScroller.TextString.set_Flash");
			}
		}

		public TextString(string text, bool scroll, bool flash)
		{
			RecoveryPending.Hit("LEDScroller.TextString..ctor");
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
			RecoveryPending.Hit("LEDScroller.get_CurrentString");
			return default(int);
		}
		set
		{
			RecoveryPending.Hit("LEDScroller.set_CurrentString");
		}
	}

	public bool EndofSentence
	{
		get
		{
			RecoveryPending.Hit("LEDScroller.get_EndofSentence");
			return default(bool);
		}
		set
		{
			RecoveryPending.Hit("LEDScroller.set_EndofSentence");
		}
	}

	public static event NewTextCheckHandler HandleNewTextCheck
	{
		[MethodImpl(MethodImplOptions.Synchronized)]
		add
		{
			RecoveryPending.Hit("LEDScroller.add_HandleNewTextCheck");
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		remove
		{
			RecoveryPending.Hit("LEDScroller.remove_HandleNewTextCheck");
		}
	}

	private void OnNewTextCheck()
	{
		RecoveryPending.Hit("LEDScroller.OnNewTextCheck");
	}

	private void OnEnable()
	{
		RecoveryPending.Hit("LEDScroller.OnEnable");
	}

	private void OnDisable()
	{
		RecoveryPending.Hit("LEDScroller.OnDisable");
	}

	private void CheckForNewText()
	{
		RecoveryPending.Hit("LEDScroller.CheckForNewText");
	}

	private void Start()
	{
		RecoveryPending.Hit("LEDScroller.Start");
	}

	private void SetUpNewStringForDisplayHelper()
	{
		RecoveryPending.Hit("LEDScroller.SetUpNewStringForDisplayHelper");
	}

	public void OnResetScroller()
	{
		RecoveryPending.Hit("LEDScroller.OnResetScroller");
	}

	private void OnScroll()
	{
		RecoveryPending.Hit("LEDScroller.OnScroll");
	}

	private void OnFlash()
	{
		RecoveryPending.Hit("LEDScroller.OnFlash");
	}

	[DebuggerHidden]
	private IEnumerator OnScrollHelper()
	{
		RecoveryPending.Hit("LEDScroller.OnScrollHelper");
		yield break;
	}

	[DebuggerHidden]
	private IEnumerator OnFlashHelper()
	{
		RecoveryPending.Hit("LEDScroller.OnFlashHelper");
		yield break;
	}

	private void OnStaticText()
	{
		RecoveryPending.Hit("LEDScroller.OnStaticText");
	}

	private void Update()
	{
		RecoveryPending.Hit("LEDScroller.Update");
	}

	public void AddText(string text, bool scroll, bool flash)
	{
		RecoveryPending.Hit("LEDScroller.AddText");
	}

	public void RemoveText(int index)
	{
		RecoveryPending.Hit("LEDScroller.RemoveText");
	}

	public void ReplaceText(string text, int index, bool scroll, bool flash)
	{
		RecoveryPending.Hit("LEDScroller.ReplaceText");
	}

	public void ClearText()
	{
		RecoveryPending.Hit("LEDScroller.ClearText");
	}

	public int TextStringCount()
	{
		RecoveryPending.Hit("LEDScroller.TextStringCount");
		return default(int);
	}
}
