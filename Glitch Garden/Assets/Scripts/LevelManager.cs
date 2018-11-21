using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelManager : MonoBehaviour {

	[SerializeField] float autoLoadNextLevelAfter = 2.5f;

	void Start() {
		if(autoLoadNextLevelAfter <= 0) {
			Debug.Log("Level auto load disabled");
		} else {
			Invoke("LoadNextLevel", autoLoadNextLevelAfter);
		}
	}
	public void LoadLevel(string name) {
		Debug.Log("New Level load: " + name);
		SceneManager.LoadScene(name);
	}
	
	public void QuitRequest() {
		Debug.Log("Quit requested");
		Application.Quit();
	}

	public void LoadNextLevel() {
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
	}

	
}
