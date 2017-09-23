using UnityEngine;
using System.Collections;

public class Respawn : MonoBehaviour {

	Vector3 spawnPoint = new Vector3 (-8f, 0.8f, 4f);
	private GameObject player;

	void Start()
	{
		player = GameObject.FindGameObjectWithTag ("Player");
	}
	void OnTriggerEnter (Collider other)
	{
		player.transform.position = spawnPoint;
	}
}
