using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicManager : MonoBehaviour {

	[SerializeField] public AudioClip[] levelMusicChangeArray;
	[SerializeField] private AudioSource audioSource;

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
		if (!thisLevelMusic) return;
		audioSource.clip = thisLevelMusic;
		if (scene.buildIndex > 0)audioSource.loop = true;
		audioSource.volume = 0.75f;
		audioSource.Play();
		
	}
}
