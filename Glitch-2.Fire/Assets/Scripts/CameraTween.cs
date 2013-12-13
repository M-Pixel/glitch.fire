using UnityEngine;
using System.Collections;

using Holoville.HOTween;
using Holoville.HOTween.Plugins;

public class CameraTween : MonoBehaviour {
	
	private Vector3 originalPos;
	private Vector3 originalRot;
	public bool debugMode;
	private fire_burner fireBurner;
	
	// Use this for initialization
	void Start () {
		originalPos = transform.localPosition;
		originalRot = transform.localRotation.eulerAngles;
		if (!debugMode) this.IntroCamera();
		fireBurner = GameObject.Find("fire_killer").GetComponent<fire_burner>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void IntroCamera(){
		PlayerMovement player = GameObject.Find("Player").GetComponent<PlayerMovement>();
		player.Freeze();
		Sequence moveSequence = new Sequence (new SequenceParms());
		Sequence rotSequence = new Sequence (new SequenceParms());
		
		transform.localPosition = new Vector3 (0,40,0);
		transform.localRotation = Quaternion.Euler(new Vector3(90,0,0));
		
		rotSequence.AppendInterval(3.0F);
		rotSequence.Append(HOTween.To (transform, 4.0F, new TweenParms().Prop("rotation", originalRot)));
		
		moveSequence.Append(HOTween.To (transform, 5.0F, new TweenParms().Prop("localPosition", new Vector3(0, 2, 0))));
		moveSequence.Append(HOTween.To (transform, 2.0F, new TweenParms().Prop("localPosition", originalPos).OnComplete(callback)));

		rotSequence.Play();
		moveSequence.Play ();
		
	}

	void callback() {
		PlayerMovement player = GameObject.Find("Player").GetComponent<PlayerMovement>();
		player.UnFreeze();
		fireBurner.UnFreeze();
		GameObject.Find("Game").GetComponent<TimerController>().StartTimer();
	}


}
