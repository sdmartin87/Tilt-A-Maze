using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Timer : MonoBehaviour {
	public static Timer TimeCon;

	public Text timerText;
	private float startTime;
	private bool finnished = false;
	public GameObject endMenu;

	void Start () 
	{
		// The first if statement effectively turns this script into a static script that can be used in non-static methods and also allowing it to be used
		// by other scripts without a reference to the object it is attached to. (Only do this if there will only be one copy of this script in the scene)
		if (TimeCon == null)
		{
			TimeCon = this;
		}

	}
		
	void Update () {
		
		if (finnished)
			return;

		float t = Time.time - startTime;

		string minutes = ((int)t / 60).ToString ();
		string seconds = (t % 60).ToString ("f2");

		timerText.text = minutes + ":" + seconds;
		
	}

	public void Finnish()
	{
		finnished = true;
		timerText.color = Color.yellow;
		endMenu.gameObject.SetActive (true);
	}

	public void gameStart(){
		startTime = Time.time;
		finnished = false;
	}

}
