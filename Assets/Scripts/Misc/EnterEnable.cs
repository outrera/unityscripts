using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterEnable : MonoBehaviour {

	public GameObject objectToEnable;
	public bool collectAll;
	// Use this for initialization
	void Start () {
		objectToEnable.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		if (collectAll) {
			GameObject[] collected = GameObject.FindGameObjectsWithTag ("Collect");
			if (collected.Length > 0) {	
				objectToEnable.SetActive(true);	
			}
		}
	}

	void OnTriggerEnter(Collider other) {
		
		if (other.CompareTag("Player")) {
			if (collectAll) {
				GameObject[] collected = GameObject.FindGameObjectsWithTag ("Collect");
				if (collected.Length > 0) {	
					objectToEnable.SetActive(true);	
				}
			}
			else objectToEnable.SetActive(true);
		}
	}
}
