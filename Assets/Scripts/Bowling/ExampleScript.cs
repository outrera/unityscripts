using UnityEngine;
using System.Collections;

public class ExampleScript : MonoBehaviour {

	public float speed = 0.0f;
	public float distance = 0.0f;
	public float time = 0.0f;

	// Use this for initialization
	void Start () 
	{

		speed = distance / time;
		if (distance != time) 
		{
			print ("Not the same!");
		}
		if (speed > 70 || speed < 40) 
		{
			print ("Don't to it!");
		}
		print ("You are travelig at " + speed + " miles per hour");
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
