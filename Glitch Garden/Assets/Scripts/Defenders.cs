using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defenders : MonoBehaviour {
	private StarDisplay starDisplay;

	[SerializeField] [Range(0f, 100f)] public int starCost;
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
