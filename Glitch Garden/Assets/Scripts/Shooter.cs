using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour {

	[SerializeField] public GameObject projectile, gun;
	[SerializeField] private GameObject projectileParent;
	private Animator animator;
	private Spawner myLaneSpawner;
	

	void Start() {
		animator = GetComponent<Animator>();

		// Creates a parent if necessary
		projectileParent = GameObject.Find("Projectiles");

		if (!projectileParent) {
			projectileParent = new GameObject("Projectiles");
		}

		SetMyLaneSpawner();
	}

	void Update() {
		animator.SetBool("isAttacking", IsAttackerAheadInLane());
		// if (IsAttackerAheadInLane()) {
		// 	animator.SetBool("isAttacking", true);
		// } else {
		// 	animator.SetBool("isAttacking", false);
		// }
	}

	bool IsAttackerAheadInLane() {
		// Exit if no attackers in lane
		if (myLaneSpawner.transform.childCount < 1) {
			return false;
		}
		foreach (Transform attacker in myLaneSpawner.transform) {
			if (attacker.transform.position.x > transform.position.x) {
				return true;
			}
		}
		// Attackers in lane, but behind us.
		return false;
	}

	// Look through all spawners, and set myLaneSpawner if found
	void SetMyLaneSpawner() {
		Spawner[] spawnerArray = GameObject.FindObjectsOfType<Spawner>();

		foreach (Spawner spawner in spawnerArray)
		{
			if (spawner.transform.position.y == Mathf.RoundToInt(transform.position.y)) {
				myLaneSpawner = spawner;
				return;
			}
		}
		if (!myLaneSpawner) {
			Debug.LogError(name + " can't find spawner in lane!");
		}
	}

	private void Fire() {
		GameObject newProjectile = Instantiate(projectile) as GameObject;
		newProjectile.transform.parent = projectileParent.transform;
		newProjectile.transform.position = gun.transform.position;
	}
}
