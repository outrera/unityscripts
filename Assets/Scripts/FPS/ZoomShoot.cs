using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoomShoot : MonoBehaviour {
    public Camera camera;
    float originalFov;
	// Use this for initialization
	void Start () {
        originalFov = camera.fieldOfView;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown("z"))
        {
            camera.fieldOfView = 10;
        }
        if (Input.GetKeyUp("z"))
        {
            camera.fieldOfView = originalFov;
        }
	}
}
