using UnityEngine;
using System.Collections;

public class JumpBasic : MonoBehaviour {
	//Very Basic Jump Script- Doesn't check for ground.
	Rigidbody rb;
	public float jumpForce = 200.0f;
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void FixedUpdate () 
	{
		if (Input.GetButtonDown ("Jump")) 
		{
			print("jumping");
			rb.AddForce(Vector3.up * jumpForce);
		}
	}
}
