using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Light : MonoBehaviour {

	[SerializeField]
  private GameObject light;
  private Light directionalLight;
	// Use this for initialization
	void Start () {
		directionalLight = GetComponent<Light>();
		directionalLight.enabled = true;
		//DontDestroyOnLoad(light);
	}

	// Update is called once per frame
	void Update () {

	}
}
