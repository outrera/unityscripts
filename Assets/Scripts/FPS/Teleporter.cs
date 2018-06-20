using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// For this to work, the following lines need to be added to the FirstPersonController script
//public void SetRotation(Transform other)
//{
//    m_MouseLook.Init(other, m_Camera.transform);
//}

public class Teleporter : MonoBehaviour {

    public GameObject destination;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.gameObject.transform.position = destination.transform.position + destination.transform.forward;
            CharacterController cc = GetComponent<CharacterController>();
            other.gameObject.transform.Rotate(0, 30, 0);
            UnityStandardAssets.Characters.FirstPerson.FirstPersonController fpc = other.gameObject.GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>();
            var type = fpc.GetType();
            if (type.GetMethod("SetRotation") != null)
            {
                fpc.SetRotation(destination.transform);
            }
        }
    }
}
