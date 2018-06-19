using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boosties : MonoBehaviour {
    public bool unlimitedBoosts = false;
    public int boostsPerPickup = 5;
    public int startingBoosts = 5;
    public Text boostText;
    public int boostSeconds = 10;
    public bool useJumpPad;
    public float boostGravity = -1.0f;
    public float jumpPadPower = 30;
    private float timeLeft;
    private int boostsRemaining;
    private float distanceToTravel;
    

	// Use this for initialization
	void Start () {
        boostsRemaining = startingBoosts;
        if (boostText == null) boostText.text = "Boosts:" + boostsRemaining;
        
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown("g")  && (unlimitedBoosts || boostsRemaining > 0) && timeLeft <= 0 )
        {
            timeLeft = boostSeconds;
            Physics.gravity = new Vector3(0.0f, boostGravity, 0.0f);
            boostsRemaining--;
            if (boostText == null) boostText.text = "Boosts:" + boostsRemaining;
        }
        if (timeLeft <= 0)
        {
            Physics.gravity = new Vector3(0.0f, -9.81f, 0.0f);
        }
        if (distanceToTravel > 0)
        {
            float currentY = transform.position.y;
            Vector3 toPos = new Vector3(transform.position.x, currentY + distanceToTravel, transform.position.z);
            transform.position = Vector3.Lerp(transform.position, toPos, Time.deltaTime);
            distanceToTravel--;
            //Physics.gravity = new Vector3(0.0f, -1.0f, 0.0f);
        }  
        timeLeft -= Time.deltaTime;
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Boost"))
        {
            boostsRemaining += boostsPerPickup;
            other.gameObject.SetActive(false);
        }

        if (other.gameObject.CompareTag("JumpPad")) {
            distanceToTravel = jumpPadPower;
        }
    }
}
