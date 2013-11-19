using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {
	
	public float jumpSpeed = 50.0f;
	public float timeBetweenJumps = 0.5f;
	public float goSpeed = 50.0f;
	
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
		// Ensure player pivot doesn't move from center of platform
		transform.localPosition = new Vector3(0.0f, transform.localPosition.y, 0.0f);
		// Jump
		if (Input.GetKeyDown("w") && isJumping == false|| Input.GetKeyDown("space") && isJumping == false|| Input.GetKeyDown("up") && isJumping == false) 
		{
			StartCoroutine(Jump ()); 
			print("Jump!");
		}
		
		// Move
		if(Input.GetKey("a")||Input.GetKey ("left"))
		{
			Debug.Log ("Going left");
			transform.Rotate(Vector3.up * Time.deltaTime * goSpeed); 
		}
		if (Input.GetKey ("d")||Input.GetKey("right")){
			Debug.Log("Going right");
			transform.Rotate(Vector3.down * Time.deltaTime * goSpeed); 
		}
		/*
		OnTriggerEnter.Collider(){
			Object.transform.parent

		}
		*/
	}
	
	IEnumerator Jump(){
		isJumping = true; 
		rigidbody.AddForce(Vector3.up *jumpSpeed);
		yield return new WaitForSeconds(1.0f); 
		isJumping = false; 
		
//		myYPosition = ((float) Transform.position.y); 
		//myZPositon = ((float) Transform.position.z); 
		
	}


	void OnColliderEnter(Collider otherCollider){
		transform.parent = otherCollider.transform;
	}
	
	void OnTriggerEnter(Collider otherCollider){
		if(otherCollider.gameObject.name.Contains("doubleJump")){
			StartCoroutine(enableDoubleJump()); 
			Destroy (otherCollider.gameObject); 
		}

		//if(otherCollider.gameObject.name.Contains("Platform")) {
		//	transform.parent = otherCollider.transform;
		//}

		if(otherCollider.gameObject.name.Contains("boost"))
		{
			StartCoroutine(boostMechanic());
		}
	}
	IEnumerator enableDoubleJump()
	{
		Debug.Log ("AW YISS"); 
		timeBetweenJumps = 0.1f; 
		yield return new WaitForSeconds(3.0f);
		timeBetweenJumps = 0.5f; 
	}
	IEnumerator boostMechanic()
	{
		jumpSpeed = 65.0f; 
		goSpeed = 65.0f; 
		yield return new WaitForSeconds(3.0f); 
		jumpSpeed = 50.0f; 
		goSpeed = 50.0f; 
	}

}
