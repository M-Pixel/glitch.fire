using UnityEngine;
using System.Collections;

public class teleportToNewLevel : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider otherCollider)
	{
		StartCoroutine(teleportPlayer()); 
	}

	IEnumerator teleportPlayer()
	{
		yield return new WaitForSeconds(3.0f); 
		Application.LoadLevel(levelTwo); 
	}
}
