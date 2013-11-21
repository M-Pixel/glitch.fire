using UnityEngine;
using System.Collections;

public class creditsScroller : MonoBehaviour {

	// Use this for initialization
	void Start () {
		StartCoroutine(returnToTitle()); 
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate(Vector3.up * 0.002f); 
	}

	IEnumerator returnToTitle()
	{
		yield return new WaitForSeconds(10.0f);
		Application.LoadLevel("titleScreen"); 
	}
}
