using UnityEngine;
using System.Collections;

public class Finnish : MonoBehaviour {

	Vector3 spawn = new Vector3 (0f, 0.8f, 0f);
	public AudioSource levelWin;

	private void OnTriggerEnter(Collider other)
	{
		levelWin.Play ();
		GameObject.Find ("Player").SendMessage ("Finnish");
		GameObject.Find ("Player").transform.position = spawn;
		GameObject.Find ("Player").gameObject.GetComponent<Rigidbody> ().isKinematic = true;
	}

}
