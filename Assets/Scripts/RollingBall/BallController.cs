using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
// Basic Ball Movement with Camera Controlling Rotation.

public class BallController : MonoBehaviour {
	//gives basic movement
	public float rotateSpeed = 40.0f;
	public float moveSpeed = 80.0f;
	public float maximumSpeed = 20.0f;
	public Camera mainCamera;
    public float turnSpeed = 4.0f;
    public float verticalCorrect = 0.0f;
    public float jumpForce = 200.0f;
    public int collectAmount = 0;
    public Text collectText;
    public Text winText;
    public Text healthText;
    public int health;
    public bool useGoal = false;

    private bool grounded = false;
    private float currentSpeed;
    private int collectCount = 0;
    private bool useHealth = false;
    private Rigidbody rb;
    private Vector3 offset;
    private Vector3 cameraForward;

    void Start () {
		rb = GetComponent<Rigidbody>();
        offset = transform.position - mainCamera.transform.position;
        winText.text = "";
        if (health > 0)
        {
            useHealth = true;
            healthText.text = "Health: " + health;
        }
        else healthText.text = "";
        if (collectAmount > 0)
            collectText.text = "Collected: " + collectCount;
        else collectText.text = "";
        Time.timeScale = 1;
    }

    private void Update()
    {
        if (Input.GetKeyDown("r"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        if (useHealth && health <= 0)
        {
            winText.text = "You Lose";
            Time.timeScale = 0;
        }
    }

    void FixedUpdate() {

        // check for ground collision
        if (Physics.Raycast(transform.position, Vector3.down, 1.51f))
        {
            grounded = true;
        }
        else { grounded = false; }

        float translation = Input.GetAxis("Vertical") * moveSpeed;
		float rotation = Input.GetAxis("Horizontal") * rotateSpeed;
        cameraForward = mainCamera.transform.forward.normalized;
        cameraForward.y = 0;

        if (Input.GetAxis("Vertical") != 0)
		{
            if (Input.GetAxis("Vertical") < 0)
			rb.AddForce (-cameraForward * moveSpeed); 
            else rb.AddForce(cameraForward * moveSpeed);

            //set max velocity
            float speed = Vector3.SqrMagnitude (rb.velocity);  // test current object speed
			if (speed > maximumSpeed)
			{
				float brakeSpeed = speed - maximumSpeed;  // calculate the speed decrease
				Vector3 normalisedVelocity = rb.velocity.normalized;
				Vector3 brakeVelocity = normalisedVelocity * brakeSpeed;  // make the brake Vector3 value
                brakeVelocity.y = 0.0f;
				rb.AddForce(-brakeVelocity);  // apply opposing brake force
			}

		}
		if (Input.GetAxis("Vertical") == 0)
		{
            Vector3 tempVelo = rb.velocity;
            tempVelo.x = 0;
            tempVelo.z = 0;
            rb.velocity = tempVelo;
		}

        if (Input.GetButtonDown("Jump") && grounded)
        {
            rb.AddForce(Vector3.up * jumpForce);
            grounded = false;
        }

        transform.Rotate(new Vector3(0, rotation, 0)); // Is this necessary?
		currentSpeed = Vector3.SqrMagnitude (rb.velocity);  // test current object speed
	}

    void LateUpdate()
    {
        mainCamera.transform.position = transform.position - offset;
        mainCamera.transform.LookAt(transform.position + new Vector3(0, verticalCorrect, 0));
        offset = Quaternion.AngleAxis(Input.GetAxis("Horizontal") * turnSpeed, Vector3.up) * offset;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (useGoal && other.gameObject.CompareTag("Goal")  &&
            (collectAmount <= 0 || (collectAmount <= collectCount))) {
            winText.text = "You Win!";
            Time.timeScale = 0;
        }
        if (collectAmount > 0 && other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            collectCount++;
            collectText.text = "Collected: " + collectCount;
            if (!useGoal && collectCount >= collectAmount)
            {
                winText.text = "You Win!";
                Time.timeScale = 0;
            }
        }
        if (useHealth && other.gameObject.CompareTag("Enemy"))
        {
            health--;
            healthText.text = "Health: " + health;
        }
    }

}