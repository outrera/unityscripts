using UnityEngine;
using System.Collections;
using UnityEngine.AI;

//this script makes an enemy chase a player if they enter a certain collider area
public class EnemyUI : MonoBehaviour {
    NavMeshAgent agent;
	Rigidbody rb;
	Vector3 originalPosition;
	private bool chasing;
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
        agent = GetComponent<NavMeshAgent>();
		originalPosition = transform.position;
		chasing = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (originalPosition != transform.position && chasing == false) {
            agent.SetDestination(originalPosition);
            transform.LookAt(originalPosition);
		}
	}

	void OnTriggerStay(Collider other)
	{
		if (other.CompareTag("Player"))
		{
			chasing = true;
			transform.LookAt(other.transform);
			//transform.position = Vector3.Lerp(transform.position, other.transform.position, 0.005f);
            agent.SetDestination(other.transform.position);
		}

	}
	void OnTriggerExit(Collider other)
	{
		if (other.CompareTag ("Player")) {
			chasing = false;
		}
	}
}
