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
	private Rect jumpsMiddlePos;

	private TimerController timerController;
	private int minutes;
	private int seconds;

	// Use this for initialization
	void Start () {
		jumpCount = 0;
		player = GameObject.Find("Player");
		fireBurner = GameObject.Find("fire_killer").GetComponent<fire_burner>();
		cameraUpdater = GameObject.Find("Main Camera").GetComponent<CameraUpdater>();

		timerController = gameObject.GetComponent<TimerController>();

		scorePos = new Rect(5, 5, 200, 30);
		jumpsPos = new Rect (
			scorePos.x,
			scorePos.y * 2 + scorePos.height,
			scorePos.width,
			scorePos.height
		);

		scoreMiddlePos = new Rect(
			Screen.width/2-200,
			Screen.height/2-50,
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
		string secondsPlace;
		if (!won) {
			minutes = Mathf.FloorToInt(timerController.playDuration / 60);
			seconds = (int)timerController.playDuration - minutes * 60;
		}

		if (seconds < 10)
			secondsPlace = "0";
		else
			secondsPlace = "";

		secondsPlace = "" + secondsPlace + seconds;

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
		Vector2 mySize = myGuiStyle.CalcSize(new GUIContent(timerstring));
		//scorePos.x = scorePos.x - mySize.x / 2;
		//scorePos.y = scorePos.y + mySize.y / 2;
		scorePos.width = mySize.x;
		scorePos.height = mySize.y;
		//HOTween.To(scorePos, 0.8F, new TweenParms().Prop("x", Screen.width/2 - mySize.x / 2).Prop("y", Screen.height/2 - mySize.y/2));
		scorePos.x = Screen.width/2 - mySize.x / 2;
		scorePos.y = Screen.height/2 - mySize.y/2;
	}

	public void addJump() {
		jumpCount ++;
	}
}
