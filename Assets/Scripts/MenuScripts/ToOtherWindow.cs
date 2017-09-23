using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToOtherWindow : MonoBehaviour {

	private string tag;

	void Start()
	{
		tag = gameObject.tag;
	}

	void OnTriggerEnter(Collider other) {
		GameController.GameCon.menuChoice = tag;
	}
}
