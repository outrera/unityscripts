using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class Timer : MonoBehaviour {

    //timer variables
	public bool useTimer = false;
	public float timer = 30;
	public Text timerText;
	private float timeLeft = 30;
    
    
    void Start()
    {
        if (useTimer == false) 
        {
            timerText.enabled = false;
        }    
        timeLeft = timer;
        timerText.text = "Time: " + timer.ToString();
    }
    void Update () {
		if (useTimer) {CheckTimer();}
	}

	void CheckTimer() 
	{
		timeLeft = timer - Time.time;
		timerText.text = "Time: " + Mathf.Floor(timeLeft).ToString();

		if (timeLeft <= 0)
		{
			GetComponent<Basics>().Lose("Out of Time!");
		}

	}

}