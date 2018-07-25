using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayNight : MonoBehaviour {

	public float secondsForCycle = 30;
	private float fractionToRotate = 0.0f;

	// Use this for initialization
	void Start () {
		fractionToRotate = 360.0f / secondsForCycle;
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate (new Vector3 (fractionToRotate, 0, 0) * Time.deltaTime);
	}
}
