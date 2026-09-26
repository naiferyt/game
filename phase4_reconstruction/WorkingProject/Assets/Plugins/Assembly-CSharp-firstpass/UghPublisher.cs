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
				return default(Transform);
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
				return default(UghText);
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
				return default(LEDScroller);
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
				return default(UghButton);
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
				return default(UghSlideToggle);
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
				return default(UghSlider);
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
			return default(TransformsDictionary);
		}
	}

	public UghTextsDictionary ughTexts
	{
		get
		{
			return default(UghTextsDictionary);
		}
	}

	public LEDScrollersDictionary ledScrollers
	{
		get
		{
			return default(LEDScrollersDictionary);
		}
	}

	public UghButtonsDictionary ughButtons
	{
		get
		{
			return default(UghButtonsDictionary);
		}
	}

	public UghSlideToggleDictionary ughSlideToggles
	{
		get
		{
			return default(UghSlideToggleDictionary);
		}
	}

	public UghSliderDictionary ughSliders
	{
		get
		{
			return default(UghSliderDictionary);
		}
	}

	public UghButton GetButton(string name)
	{
		return default(UghButton);
	}

	protected void Awake()
	{
	}

	public void OnButtonPressed(UghButton button)
	{
	}

	public UghSprite GetSprite(string name)
	{
		return default(UghSprite);
	}
}
