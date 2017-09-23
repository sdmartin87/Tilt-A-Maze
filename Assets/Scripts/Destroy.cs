using UnityEngine;
using System.Collections;

public class Destroy : MonoBehaviour {

	public Rigidbody rb;
	void Start()
	{
		
	}

	void OnTriggerStay (Collider other)
	{
		other.GetComponent<Rigidbody> ().AddForce (new Vector3 (0, -2000, 0));
		//rb.drag = 5;
		//GameObject.Find("Player").GetComponent<mobileAccelerometerInput>().speed -= 1000f;
	}
}
