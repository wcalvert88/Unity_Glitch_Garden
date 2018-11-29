﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetStartVolume : MonoBehaviour {

	private MusicManager musicManager;

	// Use this for initialization
	void Start () {
		musicManager = GameObject.FindObjectOfType<MusicManager>();
		if(musicManager) {
			float volume = PlayerPrefsManager.GetMasterVolume();
			musicManager.SetVolume(volume);
		} else {
			Debug.LogWarning("Music Manager not found in Start Scene, can't set volume");
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}