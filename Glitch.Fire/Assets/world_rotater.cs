using UnityEngine;
using System.Collections;

public class world_rotater : MonoBehaviour {
	float goSpeed; 
	
	bool isJumping = false;
	public float jumpSpeed = 50.0f; 
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	if(Input.GetKey("d"))
		{
			Debug.Log ("Going left");
			goSpeed = 50.0f; 
			transform.Rotate(Vector3.left * Time.deltaTime * goSpeed); 
		}
		if (Input.GetKey ("a")){
			Debug.Log("Going right"); 
			goSpeed = 50.0f; 
			transform.Rotate(Vector3.right * Time.deltaTime * goSpeed); 
		}
		
	}
}
	