using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {
	
	public float jumpSpeed = 50.0f;
	public float timeBetweenJumps = 1.0f; 
	
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
		yield return new WaitForSeconds(timeBetweenJumps); 
		isJumping = false; 
		
//		myYPosition = ((float) Transform.position.y); 
		//myZPositon = ((float) Transform.position.z); 
		
	}

	
	void OnTriggerEnter(Collider otherCollider){
		
		if(otherCollider.gameObject.name("DoubleJump"))
		{
			enabledDoubleJump(); 	
		}
		else if(otherCollider.gameObject.name("Boost"))
		{
			enableBoost(); 
		}
		else if(otherCollider.gameObject.name("Win"))
		{
			enableWin();	
		}
		else if(otherCollider.gameObject.name("Save"))
		{
			
		}
		
	}
	
	void enableDoubleJump()
	{
		timeBetweenJumps = 0.5f; 
		yield return new WaitForSeconds(5.0f); 
		timeBetweenJumps = 1.0f; 
	}
	
	void enableBoost()
	{
		jumpSpeed = 75.0f;
		yield return new WaitForSeconds(5.0f); 
		jumpSpeed = 50.0f; 
	}
	
	void enableWin()
	{
		Time.timeScale = 0.0f; 
		/
	}
}
