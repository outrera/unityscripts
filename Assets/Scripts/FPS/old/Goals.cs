using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class Goals : MonoBehaviour {

	//This script does too much.  Is there a way to separate it out?
	//It takes care of the logic of timed games, goal based games, player damage, and collectables
	

	//Is there a goal block in your game?
	public bool goal = true;
	private bool goalReached = false;
	
	//timer variables
	public bool timed = false;
	public float timer = 30;
	private float timeLeft = 30;

	//health variables
	public bool health = false;
	public int healthCount = 3;
	private int maxHealth = 3;
	
	//does the game have collectables
	public bool collect = false;
	public int collectCount = 3;
	private int collected = 0;


	public Text healthText;
	public Text collectText;
	public Text timerText;
	public Text endText;
	public Image overlay;
	public GameObject player;



	// Use this for initialization
	void Start () {
		if (health == false) 
		{
			healthText.enabled = false;
		}
		if (timed == false) 
		{
			timerText.enabled = false;
		}
		if (collect == false)
		{
			collectText.enabled = false;
		}
		timeLeft = timer;
		maxHealth = healthCount;
		overlay.CrossFadeAlpha(0.01f, 0, false);
		timerText.text = "Time: " + timer.ToString();
		healthText.text = "Health: " + healthCount.ToString() + "/" + maxHealth.ToString();
		collectText.text = "Collected: " + collected.ToString() + "/" + collectCount.ToString(); 

	}
	
	// Update is called once per frame
	void Update () {
		if (goal) {CheckGoal();}
		if (timed) {CheckTimer();}
		if (health) {CheckHealth();}
		if (collect) {CheckCollect();}
	}

	void CheckTimer() 
	{
		timeLeft = timer - Time.time;
		timerText.text = "Time: " + Mathf.Floor(timeLeft).ToString();

		if (timeLeft <= 0)
		{
			Lose("Out of Time!");
		}

	}

	void CheckHealth()
	{
		if (player.GetComponent<FirstPersonController>().damage == true)
		{
			RaiseDamage();
			ClearDamage();
			player.GetComponent<FirstPersonController>().damage = false;
			healthText.text = "Health: " + healthCount.ToString() + "/" + maxHealth.ToString();
		}
	}

	void CheckCollect()
	{
		if (player.GetComponent<FirstPersonController>().collect == true)
		{
			collected++;
			player.GetComponent<FirstPersonController>().collect = false;
			collectText.text = "Collected: " + collected.ToString() + "/" + collectCount.ToString(); 
			if (collected >= collectCount)
			{
				CheckWin ();
			}
		}

	}

	void CheckGoal()
	{
		if (player.GetComponent<FirstPersonController>().goal == true)
		{
			goalReached = true;
			CheckWin();
		}
		player.GetComponent<FirstPersonController>().goal = false;
	}

	void Lose(string loseMessage)
	{
		FadeIn(endText);
		endText.text = loseMessage;
		Time.timeScale = 0.0f;
		overlay.CrossFadeAlpha(0.5f, 2, true);

	}

	void CheckWin()
	{
		FadeIn(endText);
		if (goal && collect) 
		{
			if (goalReached && (collected >= collectCount))
			{
				Win();
			}
			else if (goalReached && (collected < collectCount))
			{
				goalReached = false;
				Message("Find " + (collectCount-collected).ToString() + " more items");
			}
			else if (!goalReached && (collected >= collectCount))
			{
				Message("Go to the goal!");
			}
		}
		else
		{
			Win();
		}
	}

	void Win()
	{
		FadeIn(endText);
		Time.timeScale = 0.0f;
		endText.text = "You Win!";
		overlay.color = Color.green;
		overlay.CrossFadeAlpha(0.5f, 2.0f, true);

	}

	void RaiseDamage()
	{
		overlay.CrossFadeAlpha(3.0f, 0.1f, false);
		healthCount--;
		if (healthCount <= 0)
		{
			Lose ("Too Many Hits!");
		}
	}

	void ClearDamage()
	{
		overlay.CrossFadeAlpha(0.01f, 2.0f, false);
	}

	void Message(string message)
	{
		endText.text = message;
		FadeOut(endText);
	}

	void FadeOut(Graphic graphic) 
	{
		graphic.CrossFadeAlpha(0.01f, 2.0f, false);
	}

	void FadeIn(Graphic graphic)
	{
		graphic.CrossFadeAlpha(10.0f, 0.0f, false);
	}
	void ClearEndText()
	{
		endText.text = "";
	}



}
