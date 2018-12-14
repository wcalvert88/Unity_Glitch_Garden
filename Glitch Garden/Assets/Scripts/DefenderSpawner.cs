using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderSpawner : MonoBehaviour {

	[SerializeField] public Camera myCamera;
	[SerializeField] private GameObject defenderParent;
	private StarDisplay starDisplay;

	void Start() {
		defenderParent = GameObject.Find("Defenders");
		starDisplay = GameObject.FindObjectOfType<StarDisplay>();
		if (!defenderParent) {
			defenderParent = new GameObject("Defenders");
		}
	}

	void OnMouseDown()
	{
		Vector2 rawPos = CalculateWorldPointOfMouseClick();
		Vector2 roundedPos = SnapToGrid(rawPos);
		GameObject defender = Button.selectedDefender;
		int defenderCost = defender.GetComponent<Defenders>().starCost;
		if (starDisplay.UseStars(defenderCost) == StarDisplay.Status.SUCCESS) {
			SpawnDefender(roundedPos, defender);
		} else {
			Debug.Log("Insufficient stars to spawn");
		}
	}

	void SpawnDefender (Vector2 roundedPos, GameObject defender) {
		Quaternion zeroRotation = Quaternion.identity;
		GameObject newDef = Instantiate(defender, roundedPos, zeroRotation) as GameObject;

		newDef.transform.parent = defenderParent.transform;
	}

	Vector2 SnapToGrid(Vector2 rawWorldPos) {
		float newX = Mathf.RoundToInt(rawWorldPos.x);
		float newY = Mathf.RoundToInt(rawWorldPos.y);
		return new Vector2(newX, newY);
	}

	Vector2 CalculateWorldPointOfMouseClick() {
		float mouseX = Input.mousePosition.x;
		float mouseY = Input.mousePosition.y;
		float distanceFromCamera = 10f;
		Vector3 weirdTriplet = new Vector3(mouseX, mouseY, distanceFromCamera);
		Vector2 worldPos = myCamera.ScreenToWorldPoint(weirdTriplet);

		return worldPos;
	}
}
