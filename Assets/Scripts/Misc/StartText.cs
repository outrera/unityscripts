using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartText : MonoBehaviour {
    [Header("Start Text")]
    [Tooltip("Shows Text on Screen for x seconds")]
    public int secondsToShow = 5;
    public Text startText;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        startText.CrossFadeAlpha(0.0f, secondsToShow, false);
	}
}
