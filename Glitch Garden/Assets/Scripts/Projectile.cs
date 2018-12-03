using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

	[SerializeField] public float speed, damage;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate(Vector3.right * speed * Time.deltaTime);
	}

	void OnBecameInvisible()
	{
		Destroy(gameObject);
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		Attacker attacker = other.gameObject.GetComponent<Attacker>();
		Health health = other.gameObject.GetComponent<Health>();
		if (attacker && health) {
			health.DealDamage(damage);
			Destroy(gameObject);
		}	
	}
}
