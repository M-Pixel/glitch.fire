using UnityEngine;
using System.Collections;
using System.Collections.Generic;

using Holoville.HOTween;
using Holoville.HOTween.Plugins;

public class GameController : MonoBehaviour {

	private int jumpCount;
	private bool won = false;
	private GameObject player;
	private fire_burner fireBurner;
	private CameraUpdater cameraUpdater;
	public GUIStyle myGuiStyle;
	public int level;
	private string timerstring;

	private Rect scorePos;
	private Rect jumpsPos;
	private Rect scoreMiddlePos;

	private TimerController timerController;
	private int minutes;
	private int seconds;

	private float nativeWidth = 1920;
	private float nativeHeight = 1080;

	// Use this for initialization
	void Start () {
		jumpCount = 0;
		player = GameObject.Find("Player");
		fireBurner = GameObject.Find("fire_killer").GetComponent<fire_burner>();
		cameraUpdater = GameObject.Find("Main Camera").GetComponent<CameraUpdater>();

		timerController = gameObject.GetComponent<TimerController>();

		scorePos = new Rect(5, 5, 200, 30);

		scoreMiddlePos = new Rect(
			nativeWidth/2-200,
			nativeHeight/2-50,
			400,
			100
		);
		
		GameObject.Find ("GlobalVars").GetComponent<GlobalVars> ().level = level;
	}
	
	// Update is called once per frame
	void Update () {
		//if(Input.GetKey(KeyCode.G)) winGame();
	}

	void OnGUI() {
		string secondsPlace;

		// Set up Scaling (code from SilverTabby on Unity Answers)
		float rx = Screen.width / nativeWidth;
		float ry = Screen.height / nativeHeight;
		GUI.matrix = Matrix4x4.TRS (new Vector3(0, 0, 0), Quaternion.identity, new Vector3 (rx, ry, 1));

		// Advance timer
		if (!won) {
			minutes = Mathf.FloorToInt(timerController.playDuration / 60);
			seconds = (int)timerController.playDuration - minutes * 60;
		}

		// Make sure single digit seconds are preceded with a zero
		if (seconds < 10)
			secondsPlace = "0";
		else
			secondsPlace = "";

		secondsPlace = "" + secondsPlace + seconds;
		//The player shouldn't be able to survive past a few minutes so we're not doing the same for mins

		timerstring = "Time: " + minutes + ":" + secondsPlace + "\nJumps: " + jumpCount;
		GUI.Label(scorePos, timerstring, myGuiStyle);
	}

	public void winGame() {
		Debug.Log("I am win");
		fireBurner.Freeze();
		player.GetComponent<PlayerMovement>().Freeze();
		player.rigidbody.useGravity = false;
		player.rigidbody.velocity = new Vector3();
		cameraUpdater.SpinToWin();
		AnimateScore();
		won = true;
	}

	public void AnimateScore() {
		myGuiStyle.alignment = TextAnchor.MiddleCenter;
		scorePos = scoreMiddlePos;
	}

	public void addJump() {
		jumpCount ++;
	}
}
