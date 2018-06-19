using UnityEngine;
using System.Collections;


//this script makes an enemy chase a player if they enter a certain collider area
public class EnemyUI : MonoBehaviour {

	Rigidbody rb;
	Vector3 originalPosition;
	private bool chasing;
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
		originalPosition = transform.position;
		chasing = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (originalPosition != transform.position && chasing == false) {
			transform.position = Vector3.Lerp(transform.position, originalPosition, 0.005f);
		}
	}

	void OnTriggerStay(Collider other)
	{
		if (other.CompareTag("Player"))
		{
			chasing = true;
			transform.LookAt(other.transform);
			transform.position = Vector3.Lerp(transform.position, other.transform.position, 0.005f);
			//rb.AddForce((transform.position-other.transform.position).normalized * 10);
			//rb.AddForce(other.transform.position * 10);
		}

	}
	void OnTriggerExit(Collider other)
	{
		if (other.CompareTag ("Player")) {
			chasing = false;
		}
	}
}
