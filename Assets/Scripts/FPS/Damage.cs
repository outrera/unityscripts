using UnityEngine;
using System.Collections;
using UnityEngine.UI;

//basic damage class
//sets health and checks collisions for objects with the tag of enemy

public class Damage : MonoBehaviour {
    
    //health variables
    private bool damage = false;
	public bool useHealth = false;
	public int healthCount = 3;
    public int maximumHealth = 3;
    public int healthPickUpValue = 1;
	private int originalHealth = 3;
    public Text healthText;
    
    void Start () 
    {
		if (useHealth == false) 
		{
			healthText.enabled = false;
		}

		originalHealth = healthCount;
        UpdateHealthText();
	}
    
    void Update () 
    {
		if (useHealth) {CheckHealth();}
	}
    
    void OnTriggerEnter(Collider other) 
	{
		if (other.gameObject.CompareTag ( "Enemy"))
		{
			damage = true;
		}
        if (other.gameObject.CompareTag("Health"))
        {
            if (healthCount < maximumHealth)
            {
                healthCount += healthPickUpValue;
                other.gameObject.SetActive(false);
                UpdateHealthText();
            }
        }
	}
    
    void CheckHealth()
	{
		if (damage == true)
		{
			RaiseDamage();
			ClearDamage();
			damage = false;
            UpdateHealthText();
		}
	}
    
    void RaiseDamage()
	{
		GetComponent<Basics>().overlay.color = Color.red;
		GetComponent<Basics>().overlay.CrossFadeAlpha(3.0f, 0.1f, false);
		healthCount--;
		if (healthCount <= 0)
		{
			GetComponent<Basics>().Lose ("Too Many Hits!");
		}
	}

	void ClearDamage()
	{
		GetComponent<Basics>().overlay.CrossFadeAlpha(0.01f, 2.0f, false);
	}

    void UpdateHealthText()
    {
        healthText.text = "Health: " + healthCount.ToString() + "/" + originalHealth.ToString();
    }

}