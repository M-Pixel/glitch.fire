using UnityEngine;
using System.Collections;

public class PlatformType02 : MonoBehaviour {
	
	public float goSpeed = 40.0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
		transform.Rotate (Vector3.up * Time.deltaTime*goSpeed);
	
	}
}


//Platform Types: Even numbers go clockwise, odd numbers go counter clockwise.