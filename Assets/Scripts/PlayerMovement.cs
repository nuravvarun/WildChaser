using UnityEngine;
using System.Collections;
using CnControls;
using System.Collections.Generic;

public class PlayerMovement : MonoBehaviour {

	public float speed 			= 12.0f;
	public float reverseSpeed	= 5.0f;
	public float turnSpeed		= 0.6f;
	public float currentSpeed   = 0.0f;

	public float moveDirection = 0.0f;
	public float turnDirection = 0.0f;

	public Animator anim;

	public float turnValue;
	public GameObject[] locations;
	public GameObject nitro;

	// Use this for initialization
	void Start () {
		InvokeRepeating ("spawnnitro", 1.0f, 1.0f);

		//spawnnitro ();
		//anim = GetComponent<Animator>();
	
	}
	void spawnnitro(){

		int spawn = Random.Range (0, locations.Length);
		var pos = new Vector3 (0f, 1.2f, 0f);

		var clonenitro=Instantiate (nitro,locations[spawn].transform.position+pos,locations[spawn].transform.localRotation);
		Destroy (clonenitro, 5);
	
	}
	// Update is called once per frame
	void FixedUpdate () {
		
		turnValue = CnInputManager.GetAxis ("Vertical") ;
		currentSpeed = Mathf.Abs (transform.InverseTransformDirection (GetComponent<Rigidbody>().velocity).z);


		//ANGULAR DRAG VARS
		float maxAngularDrag = 2.5f;
		float currentAngularDrag = 0.5f;
		float aDragLerpTime = currentSpeed * 0.1f;

		//DRAG VARS
		float maxDrag = 1.0f;
		float currentDrag = 2.5f;
		float dragLerpTime = currentSpeed * 0.1f;

		//MASS VARS
		float maxMass = 2.5f;
		float currentMass = 1f;
		float massLerpTime = currentSpeed * 0.1f;

		float myAngularDrag = Mathf.Lerp (maxAngularDrag, currentAngularDrag, aDragLerpTime);
		float myDrag = Mathf.Lerp (maxDrag, currentDrag, dragLerpTime);
		float myMass = Mathf.Lerp (maxMass, currentMass, massLerpTime);


		//CAR MOVEMENTS
		if (CnInputManager.GetAxis ("Vertical") > 0.0f) {
			moveDirection = CnInputManager.GetAxis ("Vertical") * reverseSpeed;
			GetComponent<Rigidbody> ().AddRelativeForce (0, 0, moveDirection);



			if (currentSpeed > 0.05f) {
				turnDirection = CnInputManager.GetAxis ("Horizontal") * turnSpeed;

				//turnValue = CnInputManager.GetAxis ("Vertical");
			GetComponent<Rigidbody>().transform.Rotate(0,turnDirection,0,Space.Self);
			//	GetComponent<Rigidbody> ().AddRelativeTorque (0, turnDirection, 0,ForceMode.Force);
			}
		}

		if (CnInputManager.GetAxis ("Vertical") < 0.0f) {
			moveDirection = CnInputManager.GetAxis ("Vertical") * speed;
			GetComponent<Rigidbody> ().AddRelativeForce (0, 0, moveDirection);	

			if (currentSpeed > 0.05f) {
				turnDirection = CnInputManager.GetAxis ("Horizontal") * turnSpeed;
				GetComponent<Rigidbody>().transform.Rotate(0,-turnDirection,0,Space.Self);
				//	GetComponent<Rigidbody> ().AddRelativeTorque (0, -turnDirection, 0,ForceMode.Force);
			
			}
		}

		//Setting Player Physics
		GetComponent<Rigidbody>().angularDrag = myAngularDrag;
		GetComponent<Rigidbody>().drag = myDrag;
		//GetComponent<Rigidbody>().angularDrag = myMass;

		//PLAYER ANIMATIONS
		//anim.SetFloat("speed", Mathf.Abs (currentSpeed));
		//turnPlayerTiers ();
	}

	private void turnPlayerTiers()
	{
		turnValue = CnInputManager.GetAxis ("Horizontal");
		bool isTurningRight = false;
		bool isTurningLeft = false;
		float ax =  CnInputManager.GetAxis ("Horizontal");
		if (ax < 0) 
		{

			isTurningRight = true;
			isTurningLeft = false;
		} 

		else if (ax > 0) 
		{
			isTurningRight = false;
			isTurningLeft = true;
		} 

		else 
		{
			isTurningRight = false;
			isTurningLeft = false;
		}

		anim.SetBool ("turnRight", isTurningRight);
		anim.SetBool ("turnLeft", isTurningLeft);
	}
}