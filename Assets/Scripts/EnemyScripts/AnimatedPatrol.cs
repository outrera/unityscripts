using UnityEngine;
using System.Collections;


//this class makes an object go back and forth a set distance.  It does not work for objects that must face a certain way.

public class AnimatedPatrol : MonoBehaviour {

	public float speed = 0.05f;
	public float distance = 10.0f;
	public float traveled = 0.0f;




	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate(0.0f, 0.0f, speed);
		traveled = traveled + Mathf.Abs(speed);
		CheckDistance();
	}


	void CheckDistance() 
	{
		if (traveled >= distance) {
			transform.Rotate(0.0f, 180.0f, 0.0f);
			//speed = -speed;
			traveled = 0;
		}

	}
}
