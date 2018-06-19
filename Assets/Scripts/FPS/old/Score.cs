using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Score : MonoBehaviour {


	//for enemy hit and collection
	public bool damage = false;
	public bool collect = false;
	public bool goal = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other) 
	{
		if (other.gameObject.CompareTag ( "Collect"))
		{
			other.gameObject.SetActive (false);
			collect = true;
		}
		if (other.gameObject.CompareTag ( "Enemy"))
		{
			damage = true;
		}
		if (other.gameObject.CompareTag ( "Goal"))
		{
			goal = true;
		}
	}
}
