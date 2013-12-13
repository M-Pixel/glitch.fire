using UnityEngine;
using System.Collections;

public class fire_burner : MonoBehaviour {
	public float moveSpeed; 
	public GameObject gameOver; 
	public bool permissionToMove = false; 
	public AudioClip clip; 
	//public AudioSource source; 

	// Use this for initialization
	public void Start () {
		//StartCoroutine(Wait());
		moveSpeed = 0.005f;
	}

	// Update is called once per frame
	public void FixedUpdate () {
		if(permissionToMove) 
		{
			gameObject.transform.Translate(Vector3.up*moveSpeed); 
			moveSpeed += 0.000008f;
		}
	}

	public void OnTriggerEnter(Collider otherCollider)
	{

		if(otherCollider.gameObject.name.Contains("PlayerModel")||otherCollider.gameObject.name.Contains("Player")){
			StartCoroutine(Die());
		}
			
	}

	public void Freeze() {
		permissionToMove = false;
	}
	public void UnFreeze() {
		permissionToMove = true;
	}

	IEnumerator Die(){
				AudioSource.PlayClipAtPoint(clip, Camera.main.transform.position); 
		yield return new WaitForSeconds(0.4f); 
				Application.LoadLevel("gameOverWorld"); 
			}

}
