using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class FallLose : MonoBehaviour {
	//If you fall off the world, you lose.  The parameters need to be tweaked if you can jump in your game.
	//private bool lose;
	public Text textBox;
    public float minY = -2.0f;
    
	void Start ()
	{
		//lose = false;
	}
	
	void FixedUpdate ()
	{
        if (transform.position.y < minY) Lose();
  //      RaycastHit hit;
		//if(!Physics.Raycast(transform.position, Vector3.down, out hit, 1.0f))
		//{
		//	Lose();
		//}
	}

	void Lose() 
	{
		//textBox.text = "You Lose";
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        //Time.timeScale = 0.5f;
	}
}