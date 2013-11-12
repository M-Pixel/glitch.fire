using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {
	
	public float jumpSpeed = 50.0f;
	public float timeBetweenJumps = 0.5f; 
	
	/*
	public float myYPosition; 
	public float myZPositon; 
	*/
	private bool canJump = true; 
	private bool isJumping = false; 
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.rotation = Quaternion.Euler(Vector3.zero);
		if (Input.GetKeyDown("w") && isJumping == false|| Input.GetKeyDown("space") && isJumping == false) 
		{
			StartCoroutine(Jump ()); 
			print("Jump!");
		}
		
	
	}
	
	IEnumerator Jump(){
		isJumping = true; 
		rigidbody.AddForce(Vector3.up *jumpSpeed);
		yield return new WaitForSeconds(1.0f); 
		isJumping = false; 
		
//		myYPosition = ((float) Transform.position.y); 
		//myZPositon = ((float) Transform.position.z); 
		
	}

	
	void OnTriggerEnter(Collider otherCollider){
		
		jumpSpeed = 0.0f;
		
	}
}
