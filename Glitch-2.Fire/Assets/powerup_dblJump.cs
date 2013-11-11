using UnityEngine;
using System.Collections;

public class powerup_dblJump : MonoBehaviour {
	PlayerMovement player; 
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnTriggerEnter(Collider otherCollider) 
	{
		if(otherCollider.gameObject.name.Contains("Player"))
		{
			player.enableDoubleJump(); 
		}
	}
}
