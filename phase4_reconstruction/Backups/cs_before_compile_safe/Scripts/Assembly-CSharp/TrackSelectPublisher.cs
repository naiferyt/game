using System;
using System.Collections.Generic;
using UnityEngine;

public class TrackSelectPublisher : UghPublisher
{
	[Serializable]
	public class TrackIcon
	{
		public string name;

		public UghSpritePrototype proto;
	}

	private GameObject[] trackList;

	private TrackUnlockHelper tuh;

	private Vector3 originOffset;

	private float transitionTimer;

	private float transitionSpeed;

	private bool oneClickEnter;

	public List<TrackIcon> trackIcons;

	public static List<TrackIcon> GetTrackIconsList()
	{
		/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
	}

	private void Refresh()
	{
	}

	private void RaceOrSummary()
	{
	}

	private void Start()
	{
	}

	private void DetermineTrophies(GameObject[] trackList)
	{
	}

	private void FixedUpdate()
	{
	}

	private void PressedTrackButton1()
	{
	}

	private void PressedTrackButton2()
	{
	}

	private void PressedTrackButton3()
	{
	}

	private void PressedBackButton()
	{
	}

	private void UpdateTrackSnapshots()
	{
	}
}
