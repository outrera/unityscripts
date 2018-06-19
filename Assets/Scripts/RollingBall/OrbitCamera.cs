using UnityEngine;
using System.Collections;

//moves the camera around an object and rotates around it based on input
public class OrbitCamera : MonoBehaviour {

	public float turnSpeed = 4.0f;
	public Transform player;
	private Vector3 offset;

	// Use this for initialization
	void Start ()
	{
		offset = player.position - transform.position;
	}
	
	void LateUpdate()
	{
		transform.position = player.position + offset;
		transform.LookAt (player.position);
		offset = Quaternion.AngleAxis (Input.GetAxis ("Horizontal") * turnSpeed, Vector3.up) * offset;

	}
}


