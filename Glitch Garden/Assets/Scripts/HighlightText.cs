using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HighlightText : MonoBehaviour {

	public TextMeshProUGUI text;
	// Use this for initialization
	
	[SerializeField] public Color originalColor;
	[SerializeField] public Color highlightColor;

	void Start() {
		text = GetComponentInChildren<TextMeshProUGUI>();
	}
	public void MakeHighlighted() {
		text.color = highlightColor;
		Debug.Log("mouse entered");
	}
	
	// Update is called once per frame
	public void OriginalColor() {
		text.color = originalColor;
		Debug.Log("mouse exit");
	}
}
