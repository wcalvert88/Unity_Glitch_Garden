using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour {

	[SerializeField] public float levelSeconds = 100.0f;
	[SerializeField] private AudioSource audioSource;
	[SerializeField] private Slider slider;
	[SerializeField] private bool isEndOfLevel = false;
	[SerializeField] private LevelManager levelManager;
	[SerializeField] private GameObject winLabel;


	private float waitTime;

	// Use this for initialization
	void Start () {
		slider = GetComponent<Slider>();
		audioSource = GetComponent<AudioSource>();
		levelManager = GameObject.FindObjectOfType<LevelManager>();
		FindYouWin();
		winLabel.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		slider.value = Time.timeSinceLevelLoad / levelSeconds;
		bool timeIsUp = (Time.timeSinceLevelLoad >= levelSeconds);
		if (timeIsUp && !isEndOfLevel) {
			HandleWinCondition();
		}
	}

	void HandleWinCondition() {
		DestroyAllTaggedObjects();
		winLabel.SetActive(true);
		audioSource.Play();
		Invoke("LoadNextLevel", audioSource.clip.length);
		isEndOfLevel = true;
	}

	// Destroys all objects with tag destroyOnWin
	void DestroyAllTaggedObjects() {
		GameObject[] taggedObjectArray = GameObject.FindGameObjectsWithTag("destroyOnWin");
		foreach(GameObject taggedObj in taggedObjectArray) {
			Destroy(taggedObj);
		}
	}

	void FindYouWin() {
		winLabel = GameObject.Find("You Win");
		if (!winLabel) {
			Debug.LogWarning("Please create You Win Object");
		}
	}

	void LoadNextLevel() {
		levelManager.LoadNextLevel();
	}
}
