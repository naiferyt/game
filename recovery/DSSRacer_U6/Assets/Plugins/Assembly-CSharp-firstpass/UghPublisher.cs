using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

// Menu screen controller base: name -> object tables for the screen's transforms, texts, buttons, toggles and
// sliders (filled from the serialized reference arrays), and button presses dispatched by function name.
// Source listing: recovery/aot_listings/Assembly-CSharp-firstpass/UghPublisher.txt
public class UghPublisher : Script
{
	public class TransformsDictionary
	{
		private Dictionary<string, Transform> nameToTransform;

		public Transform this[string name]
		{
			// RECUPERADO-AOT UghPublisher.TransformsDictionary.get_Item token 0x06000446 @0x00043a7c
			get
			{
				return nameToTransform[name];
			}
		}

		// RECUPERADO-AOT UghPublisher.TransformsDictionary..ctor token 0x06000445 @0x000439c0
		public TransformsDictionary(TransformReference[] refs)
		{
			nameToTransform = new Dictionary<string, Transform>(refs.Length);
			foreach (TransformReference reference in refs)
			{
				nameToTransform[reference.name] = reference.reference;
			}
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
			// RECUPERADO-AOT UghPublisher.UghTextsDictionary.get_Item token 0x06000449 @0x00043bac
			get
			{
				return nameToUghText[name];
			}
		}

		// RECUPERADO-AOT UghPublisher.UghTextsDictionary..ctor token 0x06000448 @0x00043af0
		public UghTextsDictionary(UghTextReference[] refs)
		{
			nameToUghText = new Dictionary<string, UghText>(refs.Length);
			foreach (UghTextReference reference in refs)
			{
				nameToUghText[reference.name] = reference.reference;
			}
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
			// RECUPERADO-AOT UghPublisher.LEDScrollersDictionary.get_Item token 0x0600044c @0x00043cdc
			get
			{
				return nameToLEDScroller[name];
			}
		}

		// RECUPERADO-AOT UghPublisher.LEDScrollersDictionary..ctor token 0x0600044b @0x00043c20
		public LEDScrollersDictionary(LEDScrollerReference[] refs)
		{
			nameToLEDScroller = new Dictionary<string, LEDScroller>(refs.Length);
			foreach (LEDScrollerReference reference in refs)
			{
				nameToLEDScroller[reference.name] = reference.reference;
			}
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
			// RECUPERADO-AOT UghPublisher.UghButtonsDictionary.get_Item token 0x0600044f @0x00043e0c
			get
			{
				return nameToUghButton[name];
			}
		}

		// RECUPERADO-AOT UghPublisher.UghButtonsDictionary..ctor token 0x0600044e @0x00043d50
		public UghButtonsDictionary(UghButtonReference[] refs)
		{
			nameToUghButton = new Dictionary<string, UghButton>(refs.Length);
			foreach (UghButtonReference reference in refs)
			{
				nameToUghButton[reference.name] = reference.reference;
			}
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
			// RECUPERADO-AOT UghPublisher.UghSlideToggleDictionary.get_Item token 0x06000452 @0x00043f3c
			get
			{
				return nameToUghSlideToggle[name];
			}
		}

		// RECUPERADO-AOT UghPublisher.UghSlideToggleDictionary..ctor token 0x06000451 @0x00043e80
		public UghSlideToggleDictionary(UghSlideToggleReference[] refs)
		{
			nameToUghSlideToggle = new Dictionary<string, UghSlideToggle>(refs.Length);
			foreach (UghSlideToggleReference reference in refs)
			{
				nameToUghSlideToggle[reference.name] = reference.reference;
			}
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
			// RECUPERADO-AOT UghPublisher.UghSliderDictionary.get_Item token 0x06000455 @0x0004406c
			get
			{
				return nameToUghSlider[name];
			}
		}

		// RECUPERADO-AOT UghPublisher.UghSliderDictionary..ctor token 0x06000454 @0x00043fb0
		public UghSliderDictionary(UghSliderReference[] refs)
		{
			nameToUghSlider = new Dictionary<string, UghSlider>(refs.Length);
			foreach (UghSliderReference reference in refs)
			{
				nameToUghSlider[reference.name] = reference.reference;
			}
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
		// RECUPERADO-AOT UghPublisher.get_transforms token 0x0600043b @0x00043550
		get
		{
			return transformsDictionary;
		}
	}

	public UghTextsDictionary ughTexts
	{
		// RECUPERADO-AOT UghPublisher.get_ughTexts token 0x0600043c @0x00043584
		get
		{
			return ughTextsDictionary;
		}
	}

	public LEDScrollersDictionary ledScrollers
	{
		// RECUPERADO-AOT UghPublisher.get_ledScrollers token 0x0600043d @0x000435b8
		get
		{
			return ledScrollersDictionary;
		}
	}

	public UghButtonsDictionary ughButtons
	{
		// RECUPERADO-AOT UghPublisher.get_ughButtons token 0x0600043e @0x000435ec
		get
		{
			return ughButtonsDictionary;
		}
	}

	public UghSlideToggleDictionary ughSlideToggles
	{
		// RECUPERADO-AOT UghPublisher.get_ughSlideToggles token 0x06000440 @0x00043668
		get
		{
			return ughSlideTogglesDictionary;
		}
	}

	public UghSliderDictionary ughSliders
	{
		// RECUPERADO-AOT UghPublisher.get_ughSliders token 0x06000441 @0x0004369c
		get
		{
			return ughSlidersDictionary;
		}
	}

	// RECUPERADO-AOT UghPublisher.GetButton token 0x0600043f @0x00043620
	public UghButton GetButton(string name)
	{
		return ughButtonsDictionary[name];
	}

	// RECUPERADO-AOT UghPublisher.Awake token 0x06000442 @0x000436d0
	protected void Awake()
	{
		transformsDictionary = new TransformsDictionary(transformReferences);
		ughTextsDictionary = new UghTextsDictionary(ughTextReferences);
		ledScrollersDictionary = new LEDScrollersDictionary(ledScrollerReferences);
		ughButtonsDictionary = new UghButtonsDictionary(ughButtonReferences);
		ughSlideTogglesDictionary = new UghSlideToggleDictionary(ughSlideToggleReferences);
		ughSlidersDictionary = new UghSliderDictionary(ughSliderReferences);
	}

	// RECUPERADO-AOT UghPublisher.OnButtonPressed token 0x06000443 @0x0004381c
	public void OnButtonPressed(UghButton button)
	{
		foreach (UghButtonReference reference in ughButtonReferences)
		{
			if (reference.reference == button)
			{
				Invoke(reference.functionName, 0f);
			}
		}
	}

	// RECUPERADO-AOT UghPublisher.GetSprite token 0x06000444 @0x000438d4
	// RECUPERADO-AOT UghPublisher.<GetSprite>c__AnonStorey2A.<>m__8 token 0x06000611 @0x0005e8c0
	public UghSprite GetSprite(string name)
	{
		return ughSprites.Where((UghSprite us) => us.gameObject.name == name).FirstOrDefault();
	}
}
