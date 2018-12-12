using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour {

	[SerializeField] public GameObject defenderPrefab;
	[SerializeField] public static GameObject selectedDefender;
	
	[SerializeField] private Button[] buttonArray;
	// Use this for initialization
	void Start () {
		buttonArray = GameObject.FindObjectsOfType<Button>();
		GetComponent<SpriteRenderer>().color = Color.black;
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
