using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class NewBehaviourScript : MonoBehaviour {
	public Button mplay;
	// Use this for initialization
	void Start () {
		mplay = GetComponent<Button>();
	}
	
	public void play(){
		Application.LoadLevel (1);
	}
	public void exit(){
		Application.Quit ();
	}// Update is called once per frame
	void Update () {
	
	}
}
