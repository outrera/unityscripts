using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterEnable : MonoBehaviour {

	public GameObject objectToEnable;
	public bool collectAll;
	public bool disableOnExit;
	// Use this for initialization
	void Start () {
		objectToEnable.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		if (collectAll) {
			GameObject[] collected = GameObject.FindGameObjectsWithTag ("Collect");
			if (collected.Length == 0) {	
				objectToEnable.SetActive(true);	
			}
		}
	}

	void OnTriggerEnter(Collider other) {
		
		if (other.CompareTag("Player")) {
			objectToEnable.SetActive(true);
		}
	}

	void OnTriggerExit(Collider other) {
		if (disableOnExit && other.CompareTag("Player")) {
			objectToEnable.SetActive(false);
		}
	}
}
