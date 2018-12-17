using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class LivesDisplay : MonoBehaviour {

	[SerializeField] private Text liveText;
	[SerializeField] int lives = 3;
	public enum Status {SUCCESS, FAILURE};

	void Start() {
		liveText = GetComponent<Text>();
		// lives = 100;
		UpdateDisplay();
	}

	public void AddLives(int amount) {
		lives += amount;
		UpdateDisplay();
	}

	public Status UseLives(int amount) {
		if (lives - amount >= 0) {
			lives -= amount;
			UpdateDisplay();
			return Status.SUCCESS;
		}
		return Status.FAILURE;
	}

	private void UpdateDisplay() {
		liveText.text = lives.ToString();
	}
}