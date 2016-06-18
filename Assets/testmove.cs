using UnityEngine;
using System.Collections;

public class testmove : MonoBehaviour {

    public Rigidbody pill;
    public bool canJump;
    public float speed, maxSpeed;

	// Use this for initialization
	void Start ()
    {
        pill = GetComponent<Rigidbody>();   
	}
	
	// Update is called once per frame
	void Update ()
	{
		//Max speed

		if (pill.velocity.magnitude > maxSpeed) {
			pill.velocity = pill.velocity.normalized * maxSpeed;
		}

		if (pill.velocity [0] <= 10 || pill.velocity [0] >= -10 || pill.velocity [2] <= 10 || pill.velocity [2] >= -10) {
			//Movement controls
			if (Input.GetKey ("w")) {
				maxSpeed = 10;
				pill.AddForce (transform.forward * speed);
			} else {
				maxSpeed = 0;
			}
			if (Input.GetKey ("s")) {
				maxSpeed = 10;
				pill.AddForce (-transform.forward * speed);
			} else {
				//maxSpeed = 0;
			}
			if (Input.GetKey ("a")) {
				maxSpeed = 10;
				pill.AddForce (-transform.right * speed);
			} else {
				//maxSpeed = 0;
			}
			if (Input.GetKey ("d")) {
				maxSpeed = 10;
				pill.AddForce (transform.right * speed);
			} else {
				//maxSpeed = 0;
			}
			if (Input.GetKeyDown ("space")) {
				maxSpeed = 10;
			}
			//if (Input.GetKey("e"))
			//{ pill.transform.Rotate(Vector3.up, Space.Self); }
		}

		//Slowing
		if (pill.velocity [0] >= 0.2) {
			pill.AddForce (-transform.right * 10);
		}
		if (pill.velocity [0] <= -0.2) {
			pill.AddForce (transform.right * 10);
		}
		if (pill.velocity [2] >= 0.2) {
			pill.AddForce (-transform.forward * 10);
		}
		if (pill.velocity [2] <= -0.2) {
			pill.AddForce (transform.forward * 10);
		}

		//if (pill.velocity[0] <= 0.3 && pill.velocity[0] >= -0.3 || pill.velocity[2] <= 0.3 && pill.velocity[2] >= -0.3)


		//Jumping
        
		RaycastHit hit;
		float distance = 1.1f;

		if (Physics.Raycast (transform.position, Vector3.down, out hit, distance)) {
			canJump = true;
		}
		else{canJump = false;}
		if (canJump == false) {
			maxSpeed = 10;
		}

		if (Input.GetKey ("m")) {
			Debug.Log (pill.velocity);
		}

		if (canJump == true && Input.GetKeyDown ("space")) {
			pill.AddForce (transform.up * 300);
		}
	}}