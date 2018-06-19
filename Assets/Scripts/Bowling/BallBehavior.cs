using UnityEngine;
using System.Collections;

public class BallBehavior : MonoBehaviour {
	public float force;
	public float forceMax = 1600;
	public Rigidbody rb;
	public Vector3 v3 = new Vector3(0.0f, 0.0f, 0.0f);

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody>();
		print("Hi mom");
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButton("Jump")) {
			force = force + 100.0f;
			if (force > forceMax)
			{
				force = forceMax;
			}
		}
		if (Input.GetButtonUp("Jump")) {
			print(force);
			rb.AddForce(0.0f, 0.0f, force);
		}
	}

	void FixedUpdate() {

	}
}
