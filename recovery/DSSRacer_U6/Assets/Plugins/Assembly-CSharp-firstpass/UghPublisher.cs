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
				RecoveryPending.Hit("UghPublisher.TransformsDictionary.get_Item");
				return default(Transform);
			}
		}

		public TransformsDictionary(TransformReference[] refs)
		{
			RecoveryPending.Hit("UghPublisher.TransformsDictionary..ctor");
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
				RecoveryPending.Hit("UghPublisher.UghTextsDictionary.get_Item");
				return default(UghText);
			}
		}

		public UghTextsDictionary(UghTextReference[] refs)
		{
			RecoveryPending.Hit("UghPublisher.UghTextsDictionary..ctor");
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
				RecoveryPending.Hit("UghPublisher.LEDScrollersDictionary.get_Item");
				return default(LEDScroller);
			}
		}

		public LEDScrollersDictionary(LEDScrollerReference[] refs)
		{
			RecoveryPending.Hit("UghPublisher.LEDScrollersDictionary..ctor");
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
				RecoveryPending.Hit("UghPublisher.UghButtonsDictionary.get_Item");
				return default(UghButton);
			}
		}

		public UghButtonsDictionary(UghButtonReference[] refs)
		{
			RecoveryPending.Hit("UghPublisher.UghButtonsDictionary..ctor");
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
				RecoveryPending.Hit("UghPublisher.UghSlideToggleDictionary.get_Item");
				return default(UghSlideToggle);
			}
		}

		public UghSlideToggleDictionary(UghSlideToggleReference[] refs)
		{
			RecoveryPending.Hit("UghPublisher.UghSlideToggleDictionary..ctor");
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
				RecoveryPending.Hit("UghPublisher.UghSliderDictionary.get_Item");
				return default(UghSlider);
			}
		}

		public UghSliderDictionary(UghSliderReference[] refs)
		{
			RecoveryPending.Hit("UghPublisher.UghSliderDictionary..ctor");
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
			RecoveryPending.Hit("UghPublisher.get_transforms");
			return default(TransformsDictionary);
		}
	}

	public UghTextsDictionary ughTexts
	{
		get
		{
			RecoveryPending.Hit("UghPublisher.get_ughTexts");
			return default(UghTextsDictionary);
		}
	}

	public LEDScrollersDictionary ledScrollers
	{
		get
		{
			RecoveryPending.Hit("UghPublisher.get_ledScrollers");
			return default(LEDScrollersDictionary);
		}
	}

	public UghButtonsDictionary ughButtons
	{
		get
		{
			RecoveryPending.Hit("UghPublisher.get_ughButtons");
			return default(UghButtonsDictionary);
		}
	}

	public UghSlideToggleDictionary ughSlideToggles
	{
		get
		{
			RecoveryPending.Hit("UghPublisher.get_ughSlideToggles");
			return default(UghSlideToggleDictionary);
		}
	}

	public UghSliderDictionary ughSliders
	{
		get
		{
			RecoveryPending.Hit("UghPublisher.get_ughSliders");
			return default(UghSliderDictionary);
		}
	}

	public UghButton GetButton(string name)
	{
		RecoveryPending.Hit("UghPublisher.GetButton");
		return default(UghButton);
	}

	protected void Awake()
	{
		RecoveryPending.Hit("UghPublisher.Awake");
	}

	public void OnButtonPressed(UghButton button)
	{
		RecoveryPending.Hit("UghPublisher.OnButtonPressed");
	}

	public UghSprite GetSprite(string name)
	{
		RecoveryPending.Hit("UghPublisher.GetSprite");
		return default(UghSprite);
	}
}
