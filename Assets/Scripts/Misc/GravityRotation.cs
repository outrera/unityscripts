using UnityEngine;
using System.Collections;
using UnityEngine.UI;

//this makes an object rotate around another object.  it needs some tweaking.
public class GravityRotation : MonoBehaviour 
{
	public Transform target;
	//public Text info;
	
	void Update () 
	{
		Vector3 relativePos = (target.position + new Vector3(0, 1.5f, 0)) - transform.position;

		Quaternion rotation = Quaternion.LookRotation(relativePos);
		Quaternion current = transform.localRotation;
		Quaternion bob = Quaternion.identity;
		bob.SetFromToRotation(new Vector3(5, 0, 0), new Vector3(0, 0, 0));
		//info.text = bob.eulerAngles.ToString();

		//transform.localRotation = rotation;
		transform.localRotation = Quaternion.Slerp(current, rotation, Time.deltaTime);
		transform.Translate(0, 0, 5 * Time.deltaTime);
	}
}