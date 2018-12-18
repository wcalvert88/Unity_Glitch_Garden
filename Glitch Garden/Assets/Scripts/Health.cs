using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {

	[SerializeField] public float health;

	private Stone stone;
	// Use this for initialization
	void Start () {
		// check if stone
		stone = gameObject.GetComponent<Stone>();
		if (!stone) {
			print ("Not stone");
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void DealDamage (float damage) {
		health -= damage;
		if (health <= 0) {
			// Optionally trigger animation
			if (stone) {
				stone.Die();
			} else {
			DestroyObject();
			}
		}
	}

	public void DestroyObject() {
		Destroy(gameObject);
	}
}
