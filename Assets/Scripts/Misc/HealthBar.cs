using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Animations;

public class HealthBar : MonoBehaviour {

	public Image bar;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		bar.rectTransform.SetSizeWithCurrentAnchors(UnityEngine.RectTransform.Axis.Horizontal, bar.rectTransform.rect.width - 1);
	}
}
