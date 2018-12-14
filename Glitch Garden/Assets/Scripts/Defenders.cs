using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defenders : MonoBehaviour {
	private StarDisplay starDisplay;

	[SerializeField] [Range(0f, 500f)] public int starCost = 100;
	void Start () {
		starDisplay = GameObject.FindObjectOfType<StarDisplay>();
	}

	public void AddStars(int amount) {
		starDisplay.AddStars(amount);
	}

	public void ChargeStars(int amount) {
		starDisplay.UseStars(amount);
	}
}
