using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class lap : MonoBehaviour {

	public Transform lappoint;
	public int lapno = 0;
	public Text txt;
	// Use this for initialization
	void start () {
		

	}

	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player") 
		{
			lapno += 1;
			txt.text = lapno + "/3";
		}
			
	}
	// Update is called once per frame
	void Update () {
	

	}
}
