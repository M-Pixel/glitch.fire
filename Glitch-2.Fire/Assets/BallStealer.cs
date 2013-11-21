using UnityEngine;
using System.Collections;

public class BallStealer : MonoBehaviour {
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnTriggerEnter (Collider otherCollider) {
		if (otherCollider.gameObject.name.Contains ("PlayerModel")) {
			Debug.Log("colliding with player");
			otherCollider.transform.parent.parent = transform;
			otherCollider.transform.parent.GetComponent<PlayerMovement>().ResetZeroes();
		}
	}
}