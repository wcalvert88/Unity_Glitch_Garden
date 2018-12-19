using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopButton : MonoBehaviour {

	[SerializeField] private LevelManager levelManager;

	void Start() {
		levelManager = GameObject.FindObjectOfType<LevelManager>();
	}
	void OnMouseDown() {
		levelManager.LoadLevel("01a_Start");
	}
}
