﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {

	[SerializeField] public float health;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void DealDamage (float damage) {
		health -= damage;
		if (health <= 0) {
			// Optionally trigger animation
			DestroyObject();
		}
	}

	public void DestroyObject() {
		Destroy(gameObject);
	}
}
