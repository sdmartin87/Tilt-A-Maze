using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour 
{
	public static GameController GameCon;

	// Using same speed reference in both, desktop and other devices
	private float speed =10000;
	private float speedCheck;
	private Rigidbody rigidBody;
	private AudioSource ballSoundSource;
	public AudioSource ballWallHit;
	private float pitch;
	private float volume;
	private float k = 0.3f;
	private float c = 0.5f;
	public AudioSource click;
	public AudioSource levelStart;
	public float travelSpeed;
	private Vector3 startPosition;
	private Vector3 startPositionBallPic;
	private Vector3 originalScale;
	private Vector3 originalScaleBallPic;
	private bool onlyOnce;
	public GameObject ballPic;
	public string menuChoice;

	public int remainingBalls = 5;

	void Main ()
	{
		// Preventing mobile devices going in to sleep mode 
		//(actual problem if only accelerometer input is used)
		Screen.sleepTimeout = SleepTimeout.NeverSleep;
	}

	void Start()
	{
//		Screen.SetResolution(640, 480, true);
//		Camera.main.orthographicSize = (20.0f / Screen.width * Screen.height / 2.0f);
		if (GameCon == null)
		{
			GameCon = this;
		}
		startPosition = gameObject.transform.position;
		startPositionBallPic = ballPic.transform.position;
		originalScale = gameObject.transform.localScale;
		originalScaleBallPic = ballPic.transform.localScale;
		rigidBody = GetComponent<Rigidbody>();
		ballSoundSource = GetComponent<AudioSource>();
		Screen.orientation = ScreenOrientation.LandscapeLeft;
	}

	void Update()
	{
		ballPic.transform.position = gameObject.transform.position;
		pitch = speedCheck * k;
		volume = speedCheck * c;
		ballSoundSource.pitch = pitch;
		ballSoundSource.volume = volume;

		if (gameObject.transform.position.y < 8) {
			gameObject.transform.position = startPosition;
		}
	
		if (SystemInfo.deviceType == DeviceType.Desktop) 
		{
			// Exit condition for Desktop devices
			if (Input.GetKey("escape"))
				Application.Quit();
		}
		else
		{
			// Exit condition for mobile devices
			if (Input.GetKeyDown(KeyCode.Escape))
				Application.Quit();            
		}
	}

	void FixedUpdate ()
	{
		speedCheck = rigidBody.velocity.magnitude;

		if (SystemInfo.deviceType == DeviceType.Desktop) 
		{ 
			// Player movement in desktop devices
			// Definition of force vector X and Y components
			float moveHorizontal = Input.GetAxis("Horizontal");
			float moveVertical = Input.GetAxis("Vertical");
			// Building of force vector
			Vector3 movement = new Vector3 (moveHorizontal,0.0f,moveVertical);
			// Adding force to rigidbody
			GetComponent<Rigidbody>().AddForce(movement * speed * Time.deltaTime);
		}
		else
		{
			// Player movement in mobile devices
			// Building of force vector 
			Vector3 movement = new Vector3 (Input.acceleration.x, 0.0f, Input.acceleration.y);
			// Adding force to rigidbody
			GetComponent<Rigidbody>().AddForce(movement * speed * Time.deltaTime);
		}
	}

	void OnCollisionStay(Collision collision) {
		if (ballSoundSource.isPlaying == false && speedCheck >= 0.1f && collision.gameObject.tag == "Ground")
		{
			ballSoundSource.Play();
		}
		else if (ballSoundSource.isPlaying == true && speedCheck < 0.1f && collision.gameObject.tag == "Ground")
		{
			ballSoundSource.Pause();
		}
	}

	void OnCollisionEnter(Collision collision) {
		if (ballWallHit.isPlaying == false && collision.gameObject.tag == "Wall") 
		{
			ballWallHit.Play ();
		}
			else if (ballWallHit.isPlaying == true && collision.gameObject.tag == "Wall") 
		{
			ballWallHit.Pause ();
		}

	}

	void OnCollisionExit(Collision collision) {
		if (ballSoundSource.isPlaying == true && collision.gameObject.tag == "Ground")
		{
			ballSoundSource.Pause();
		}
	}

	void OnTriggerStay (Collider other)
	{
		if (other.gameObject.tag == "Hole") {
			gameObject.transform.position = Vector3.Lerp(transform.position, other.gameObject.transform.position, travelSpeed);
			rigidBody.isKinematic = true;
			StartCoroutine(ScaleOverTime(0.8f));
		}
	}

	IEnumerator ScaleOverTime(float time)
	{
		
		Vector3 destinationScale = new Vector3(0.0f, 0.0f, 0.0f);

		float currentTime = 0.0f;

		do
		{
			gameObject.transform.localScale = Vector3.Lerp(originalScale, destinationScale, currentTime / time);
			ballPic.transform.localScale = Vector3.Lerp(originalScaleBallPic, destinationScale, currentTime / time);
			currentTime += Time.deltaTime;
			yield return null;
		} while (currentTime <= time);
			
//		gameObject.transform.position = startPosition;
//		ballPic.transform.position = startPositionBallPic;
		gameObject.transform.localScale = originalScale;
		ballPic.transform.localScale = originalScaleBallPic;
		rigidBody.isKinematic = false;

		if (menuChoice == "LevelOne") {
			ButtonController.BtnCon.Play ();
		} else if (menuChoice == "Options") {
			ButtonController.BtnCon.Options ();
		} else if (menuChoice == "Store") {
			ButtonController.BtnCon.Store ();
		} else if (menuChoice == "Profile") {
			ButtonController.BtnCon.Profile ();
		} else if (menuChoice == "LevelOneHole") {
			ballPic.transform.position = UIController.UICon.levelOneSpawnPoint;
			gameObject.transform.position = UIController.UICon.levelOneSpawnPoint;
		}
		StopAllCoroutines ();
	}
		

	public void goToLoveApps(){
		Application.OpenURL("https://play.google.com/store/apps/developer?id=Love%20Apps%20LLC&hl=en");
	}

	public void ButtonClick(){
		click.Play ();
	}

	public void LevelStartSound(){
		levelStart.Play ();
	}
}