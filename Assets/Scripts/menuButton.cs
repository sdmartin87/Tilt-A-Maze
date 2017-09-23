using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class menuButton : MonoBehaviour {

	public Image menu;
	public Button resume;
	public Button quit;
	public Text resumeText;
	public Text quitText;

	public void Pause()
	{
		if (Time.timeScale == 1) {
			Time.timeScale = 0;
		}
		else if(Time.timeScale == 0){
			Time.timeScale = 1;
		}
		menu.enabled = true;
		resume.enabled = true;
		quit.enabled = true;
		resumeText.enabled = true;
		quitText.enabled = true;
	}
}