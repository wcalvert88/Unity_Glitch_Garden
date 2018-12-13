using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Attacker : MonoBehaviour {

	[SerializeField] [Range (-1f, 1.5f)] private float currentSpeed;

	[Tooltip ("Average number of seconds between appearances")]
	[SerializeField] [Range (0f, 60f)] public float seenEverySeconds;
	private GameObject currentTarget;
	private Animator animator;

	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate(Vector3.left * currentSpeed * Time.deltaTime);
		if (!currentTarget) {
			animator.SetBool("isAttacking", false);
		}
	}

	public void SetSpeed(float speed) {
		currentSpeed = speed;
	}
	// Called from the animator at time of actual blow
	public void StrikeCurrentTarget (float damager) {
		if (currentTarget) {
			Health health = currentTarget.GetComponent<Health>();
			if (health) {
				health.DealDamage(damager);
			}
		}
	}

	public void Attack (GameObject obj) {
		currentTarget = obj;
	}
}
