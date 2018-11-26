using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicManager : MonoBehaviour {

	[SerializeField] public AudioClip[] levelMusicChangeArray;
	[SerializeField] private AudioSource audioSource;

	[SerializeField] private AudioClip currentlyPlaying;

	void Awake() {
		DontDestroyOnLoad(gameObject);
		
	}

	void Start() {
		audioSource.GetComponent<AudioSource>();

	}
	
	void OnEnable() {
		// Tell 'OnSceneLoaded' function tostart listening for a scene change as soon as this script is enabled.
		SceneManager.sceneLoaded += OnSceneLoaded;
	}

	void OnDisable()
	{
		//Tell our 'OnSceneLoaded' function to stop listening for a scene change as soon as this script is disabled. Remember to always have an unsubscription for every delegate you subscribe to!
		SceneManager.sceneLoaded -= OnSceneLoaded;
	}

	void OnSceneLoaded(Scene scene, LoadSceneMode mode) {
		// Use the buildIndex of the scene to pass the level value to the array.
		AudioClip thisLevelMusic = levelMusicChangeArray[scene.buildIndex];
		if (scene.buildIndex > 0 && scene.buildIndex < 6) {
			thisLevelMusic = levelMusicChangeArray[1];
		}
		
		if (!thisLevelMusic) return;
		
		if (scene.buildIndex > 0) { audioSource.loop = true;
		}
		if (currentlyPlaying != thisLevelMusic) {
			audioSource.clip = thisLevelMusic;
			audioSource.volume = 0.75f;
			if (thisLevelMusic.name == "level_up_kazoo") {
				audioSource.volume = 0.3f;
				audioSource.loop = false;
			}
			audioSource.Play();
		}
		
		currentlyPlaying = thisLevelMusic;
	}

	public void ChangeVolume(float volume) {
		audioSource.volume = volume;
	}
}
