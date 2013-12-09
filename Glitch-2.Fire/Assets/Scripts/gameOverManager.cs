using UnityEngine;
using System.Collections;

public class gameOverManager : MonoBehaviour
{
	// This script needs to be properly modified in order to load the previous level that the player died trying to complete. ]
	string prevLevel; 
	// Use this for initialization
	void Start () {
//		prevLevel = PlayerMovement.LevelCount;  
		StartCoroutine(returnToStart()); 
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	IEnumerator returnToStart()
	{
		yield return new WaitForSeconds(5.0f);
		Application.LoadLevel("titleScreen"); 
	}
}
