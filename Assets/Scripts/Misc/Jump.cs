using UnityEngine;
using System.Collections;

public class Jump : MonoBehaviour {

	Rigidbody rb;
	public float jumpForce = 200.0f;
	public bool jumpInAir = false;
	public bool grounded;
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
		grounded = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void FixedUpdate () 
	{
		if (jumpInAir == false) 
		{
			if(Physics.Raycast(transform.position, Vector3.down, 0.51f))
			{
				grounded = true;
				//print ("grounded");
			}
			else {grounded = false;}
		}
		if (Input.GetButtonDown ("Jump") && (grounded == true || jumpInAir == true) )
		{
			myJump();
		}
	}
	
	void myJump()
	{
			print("jumping");
			rb.AddForce(Vector3.up * jumpForce);
			grounded = false;
	}

}
