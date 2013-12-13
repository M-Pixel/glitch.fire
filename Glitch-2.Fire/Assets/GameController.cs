using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameController : MonoBehaviour {
	public Font myFont;

	private int jumpCount;
	private GameObject player;
	private fire_burner fireBurner;
	private CameraUpdater cameraUpdater;
	private GUIStyle myGuiStyle;

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

		GUI.Label(new Rect(5, 5, 200, 30), "Time: " + minutes + ":" + secondsPlace, myGuiStyle);
		GUI.Label(new Rect(5, 40, 200, 30), "Jumps: " + jumpCount, myGuiStyle);
	}

	public void winGame() {
		Debug.Log("I am win");
		fireBurner.Freeze();
		player.GetComponent<PlayerMovement>().Freeze();
		player.rigidbody.useGravity = false;
		cameraUpdater.SpinToWin();
	}

	public void addJump() {
		jumpCount ++;
	}
}
