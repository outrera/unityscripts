using UnityEngine;
using System.Collections;

public class KeyCount : MonoBehaviour {

	int keys = 0;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other)
	{
		int tagNum;
		string tagText = other.tag;
	
		if (other.CompareTag ("key")) {
			keys++;
		}
		int.TryParse (tagText, out tagNum);
		if (tagNum != 0)
		{
			if (keys >= tagNum)
			{
				keys -= tagNum;
				other.gameObject.SetActive(false);
			}
		}
	} 

}
