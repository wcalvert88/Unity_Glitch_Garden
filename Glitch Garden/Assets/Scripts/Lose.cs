using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Lose : MonoBehaviour {
	[SerializeField] private LivesDisplay livesDisplay;
	[SerializeField] private LevelManager levelManager;

	void Start() {
		livesDisplay = GameObject.FindObjectOfType<LivesDisplay>();
		levelManager = GameObject.FindObjectOfType<LevelManager>();
	}
	void OnTriggerEnter2D(Collider2D other)
	{
		Destroy(other.gameObject);
		if (livesDisplay.UseLives(1) == LivesDisplay.Status.FAILURE) {
			levelManager.LoadLevel("03b_Lose");
		} else {
			livesDisplay.UseLives(1);
		}
	}
}
