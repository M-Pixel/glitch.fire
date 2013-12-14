using UnityEngine;
using System.Collections;
using System.Collections.Generic;

using Holoville.HOTween;
using Holoville.HOTween.Plugins;

public class GameController : MonoBehaviour {
	public Font myFont;

	private int jumpCount;
	private GameObject player;
	private fire_burner fireBurner;
	private CameraUpdater cameraUpdater;
	private GUIStyle myGuiStyle;

	private Rect scorePos;
	private Rect jumpsPos;
	private Rect scoreMiddlePos;
	private Rect jumpsMiddlePos;

	private TimerController timerController;

	// Use this for initialization
	void Start () {
		jumpCount = 0;
		player = GameObject.Find("Player");
		fireBurner = GameObject.Find("fire_killer").GetComponent<fire_burner>();
		cameraUpdater = GameObject.Find("Main Camera").GetComponent<CameraUpdater>();

		timerController = gameObject.GetComponent<TimerController>();

		myGuiStyle = new GUIStyle();
		myGuiStyle.font = myFont;
		myGuiStyle.normal.textColor = new Color(1, 0.5f, 0);
		myGuiStyle.fontSize = 38;

		scorePos = new Rect(5, 5, 200, 30);
		jumpsPos = new Rect (
			scorePos.x,
			scorePos.y * 2 + scorePos.height,
			scorePos.width,
			scorePos.height
		);

		scoreMiddlePos = new Rect(
			Screen.width/2-200,
			Screen.height/2-110,
			400,
			100
		);
		jumpsMiddlePos = new Rect(
			scoreMiddlePos.x,
			scoreMiddlePos.y + 120,
			scoreMiddlePos.width,
			scoreMiddlePos.height
		);
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKey(KeyCode.G)) winGame();
	}

	void OnGUI() {
		int minutes = Mathf.FloorToInt(timerController.playDuration / 60);
		int seconds = (int)timerController.playDuration - minutes * 60;
		string secondsPlace;

		if (seconds < 10)
			secondsPlace = "0";
		else
			secondsPlace = "";

		secondsPlace = "" + secondsPlace + seconds;

		GUI.Label(scorePos, "Time: " + minutes + ":" + secondsPlace, myGuiStyle);
		GUI.Label(jumpsPos, "Jumps: " + jumpCount, myGuiStyle);
	}

	public void winGame() {
		Debug.Log("I am win");
		fireBurner.Freeze();
		player.GetComponent<PlayerMovement>().Freeze();
		player.rigidbody.useGravity = false;
		player.rigidbody.velocity = new Vector3();
		cameraUpdater.SpinToWin();
	}

	public void AnimateScore() {
		Sequence moveSequence = new Sequence (new SequenceParms());
	}

	public void addJump() {
		jumpCount ++;
	}
}
