using UnityEngine;
using System.Collections;

public class PlayerProperties : MonoBehaviour {

	public enum PlayerState
	{
		Normal = 0,
		Turbo = 1

	}

	public PlayerState playerState = PlayerState.Normal;

	//Turbo Variables
	public GameObject turbo;
	//public Transform turboSocket;

	public bool hasTurbo = false;


	public bool changeState = false;
	public bool canPickUp = false;

	public float turboTimer = 3.0f;
	public float resetTurboTimer = 3.0f;
	public bool turboTimerActive = false;
	public float turboModifier = 3.0f;
	public float resetSpeed = 0.0f;
	public float resetturnspeed=0.0f;

	// Use this for initialization
	void Start () {
		GameObject player = GameObject.Find("Player");
		PlayerMovement playerMovement = gameObject.GetComponent<PlayerMovement> ();
		resetSpeed = playerMovement.reverseSpeed;
		resetturnspeed = playerMovement.turnSpeed;
	//turbo=GetComponent<GameObject>();
	
	}
	
	// Update is called once per frame
	void Update () {
		if (changeState) {
			SetPlayerState ();
		}

		if (hasTurbo) {
			PlayerMovement playerMovement = gameObject.GetComponent<PlayerMovement> ();

			GameObject cloneTurbo;

			if (Input.GetKeyDown (KeyCode.LeftAlt)) {
				//cloneTurbo = (GameObject)Instantiate (turbo, turboSocket.transform.position, transform.rotation);
			    //cloneTurbo.transform.parent = turboSocket;

				turboTimerActive = true;
				playerMovement.speed *= turboModifier;
				playerMovement.turnSpeed *= turboModifier;
			}

			if (turboTimerActive) {
				turboTimer -= Time.deltaTime;

				if (turboTimer <= 0.0f) {
					turboTimerActive = false;
					playerMovement.reverseSpeed = resetSpeed;

					turboTimer = resetTurboTimer;
					playerMovement.turnSpeed = resetturnspeed;

					playerState = PlayerState.Normal;
					changeState = true;
				}
			}

		}

	}

	void SetPlayerState()
	{
		PlayerMovement playerMovement = gameObject.GetComponent<PlayerMovement> ();

		switch (playerState) {

		case PlayerState.Normal:
			hasTurbo = false;
			turbo.SetActive (false);
			canPickUp = true;
		break;
		

		case PlayerState.Turbo:
			hasTurbo = true;
			turboTimerActive = true;
			playerMovement.reverseSpeed=40.0f;
			playerMovement.turnSpeed=3.0f;
			turbo.SetActive (true);
			//PlayAnimation("nitro");
			canPickUp = false;
		break;
		}
	}
}
