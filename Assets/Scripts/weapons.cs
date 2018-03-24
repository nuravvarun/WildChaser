using UnityEngine;

using System.Collections;
using CnControls;

public class weapons : MonoBehaviour {

	public Bullet bullet;

	// Update is called once per frame
	void FixedUpdate ()
	{
		if (CnInputManager.GetAxis ("Horizontalw")!=0f || CnInputManager.GetAxis ("Verticalw")!=0f) 
		{
			float turretY = calculateAngle (CnInputManager.GetAxis ("Horizontalw"), CnInputManager.GetAxis ("Verticalw"));

			if (CnInputManager.GetAxis ("Horizontalw") < 0)
				turretY += 180;	

			turretY += 90;

			transform.rotation = Quaternion.Euler(90, turretY, 0);
		}



	/*	if (Mathf.Abs(CnInputManager.GetAxis ("Horizontalw")) == 1.0f || Mathf.Abs(CnInputManager.GetAxis ("Verticalw")) == 1.0f) 
		{
			Instantiate (Resources.Load("Bullet"), transform.position, transform.rotation);
		}*/

	}

	private float calculateAngle(float baseOfTriangle, float perpendicular)
	{
		float angleInRadian = Mathf.Atan (perpendicular / baseOfTriangle);
		return angleInRadian * -180 / Mathf.PI;
	}
}