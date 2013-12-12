using UnityEngine;
using System.Collections;

public class endingScript : MonoBehaviour {
	public GameObject playerFreeze; 
	public GameObject thing1; 
	public GameObject thing2;
	public GameObject thing3; 
	// Use this for initialization
	void Start () {
		/*
		thing1 = new GameObject(); 
		thing2 = new GameObject(); 
		thing3 = new GameObject(); 
*/
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider otherCollider)
	{
		if(otherCollider.gameObject.name.Contains("Player")){
		//	StartCoroutine(wowCutscene()); 
		}
	}

}
