using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour
{
	public float speed = 0.3f;			//Move speed
	public float destroyTime;	//Time it takes to destroy
	public int damage = 20;		//Damage
	public int hit =0;
	void Start ()
	{
		//Start DestroyGo
		StartCoroutine("DestroyGo");
	}
	
	void FixedUpdate ()
	{
		//Move bullet
		//transform.Translate(new Vector3(0,0.5f,0) * speed * Time.deltaTime);
		GetComponent<Rigidbody> ().velocity=transform.TransformDirection(0,speed,0);
	}
	
	void OnTriggerEnter(Collider other)
	{
		//If we are in a enemy trigger
		if (other.tag == "Enemy") {
			hit = hit + 1;
			if (hit > 5) {
			
				//other.GetComponent<Enemy> ().Hit (damage);
				//Destroy
				Destroy (other.gameObject);
			
			}
		}
			//Hit enemy
		//	}
	}

	IEnumerator DestroyGo()
	{
		//Wait
        yield return new WaitForSeconds(destroyTime);
		//Destroy
		Destroy(gameObject);
    }
}
