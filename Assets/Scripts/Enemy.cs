using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour {

	[SerializeField]
	private Transform exitPoint;
	[SerializeField]
	private float navigationUpdate = 0;
	private Transform enemy;
	private float navigationTime = 2.0f;
	private float moveSpeed = 0.05f;
	private bool landed = false;

	// Use this for initialization
	void Start () {
		enemy = GetComponent<Transform>();
	}

	// Update is called once per frame
	void Update () {
		if (GameManager.Instance.getScore() > 20) {
			//moveSpeed = 0.1f;
		}
		if(!landed){
			//navigationTime += Time.deltaTime;
			if (navigationTime > navigationUpdate) {
					//Debug.Log("Moving towards end");
					enemy.position = Vector3.MoveTowards(enemy.position, exitPoint.position, moveSpeed * navigationTime);
				  landed = true;
					//navigationTime = 1;
			}
		}
	}

	void OnTriggerEnter(Collider other){
	  if (other.tag == "Player") {
			//Debug.Log("Collision Triggered");

		}
		else if (other.tag == "Finish"){
			//Debug.Log("Collision Triggered");
			GameManager.Instance.removeEnemyFromScreen();
			Destroy(gameObject);
		}
	}
}
