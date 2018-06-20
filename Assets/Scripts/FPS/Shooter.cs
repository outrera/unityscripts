using UnityEngine;
using System.Collections;

public class Shooter : MonoBehaviour {


	public GameObject particles;
	public Camera thisCamera;
	public bool fps;
	public int damage = 1;
	public bool hasWeapon;
	public bool leaveMark;
	public bool makeParticles;
	public GameObject splat;
	private Quaternion splatRotation;

	// Use this for initialization
	void Start () {
		//camera = GetComponent<Camera>();
		leaveMark = false;
		//makeParticles = false;
	}

	// Update is called once per frame
	void Update () {
		Ray ray;
		if (fps)
		{
			ray = thisCamera.ScreenPointToRay(new Vector3(thisCamera.pixelWidth/2, thisCamera.pixelHeight/2, 0));
		}

		else 
		{
			ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		}
		//Debug.DrawRay(ray.origin, ray.direction * 50, Color.yellow);

		RaycastHit hit;
		Vector3 hitPosition;

		Vector3 fwd = transform.TransformDirection(Vector3.forward);
		Vector3 fwdFix = transform.TransformDirection(new Vector3(0.0f, 0.0f, 500.0f));
		fwdFix = fwdFix + fwd;
		//Debug.DrawRay(transform.position, fwdFix, Color.red, 1.0f);

		if (Input.GetButtonDown("Fire1") && hasWeapon)
		{

			//if (Physics.Raycast(transform.position, fwd, out hit, 50))
			if (Physics.Raycast (ray, out hit, 100))
			{
				Vector3 hitPoint = hit.point + (hit.normal * .01f);
				if (leaveMark && !hit.collider.CompareTag("Player"))
				{
					//splatRotation = Quaternion.LookRotation(hit.normal);

					//Instantiate(splat, hitPoint, splatRotation);
				}
				if (makeParticles)
				{
					Debug.Log("Make Particles");
					hitPosition = hit.point;
					GameObject newParticles = (GameObject)Instantiate(particles, hitPosition, Quaternion.identity);
					newParticles.tag = "Particle";

				}
				if (hit.collider.tag == "Enemy")
				{
					if (hit.collider.gameObject.GetComponent<HitPoints> () != null) {
						HitPoints enemyPoints = hit.collider.gameObject.GetComponent<HitPoints> ();
						enemyPoints.hitPoints -= damage;
						if (enemyPoints.hitPoints <= 0) {
							hit.collider.gameObject.SetActive (false);	
							GetComponent<Basics> ().CheckWin ();
						} else
							GetComponent<Basics> ().Message (enemyPoints.hitPoints.ToString());
					}
					else{
						hit.collider.gameObject.SetActive(false);
						GetComponent<Basics>().CheckWin ();
					}
				}
			}
		}
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag("Weapon"))	{
			hasWeapon = true;
			other.gameObject.SetActive (false);
		}

		if (other.gameObject.CompareTag("PowerUp"))	{
			damage++;
			other.gameObject.SetActive (false);
		}
	}

}
