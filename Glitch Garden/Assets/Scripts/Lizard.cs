﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(Attacker))]
public class Lizard : MonoBehaviour {

	private Animator anim;
	private Attacker attacker;
	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();
		attacker = GetComponent<Attacker>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void OnTriggerEnter2D(Collider2D other)
	{
		GameObject obj = other.gameObject;

		// Leave the method if not colliding with defender
		if (!obj.GetComponent<Defenders>()) {
			return;
		}
		
		anim.SetBool("isAttacking", true);
		attacker.Attack(obj);
	}
}
