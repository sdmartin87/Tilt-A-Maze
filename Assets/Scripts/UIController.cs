using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour {
	public static UIController UICon;

	public GameObject player;
	public GameObject mainMenu;
	public GameObject optionsMenu;
	public GameObject level1;
	public GameObject endMenu;
	public GameObject profileMenu;
	public GameObject storeMenu;
	public GameObject musicMenu;
	public GameObject rulesMenu;
	public GameObject creditsMenu;
	public GameObject freeBallsMenu;
	public GameObject backgroundMenu;
	public GameObject calibrate;
	public GameObject language;

	public Vector3 spawnPoint = new Vector3 (-8f, 11.5f, 4f);
	[HideInInspector]
	public Vector3 audioSpawnPoint = new Vector3 (0f, 11.5f, 0f);

	public Vector3 levelOneSpawnPoint = new Vector3 (-8f, 11.5f, -4.3f);

	void Start () 
	{
		// The first if statement effectively turns this script into a static script that can be used in non-static methods and also allowing it to be used
		// by other scripts without a reference to the object it is attached to. (Only do this if there will only be one copy of this script in the scene)
		if (UICon == null)
		{
			UICon = this;
		}
	}

	public void loadMainMenu(){
		mainMenu.SetActive(true);
	}

	public void loadProfile(){
		profileMenu.SetActive(true);
	}

	public void loadStore(){
		storeMenu.SetActive(true);
	}

	public void loadOptions(){
		optionsMenu.SetActive(true);
	}

	public void loadLevel1(){
		level1.SetActive(true);
	}

	public void loadEndMenu(){
		endMenu.SetActive(true);
	}

	public void loadBackground(){
		backgroundMenu.SetActive(true);
	}

	public void loadMusic(){
		musicMenu.SetActive(true);
	}

	public void loadRules(){
		rulesMenu.SetActive(true);
	}

	public void loadCredits(){
		creditsMenu.SetActive(true);
	}

	public void loadFreeBalls(){
		freeBallsMenu.SetActive(true);
	}

	public void hideAudio(){
		musicMenu.SetActive (false);
	}

	public void loadCalibrate(){
		calibrate.SetActive (true);
	}

	public void loadLanguage(){
		language.SetActive(true);
	}

	public void hideScreens(){
//		player.transform.position = spawnPoint;
		mainMenu.SetActive(false);
		optionsMenu.SetActive(false);
		level1.SetActive(false);
//		endMenu.SetActive (false);
		profileMenu.SetActive (false);
		storeMenu.SetActive (false);
//		backgroundMenu.SetActive (false);
//		musicMenu.SetActive (false);
//		language.SetActive(false);
//		rulesMenu.SetActive (false);
		creditsMenu.SetActive (false);
		freeBallsMenu.SetActive (false);
		calibrate.SetActive (false);
	}
}
