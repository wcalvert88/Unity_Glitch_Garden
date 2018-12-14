using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class StarDisplay : MonoBehaviour {

	[SerializeField] private Text starText;
	[SerializeField] int stars = 0;

	void Start() {
		starText = GetComponent<Text>();
		stars = 50;
		UpdateDisplay();
	}

	public void AddStars(int amount) {
		stars += amount;
		UpdateDisplay();
	}

	public void UseStars(int amount) {
		stars -= amount;
		UpdateDisplay();
	}

	private void UpdateDisplay() {
		starText.text = stars.ToString();
	}
}
