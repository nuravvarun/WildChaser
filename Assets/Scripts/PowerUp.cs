using UnityEngine;
using System.Collections;

public class PowerUp : MonoBehaviour {

	private GameObject playerGameObject;
	private GameObject enemyGameObject;
	private GameObject enemy1GameObject;
	// Use this for initialization
	void Start () {
		
		playerGameObject = GameObject.FindGameObjectWithTag ("Player");
		//enemyGameObject= GameObject.FindGameObjectWithTag ("Enemy1");
		//enemy1GameObject= GameObject.FindGameObjectWithTag ("Enemy2");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other)
	{
		PlayerProperties playerProperties = playerGameObject.GetComponent<PlayerProperties> ();

		if (other.tag == "Player") {
			Debug.Log ("Got a turbo.");
			DestroyObject(this.gameObject);

			ApplyPowerUp (playerProperties);
			Debug.Log ("Called ApplyPU");
		}
	}

	void ApplyPowerUp(PlayerProperties playerStatus)
	{
		if (playerStatus.playerState == PlayerProperties.PlayerState.Normal) {
			Debug.Log ("Changing state and status");
			playerStatus.playerState = PlayerProperties.PlayerState.Turbo;
			playerStatus.hasTurbo = true;
			playerStatus.changeState = true;
		}

		return;
	}
}
