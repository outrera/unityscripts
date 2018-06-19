using UnityEngine;
using System.Collections;

public class CameraScript : MonoBehaviour {
	public GameObject ball;
	private Vector3 v3 = new Vector3(0.0f, 0.0f, 0.0f);
	private Transform trans;
	private float location;
	private float oldLocation;

	// Use this for initialization
	void Start () {
		location = ball.transform.position.z;
		oldLocation = ball.transform.position.z;
		trans = GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update () {
		oldLocation = location;
		location = ball.transform.position.z;
		v3.z = location - oldLocation;
		trans.Translate(v3, Space.World);
		//trans.position.z = ball.transform.position.z;
	}
}
