using UnityEngine;
using System.Collections;

public class ParticleSystemDestroy : MonoBehaviour
{
	bool destroyed;

	private void Start()
	{
		destroyed = false;
	}

	private void Update()
	{
		if (this.tag == "Particle" && destroyed == false) 
		{
			destroyed = true;
			Destroy (gameObject, GetComponent<ParticleSystem> ().duration); 
		}
	}


}