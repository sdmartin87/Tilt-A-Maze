using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour {

	public AudioSource volumeAudio;
	Vector3 spawnPoint = new Vector3 (-8f, 0.8f, 4f);
	public GameObject audioMenu;
	public GameObject player;

	void Start(){

	}

	public void DoneButton(){
		player.transform.position = spawnPoint;
		player.gameObject.GetComponent<Rigidbody> ().isKinematic = false;
		audioMenu.gameObject.SetActive (false);
	}
}

//	static bool AudioBegin = false;
//	void Awake(){
//		
//		
//
//		if (!AudioBegin) {
//			GetComponent<AudioSource>().Play ();
//			DontDestroyOnLoad (gameObject);
//			AudioBegin = true;
//		} 
//	}
//
//	void Start(){
//		if (FindObjectsOfType<AudioManager> ().Length > 1) {
//			Destroy (gameObject);
//		}
//	}
//
//	void Update () {
//		if(Application.loadedLevelName == "Upgraded")
//		{
//			GetComponent<AudioSource>().Stop();
//			AudioBegin = false;
//		}
//	}

