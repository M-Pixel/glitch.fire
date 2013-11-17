using UnityEngine;
using System.Collections;

public class gameOverManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
		StartCoroutine(returnToStart()); 
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	IEnumerator returnToStart()
	{
		yield return new WaitForSeconds(10.0f);
		Application.LoadLevel("titleScreen"); 
	}
}
