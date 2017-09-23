using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour {
	public static ButtonController BtnCon;
	void Start () 
	{
		// The first if statement effectively turns this script into a static script that can be used in non-static methods and also allowing it to be used
		// by other scripts without a reference to the object it is attached to. (Only do this if there will only be one copy of this script in the scene)
		if (BtnCon == null)
		{
			BtnCon = this;
		}

	}

	public void Play(){
		//GameController.GameCon.ButtonClick ();
		GameController.GameCon.LevelStartSound ();
		UIController.UICon.player.gameObject.GetComponent<Rigidbody> ().isKinematic = false;
		UIController.UICon.player.gameObject.transform.position = UIController.UICon.levelOneSpawnPoint;
		UIController.UICon.hideScreens ();
		UIController.UICon.loadLevel1 ();
		Timer.TimeCon.gameStart ();
	}

	public void MainMenu(){
		GameController.GameCon.ButtonClick ();
		UIController.UICon.player.gameObject.GetComponent<Rigidbody> ().isKinematic = false;
		UIController.UICon.hideScreens ();
		UIController.UICon.loadMainMenu ();
	}

	public void Profile(){
		GameController.GameCon.ButtonClick ();
		UIController.UICon.hideScreens ();
		UIController.UICon.loadProfile ();
	}

	public void Store(){
		GameController.GameCon.ButtonClick ();
		UIController.UICon.hideScreens ();
		UIController.UICon.loadStore ();
	}

	public void Options(){
		GameController.GameCon.ButtonClick ();
		UIController.UICon.hideScreens ();
		UIController.UICon.loadOptions ();
	}

	public void Music(){
		GameController.GameCon.ButtonClick ();
		UIController.UICon.hideScreens ();
		UIController.UICon.loadMusic ();
	}

	public void Rules(){
		GameController.GameCon.ButtonClick ();
		UIController.UICon.hideScreens ();
		UIController.UICon.loadRules ();
	}

	public void Credits(){
		GameController.GameCon.ButtonClick ();
		UIController.UICon.hideScreens ();
		UIController.UICon.loadCredits ();
	}

	public void FreeBalls(){
		GameController.GameCon.ButtonClick ();
		UIController.UICon.hideScreens ();
		UIController.UICon.loadFreeBalls ();
	}

	public void Backgrounds(){
		GameController.GameCon.ButtonClick ();
		UIController.UICon.hideScreens ();
		UIController.UICon.loadBackground ();
	}

	public void AudioDone(){
		GameController.GameCon.ButtonClick ();
		UIController.UICon.hideAudio ();
		UIController.UICon.player.gameObject.GetComponent<Rigidbody> ().isKinematic = false;
		UIController.UICon.player.transform.position = UIController.UICon.spawnPoint;
	}

	public void Back(){
		GameController.GameCon.ButtonClick ();
		if (UIController.UICon.optionsMenu.activeSelf || UIController.UICon.profileMenu.activeSelf || UIController.UICon.storeMenu.activeSelf) {
			UIController.UICon.hideScreens ();
			UIController.UICon.loadMainMenu ();
		} else if (UIController.UICon.calibrate.activeSelf || UIController.UICon.creditsMenu.activeSelf/* || UIController.UICon.musicMenu.activeSelf || UIController.UICon.language.activeSelf*/) {
			UIController.UICon.hideScreens ();
			UIController.UICon.loadOptions ();
		} else if (UIController.UICon.freeBallsMenu.activeSelf) {
			UIController.UICon.hideScreens ();
			UIController.UICon.loadStore ();
		}
	}

	public void Calibrate(){
		GameController.GameCon.ButtonClick ();
		UIController.UICon.hideScreens ();
		UIController.UICon.loadCalibrate ();
	}
		
}
