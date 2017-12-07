using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour {

	[SerializeField]
	private GameObject[] exitPoint;
	[SerializeField]
	private float navigationUpdate = 0;
	private Transform spawnPoint;
	private Transform enemy;
	private float navigationTime = 2.0f;
	private float moveSpeed = 5f;
	private bool landed = false;
	private int randomSpawn = 0;
	private Collider sphereCollider;
	private Rigidbody enemyBody;
	// Use this for initialization
	void Start () {
		enemy = GetComponent<Transform>();
		sphereCollider = GetComponent<Collider>();
		enemyBody = GetComponent<Rigidbody>();
		randomSpawn = Random.Range (0, 7);
		spawnPoint = exitPoint[randomSpawn].transform;
	}

	// Update is called once per frame
	void Update () {
		if (GameManager.Instance.getScore() > 100) {
			//moveSpeed = 0.1f;
		}
			//navigationTime += Time.deltaTime;
			if (enemy.position == spawnPoint.position) {
					landed = true;
					enemyBody.useGravity = true;
					sphereCollider.enabled = true;
					enemyBody.isKinematic = false;
			}
			if (navigationTime > navigationUpdate && !landed) {
					//Debug.Log("Moving towards end");
					enemy.position = Vector3.MoveTowards(enemy.position, spawnPoint.position, moveSpeed * Time.deltaTime);
					//navigationTime = 1;
			}
	}

	void OnTriggerEnter(Collider other){
	  if (other.tag == "Player") {
			//Debug.Log("Collision Triggered");
			GameManager.Instance.Death();

		}
		else if (other.tag == "Finish"){
			//Debug.Log("Collision Triggered");
			GameManager.Instance.removeEnemyFromScreen();
			Destroy(gameObject);
		}
	}
}
