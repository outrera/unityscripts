using UnityEngine;
using System.Collections;
//for the score
using UnityEngine.UI;

public class Collect : MonoBehaviour 
{
    //does the game have collectables
	public bool useCollect = true;
	private bool collect = false;
	public int collectCount = 3;
	public int collected = 0;
    //public bool collect = false;
    public Text collectText;
    
    void Start()
    {
        if (!useCollect)
		{
			collectText.enabled = false;
		}
        collectText.text = "Collected: " + collected.ToString() + "/" + collectCount.ToString();
    }
    
    void Update()
    {
        if (useCollect) {CheckCollect();}
    }
    
    
    void OnTriggerEnter(Collider other) 
	{
		if (other.gameObject.CompareTag ( "Collect"))
		{
			other.gameObject.SetActive (false);
			collect = true;
		}  
	} 
    
    void CheckCollect()
	{
		if (collect == true) {
			collected++;
			collect = false;
			collectText.text = "Collected: " + collected.ToString () + "/" + collectCount.ToString (); 
			if (collected >= collectCount) {
				Debug.Log ("All Collected");
				//GetComponent<Basics> ().CheckWin ();
				GetComponent<Basics>().collected = collected;
				GetComponent<Basics>().CheckWin();
			}
		}
	}
    
}