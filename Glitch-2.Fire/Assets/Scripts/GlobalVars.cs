using UnityEngine;
using System.Collections;

public class GlobalVars : MonoBehaviour {

	public int level;

	void Awake() {
		// Do not destroy this game object:
		DontDestroyOnLoad(this);
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
