using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {
	
	public float jumpSpeed = 165.0f;
	public float timeBetweenJumps = 0.25f;
	public float goSpeed = 70.0f;
	
	private float zeroX = 0.0f;
	private float zeroZ = 0.0f;
	private bool frozen = false;
	
	/*
	public float myYPosition; 
	public float myZPositon; 
	*/
	private bool canJump = true; 
	private bool canDoubleJump = true;
	// Use this for initialization
	void Start () {
		//Time.timeScale = 0.2f;
	}
	
	// Update is called once per frame
	void Update () {
		// Ensure player pivot doesn't move from center of platform
		transform.localPosition = new Vector3(zeroX, transform.localPosition.y, zeroZ);
		if (!frozen) {
			// Jump
			if ((Input.GetAxisRaw("Vertical") == 1 || Input.GetAxisRaw("Jump") == 1) && (canJump || canDoubleJump)) 
			{
				StartCoroutine(Jump ());
				print("Jump!");
			}
			
			// Move
			if(Input.GetAxisRaw("Horizontal") != 0)
			{
				transform.Rotate(Vector3.up * Time.deltaTime * goSpeed * Input.GetAxisRaw("Horizontal") * -1);
			}
		}
	}
	
	public void ResetZeroes() {
		zeroX = this.transform.localPosition.x;
		zeroZ = this.transform.localPosition.z;
	}
	
	IEnumerator Jump(){
		bool isDoubleJumping = false;

		// This check is redundant, but ensures these rules are enforced if the method is used elsewhere
		if (canJump || canDoubleJump) {
			if (canJump == false) isDoubleJumping = true;
			Debug.Log("set double jump to true");
			canJump = false;
			canDoubleJump = false;
			rigidbody.AddForce(Vector3.up *jumpSpeed);
			yield return new WaitForSeconds(timeBetweenJumps);
			if (!isDoubleJumping) {
				canDoubleJump = true;
				Debug.Log("Can double jump!");
			}
			//		myYPosition = ((float) Transform.position.y); 
			//myZPositon = ((float) Transform.position.z); 
		}
	}
	
	
	void OnCollisionEnter(Collision otherCollider){
		// The following relative velocity check ensures that this is triggered only from landing on a platform, not from hitting underneath.
		Debug.Log(otherCollider.relativeVelocity.y);
		if (otherCollider.gameObject.name.Contains("Platform") && otherCollider.relativeVelocity.y >= 0|| otherCollider.gameObject.name.Contains("polyS") && otherCollider.relativeVelocity.y >= 0)
		{
			Debug.Log("Hit teh ground");
		    canJump = true;
			canDoubleJump = true;
		}
	}

	public void Freeze() {
		frozen = true;
	}
	public void UnFreeze() {
		frozen = false;
	}
}

	
/*	void OnTriggerEnter(Collider otherCollider){
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
	
*/
