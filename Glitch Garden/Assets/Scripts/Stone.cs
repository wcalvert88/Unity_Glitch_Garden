using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stone : MonoBehaviour {
	[SerializeField] private Animator animator;

	void Start() {
		animator = GetComponent<Animator>();
	}

	void Update() {

	}

	public void Die() {
		animator.SetBool("isDead", true);
	}

	public void OnTriggerStay2D(Collider2D other)
	{
		Attacker attacker = other.gameObject.GetComponent<Attacker>();
		if (attacker) {
			animator.SetTrigger("underAttackTrigger");
		}
	}
}
