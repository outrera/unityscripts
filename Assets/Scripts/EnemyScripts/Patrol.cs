using UnityEngine;
using System.Collections;

public enum PatrolDirection {x, y, z}


public class Patrol : MonoBehaviour {

	public float speed = 0.1f;
	public float distance = 10.0f;
	public float traveled = 0.0f;
	public PatrolDirection axis;



	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	switch (axis)
	{
		case PatrolDirection.x: 
			transform.Translate(speed, 0.0f, 0.0f);
			traveled = traveled + Mathf.Abs(speed);
			CheckDistance();
			//transform.position.x = transform.position.x + speed;
			break;
		case PatrolDirection.y:
			transform.Translate(0.0f, speed, 0.0f);
			traveled = traveled + Mathf.Abs(speed);
			CheckDistance();
			//transform.position.y = transform.position.y + speed;
			break;
		case PatrolDirection.z:
			transform.Translate(0.0f, 0.0f, speed);
			traveled = traveled + Mathf.Abs(speed);
			CheckDistance();
			//transform.position.z = transform.position.z + speed;
			break;
	}
	}

//	void OnTriggerEnter(Collider other) {
//		if (other.gameObject.CompareTag ("Wall"))
//		{
//			speed = -speed;
//		}
//
//	}

	void CheckDistance() 
	{
		if (traveled >= distance) {
			speed = -speed;
			traveled = 0;
		}

	}
}
