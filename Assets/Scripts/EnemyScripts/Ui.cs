using UnityEngine;
using System.Collections;

public class Ui : MonoBehaviour {

	public Transform goal;
	private Vector3 home;
	private NavMeshAgent agent;
	// Use this for initialization
	void Start () {
		home = GetComponent<Transform> ().position;
		agent = GetComponent<NavMeshAgent> ();

	}
	
	// Update is called once per frame
	void Update () {
		//agent.destination = goal.position;
	}

	void OnTriggerStay(Collider other)
	{
		if (other.gameObject.CompareTag("Player"))
		{
			agent.destination = goal.position;
		}

	}

	void OnTriggerExit(Collider other)
	{
		if (other.gameObject.CompareTag ("Player")) {
			agent.destination = home;
		}
	}

}
