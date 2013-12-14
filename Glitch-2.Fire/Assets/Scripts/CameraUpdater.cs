using UnityEngine;
using System.Collections;

using Holoville.HOTween;
using Holoville.HOTween.Plugins;

public class CameraUpdater : MonoBehaviour {
	
	//public PlayerMovement playerMover;
	public float spinSpeed;
	private bool spin;
	private GameObject playerModel;
	
	// Use this for initialization
	void Start () {
		spin = false;
		playerModel = GameObject.Find("PlayerModel");
	}
	
	// Update is called once per frame
	void FixedUpdate () {
	//	transform.Translate(0.0f, playerMover.myYPosition, playerMover.myZPosition-5.0f);
		if (spin) {
			Debug.Log("I am spinning");
			transform.RotateAround(playerModel.transform.position, Vector3.up, spinSpeed);
		}
	}


	public void SpinToWin() {
		spin = true;
		Debug.Log ("I got spun");
	}
}
