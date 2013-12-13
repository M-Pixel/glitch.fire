using UnityEngine;
using System.Collections;

public class TimerController : MonoBehaviour {
	private float startTime;
	public float playDuration;

	// Use this for initialization
	void Start () {
		startTime = 0;
	}

	public void StartTimer() {
		startTime = Time.time;
	}

	// Update is called once per frame
	void FixedUpdate () {
		if (startTime != 0)
			playDuration = Time.time - startTime;
	}
}
