using System;
using System.Collections.Generic;
using UnityEngine;

public class UghPublisher : Script
{
	public class TransformsDictionary
	{
		private Dictionary<string, Transform> nameToTransform;

		public Transform this[string name]
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		public TransformsDictionary(TransformReference[] refs)
		{
		}
	}

	[Serializable]
	public class TransformReference
	{
		public string name;

		public Transform reference;
	}

	public class UghTextsDictionary
	{
		private Dictionary<string, UghText> nameToUghText;

		public UghText this[string name]
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		public UghTextsDictionary(UghTextReference[] refs)
		{
		}
	}

	[Serializable]
	public class UghTextReference
	{
		public string name;

		public UghText reference;
	}

	public class LEDScrollersDictionary
	{
		private Dictionary<string, LEDScroller> nameToLEDScroller;

		public LEDScroller this[string name]
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		public LEDScrollersDictionary(LEDScrollerReference[] refs)
		{
		}
	}

	[Serializable]
	public class LEDScrollerReference
	{
		public string name;

		public LEDScroller reference;
	}

	public class UghButtonsDictionary
	{
		private Dictionary<string, UghButton> nameToUghButton;

		public UghButton this[string name]
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		public UghButtonsDictionary(UghButtonReference[] refs)
		{
		}
	}

	[Serializable]
	public class UghButtonReference
	{
		public string name;

		public UghButton reference;

		public string functionName;
	}

	public class UghSlideToggleDictionary
	{
		private Dictionary<string, UghSlideToggle> nameToUghSlideToggle;

		public UghSlideToggle this[string name]
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		public UghSlideToggleDictionary(UghSlideToggleReference[] refs)
		{
		}
	}

	[Serializable]
	public class UghSlideToggleReference
	{
		public string name;

		public UghSlideToggle reference;
	}

	public class UghSliderDictionary
	{
		private Dictionary<string, UghSlider> nameToUghSlider;

		public UghSlider this[string name]
		{
			get
			{
				/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
			}
		}

		public UghSliderDictionary(UghSliderReference[] refs)
		{
		}
	}

	[Serializable]
	public class UghSliderReference
	{
		public string name;

		public UghSlider reference;
	}

	public TransformReference[] transformReferences;

	private TransformsDictionary transformsDictionary;

	public UghTextReference[] ughTextReferences;

	private UghTextsDictionary ughTextsDictionary;

	public LEDScrollerReference[] ledScrollerReferences;

	private LEDScrollersDictionary ledScrollersDictionary;

	public UghButtonReference[] ughButtonReferences;

	private UghButtonsDictionary ughButtonsDictionary;

	public UghSlideToggleReference[] ughSlideToggleReferences;

	private UghSlideToggleDictionary ughSlideTogglesDictionary;

	public UghSliderReference[] ughSliderReferences;

	private UghSliderDictionary ughSlidersDictionary;

	public List<UghSprite> ughSprites;

	public TransformsDictionary transforms
	{
		get
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}
	}

	public UghTextsDictionary ughTexts
	{
		get
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}
	}

	public LEDScrollersDictionary ledScrollers
	{
		get
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}
	}

	public UghButtonsDictionary ughButtons
	{
		get
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}
	}

	public UghSlideToggleDictionary ughSlideToggles
	{
		get
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}
	}

	public UghSliderDictionary ughSliders
	{
		get
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		}
	}

	public UghButton GetButton(string name)
	{
		/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
	}

	protected void Awake()
	{
	}

	public void OnButtonPressed(UghButton button)
	{
	}

	public UghSprite GetSprite(string name)
	{
		/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
	}
}
