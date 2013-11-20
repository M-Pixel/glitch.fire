using UnityEngine;
using System.Collections;

public class fire_burner : MonoBehaviour {
	public float moveSpeed; 
	public GameObject gameOver; 
	public bool permissionToMove = false; 
	// Use this for initialization
	void Start () {
		StartCoroutine(Wqait());
		moveSpeed = 0.005f; 
	
	}
	
	// Update is called once per frame
	void Update () {
		if(permissionToMove = true) 
		{
		gameObject.transform.Translate(Vector3.up*moveSpeed); 
		moveSpeed += 0.000009f;
		}
	}

	void OnTriggerEnter(Collider otherCollider)
	{

		if(otherCollider.gameObject.name.Contains("PlayerModel")){
			Application.LoadLevel("gameOverWorld"); 
			}
			
	}

	IEnumerator Wait()
	{
		yield return new WaitForSeconds(3.0f); 
		permissionToMove = true; 
		Debug.Log ("herp derp"); 
	}
}
