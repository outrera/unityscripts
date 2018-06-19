using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Keys : MonoBehaviour {

	private List<string> keys = new List<string>();

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other)
	{
		
		if (other.tag.Contains ("key"))
		{
			keys.Add(other.tag.Substring(0, other.tag.IndexOf("key")));
			Debug.Log (other.tag.Substring (0, other.tag.IndexOf ("key")));
			other.gameObject.SetActive (false);
		}
		if (other.tag.Contains ("door")) {
			string door = other.tag.Substring (0, other.tag.IndexOf ("door"));
			if (keys.Contains(door)){
				keys.Remove(door);
				other.gameObject.SetActive(false);
			}
		}

	}

}
