using UnityEngine;
using System.Collections;
using UnityEngine.UI;

//basic damage class
//sets health and checks collisions for objects with the tag of enemy

public class Damage : MonoBehaviour {
    
    //health variables
    private bool damage = false;
    private bool hittable = true;
    public float hitDelay = 1.0f;
    private float hitTimer = 0.0f;
	public bool useHealth = false;
	public int healthCount = 3;
    public int maximumHealth = 3;
    public int healthPickUpValue = 1;
	private int originalHealth = 3;
    public Text healthText;
    public bool useFallDamage = false;
    private bool previouslyFalling = false;
    public float distanceForFallDamage = 20.0f;
    private float startYFallPosition = 0.0f;
    private bool takeFallDamage = false;
    private CharacterController cc;

    void Start () 
    {
		if (useHealth == false) 
		{
			healthText.enabled = false;
		}

		originalHealth = healthCount;
        UpdateHealthText();
        cc = GetComponent<CharacterController>();

	}
    
    void Update () 
    {
		if (useHealth) {CheckHealth();}
        hitTimer += Time.deltaTime;
        if (hitTimer > hitDelay)
        {
            hittable = true;
        }
        if (useFallDamage)
        {
            if (previouslyFalling == false)
            {
                if (cc.isGrounded == false)
                {
                    previouslyFalling = true;
                    startYFallPosition = transform.position.y;
                }
            }
            else
            {
                if (cc.isGrounded == true)
                {
                    previouslyFalling = false;
                    if (takeFallDamage)
                    {
                        damage = true;
                        takeFallDamage = false;
                    }
                }
                else
                {
                    if (startYFallPosition - transform.position.y > distanceForFallDamage)
                    {
                        takeFallDamage = true;
                    }
                }
            }
        }
	}
    
    void OnTriggerEnter(Collider other) 
	{
		if (other.gameObject.CompareTag ( "Enemy"))
		{
            if (hittable == true)
            {
                damage = true;
                hittable = false;
                hitTimer = 0.0f;
            }
		}
        if (other.gameObject.CompareTag("Health"))
        {
            if (healthCount < maximumHealth)
            {
                healthCount += healthPickUpValue;
                other.gameObject.SetActive(false);
                UpdateHealthText();
                GetComponent<Basics>().overlay.color = Color.green;
                GetComponent<Basics>().overlay.CrossFadeAlpha(3.0f, 0.1f, false);
                ClearDamage();
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