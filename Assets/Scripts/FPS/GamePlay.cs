using UnityEngine;
using System.Collections;
//for the score
using UnityEngine.UI;

public class GamePlay : MonoBehaviour {
	
	// public vars
	//public float mouseSensitivityX = 3.5f;
	//public float mouseSensitivityY = 3.5f;
	//public float walkSpeed = 6;
	//public float jumpForce = 220;
	//public LayerMask groundedMask;
	//CursorLockMode wantedMode;

	// System vars
	//bool grounded;
	//Vector3 moveAmount;
	//Vector3 smoothMoveVelocity;
	//float verticalLookRotation;
	//Transform cameraTransform;
	//Rigidbody rb;

	//for enemy hit and collection
	public bool damage = false;
	public bool collect = false;
	public bool goal = false;

	void Awake() {


	}

	void Start() {
		//Cursor.lockState = wantedMode;
		//Cursor.visible = false;
		//wantedMode = CursorLockMode.Locked;
		//cameraTransform = Camera.main.transform;
		//rb = GetComponent<Rigidbody> ();
	}

	
	void Update() {
		
		// Look rotation:
		//transform.Rotate(Vector3.up * Input.GetAxis("Mouse X") * mouseSensitivityX);
		//verticalLookRotation += Input.GetAxis("Mouse Y") * mouseSensitivityY;
		//verticalLookRotation = Mathf.Clamp(verticalLookRotation,-60,60);
		//cameraTransform.localEulerAngles = Vector3.left * verticalLookRotation;
		
		// Calculate movement:
		//float inputX = Input.GetAxisRaw("Horizontal");
		//float inputY = Input.GetAxisRaw("Vertical");
		
		//Vector3 moveDir = new Vector3(inputX,0, inputY).normalized;
		//Vector3 targetMoveAmount = moveDir * walkSpeed;
		//moveAmount = Vector3.SmoothDamp(moveAmount,targetMoveAmount,ref smoothMoveVelocity,.15f);
		
		// Jump
		//if (Input.GetButtonDown("Jump")) {
		//	if (grounded) {
		//		rb.AddForce(transform.up * jumpForce);
		//		Debug.Log ("Jump!");
		//	}
		//}
		
		// Grounded check
		//Ray ray = new Ray(transform.position, -transform.up);
		//RaycastHit hit;
		
		//if (Physics.Raycast(ray, out hit, 2f + .1f, groundedMask)) {
		//if (Physics.Raycast(transform.position, -transform.up, 3)) {
		//	grounded = true;
		//}
		//else {
		//	grounded = false;
		//}

		//if (Input.GetKeyDown (KeyCode.Escape)) 
		//{
		//	Cursor.lockState = wantedMode = CursorLockMode.None;
		//	Cursor.visible = true;
		//	Debug.Log ("Free");
		//}
	}
	
	void FixedUpdate() {
		// Apply movement to rigidbody
		//Vector3 localMove = transform.TransformDirection(moveAmount) * Time.fixedDeltaTime;
		//rb.MovePosition(rb.position + localMove);
	}

	void OnTriggerEnter(Collider other) 
	{
		if (other.gameObject.CompareTag ( "Collect"))
		{
			other.gameObject.SetActive (false);
			collect = true;
		}
		if (other.gameObject.CompareTag ( "Enemy"))
		{
			damage = true;
		}
		if (other.gameObject.CompareTag ( "Goal"))
		{
			goal = true;
		}
	}
}