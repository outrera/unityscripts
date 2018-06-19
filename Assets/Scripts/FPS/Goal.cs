using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class Goal : MonoBehaviour 
{
    //Is there a goal block in your game?
	public bool useGoal = true;
	public bool goal = false;
	public bool goalReached = false;
    
    void OnTriggerEnter(Collider other) 
	{
		if (other.gameObject.CompareTag ( "Goal"))
		{
			goal = true;
		}
	}
    
    void Update () 
    {
		if (goal) {CheckGoal();}
	}
    
    void CheckGoal()
	{
		if (goal == true)
		{
			goalReached = true;
			GetComponent<Basics>().goalReached = goalReached;
			GetComponent<Basics>().CheckWin();
			goalReached = false;
		}
		goal = false;
	}
    
}