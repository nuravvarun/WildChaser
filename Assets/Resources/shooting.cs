using UnityEngine;
using System.Collections;
using CnControls;

public class shooting : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (Mathf.Abs(CnInputManager.GetAxis ("Horizontalw")) == 1.0f || Mathf.Abs(CnInputManager.GetAxis ("Verticalw")) == 1.0f) 
		{
			Instantiate (Resources.Load("Bullet"), transform.position, transform.rotation);
		}

	}
}
