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
		RecoveryPending.Hit("TrackSelectPublisher.GetTrackIconsList");
		return default(List<TrackIcon>);
	}

	private void Refresh()
	{
		RecoveryPending.Hit("TrackSelectPublisher.Refresh");
	}

	private void RaceOrSummary()
	{
		RecoveryPending.Hit("TrackSelectPublisher.RaceOrSummary");
	}

	private void Start()
	{
		RecoveryPending.Hit("TrackSelectPublisher.Start");
	}

	private void DetermineTrophies(GameObject[] trackList)
	{
		RecoveryPending.Hit("TrackSelectPublisher.DetermineTrophies");
	}

	private void FixedUpdate()
	{
		RecoveryPending.Hit("TrackSelectPublisher.FixedUpdate");
	}

	private void PressedTrackButton1()
	{
		RecoveryPending.Hit("TrackSelectPublisher.PressedTrackButton1");
	}

	private void PressedTrackButton2()
	{
		RecoveryPending.Hit("TrackSelectPublisher.PressedTrackButton2");
	}

	private void PressedTrackButton3()
	{
		RecoveryPending.Hit("TrackSelectPublisher.PressedTrackButton3");
	}

	private void PressedBackButton()
	{
		RecoveryPending.Hit("TrackSelectPublisher.PressedBackButton");
	}

	private void UpdateTrackSnapshots()
	{
		RecoveryPending.Hit("TrackSelectPublisher.UpdateTrackSnapshots");
	}
}
