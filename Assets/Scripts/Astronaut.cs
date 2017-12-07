using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Astronaut : Singleton<Astronaut> {

	private Transform astronaut;
	private int target = 2;
	public float playerSpeed = 2.0f;
	private float navigationTime = 2.0f;
	[SerializeField]
	private Transform[] placeholderPoints;
	private float rightBound = 3.4f;
	private float leftBound = -5.66f;
	// Use this for initialization
	void Start () {
		//getCurrentLocation();
		astronaut = GetComponent<Transform>();
	}
	// Update is called once per frame
	void Update () {
		//getCurrentLocation();
		if (GameManager.Instance.getLife()) {
				astronaut.Translate(Input.GetAxis("Horizontal")*Time.deltaTime*playerSpeed,0f,0f);
				astronaut.position = new Vector3 (
				Mathf.Clamp(astronaut.position.x,leftBound,rightBound),
				-2.76f,
				-8.9f
				);
				/*
			if (Input.GetKeyDown(KeyCode.LeftArrow))
					 {
						 //if (destination >= 0) {

						 		target--;
								Debug.Log("Player moved to location: " + target.ToString());
								//astronaut.position = placeholderPoints[destination-1];
						 //}
					 }

					 if (Input.GetKeyDown(KeyCode.RightArrow))
					 {
						 //if (destination <= 3) {
						 target++;
						 Debug.Log("Player moved to location: " + target.ToString());
						 // }
					 }
					 */
		 }
	}

	void OnTriggerEnter(Collider other){
		if (other.tag == "Alien") {
			GameManager.Instance.Death();
			Destroy(gameObject);
			Debug.Log("Death!");
		}
	}
}
