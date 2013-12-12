using UnityEngine;
using System.Collections;

public class gameOverManager : MonoBehaviour {
	public string level; 
	// Use this for initialization
	void Start () {
		StartCoroutine(returnToStart()); 
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown("space"))
		{
			Application.LoadLevel(level);
		}
	}

	IEnumerator returnToStart()
	{
		yield return new WaitForSeconds(5.0f);
		Application.LoadLevel("titleScreen"); 
	}

}
