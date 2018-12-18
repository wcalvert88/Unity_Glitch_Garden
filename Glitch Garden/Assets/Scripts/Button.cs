using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Button : MonoBehaviour {

	[SerializeField] public GameObject defenderPrefab;
	[SerializeField] public static GameObject selectedDefender;
	
	[SerializeField] private Button[] buttonArray;
	[SerializeField] private Text costText;
	// Use this for initialization
	void Start () {
		buttonArray = GameObject.FindObjectsOfType<Button>();
		GetComponent<SpriteRenderer>().color = Color.black;
		costText = GetComponentInChildren<Text>();
		if (!costText) {
			Debug.LogWarning(name + " has no cost text");
		}
		costText.text = defenderPrefab.GetComponent<Defenders>().starCost.ToString();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnMouseDown() {
		foreach (Button thisButton in buttonArray)
		{
			thisButton.GetComponent<SpriteRenderer>().color = Color.black;
			
		}
		GetComponent<SpriteRenderer>().color = Color.white;
		selectedDefender = defenderPrefab;
		print (selectedDefender);
		// if (item.color == Color.black) {
		// 	item.color = Color.white;
		// } else {
		// 	item.color = Color.black;
		// }
	}
}
