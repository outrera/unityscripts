using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class Basics : MonoBehaviour 
{
    public Text endText;
    public Image overlay;
	public bool killAll;
	public bool goalReached;
	public int collectCount;
	public int collected;
	public bool useCollectable;
	public bool useGoal;
    //public GameObject player;  //need this?

    void Start()
    {
        overlay.CrossFadeAlpha(0.00f, 0, false);
    }

	void Update()
	{
		if (useGoal) {
			goalReached = GetComponent<Goal> ().goalReached;
		}
		if (useCollectable) {
			collectCount = GetComponent<Collect> ().collectCount;
			collected = GetComponent<Collect> ().collected;
		}
		//CheckWin ();
	}

    public void Message(string message)
	{
		FadeIn (endText);
		endText.text = message;
		FadeOut(endText);
	}

	void FadeOut(Graphic graphic) 
	{
		graphic.CrossFadeAlpha(0.00f, 2.0f, false);
	}

	void FadeIn(Graphic graphic)
	{
		graphic.CrossFadeAlpha(10.0f, 0.0f, false);
	}
	void ClearEndText()
	{
		endText.text = "";
	}
    
    public void Lose(string loseMessage)
	{
		FadeIn(endText);
		endText.text = loseMessage;
		Time.timeScale = 0.0f;
		overlay.CrossFadeAlpha(0.5f, 2, true);
	}
    
    public void CheckWin()
	{
		if (killAll) 
		{
				GameObject[] enemies = GameObject.FindGameObjectsWithTag ("Enemy");
				if (enemies.Length > 0) {	
					Message ("Kill " + enemies.Length + " more enemies.");
					return;
				}
		}
		//FadeIn(endText);
		if (useGoal && useCollectable && GetComponent<Goal> ().useGoal && GetComponent<Collect> ().useCollect) {   
			
			if (goalReached && (collected >= collectCount)) {
				Win ();
			} else if (goalReached && (collected < collectCount)) {
				goalReached = false;
				Message ("Find " + (collectCount - collected).ToString () + " more items");
			} else if (!goalReached && (collected >= collectCount)) {
				Message ("Go to the goal!");
			} else {
				Debug.Log ("Nope");
				Debug.Log (collected);
				Debug.Log (collectCount);
				Debug.Log (goalReached);
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
}

