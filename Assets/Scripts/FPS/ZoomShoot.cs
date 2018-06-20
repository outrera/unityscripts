using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoomShoot : MonoBehaviour {
    public Camera thisCamera;
    float originalFov;
	// Use this for initialization
	void Start () {
        originalFov = thisCamera.fieldOfView;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown("z"))
        {
            thisCamera.fieldOfView = 10;
        }
        if (Input.GetKeyUp("z"))
        {
            thisCamera.fieldOfView = originalFov;
        }
	}
}
