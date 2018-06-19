using UnityEngine;
using System.Collections;

public class Rotator : MonoBehaviour {
	
	//this just makes an object spin in space.  Good for things that need to get your attention
	void Update () 
	{
		transform.Rotate (new Vector3 (15, 30, 45) * Time.deltaTime);
	}
}