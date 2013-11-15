using UnityEngine;
using System.Collections;

public class fire_burner : MonoBehaviour {
	public float moveSpeed; 
	public GameObject gameOver; 
	// Use this for initialization
	void Start () {
		moveSpeed = 0.005f; 
	
	}
	
	// Update is called once per frame
	void Update () {
		gameObject.transform.Translate(Vector3.up*moveSpeed); 
		moveSpeed += 0.000002f;
	}

	void OnTriggerEnter(Collider otherCollider)
	{

		if(otherCollider.gameObject.name.Contains("PlayerModel")){
			Application.LoadLevel("gameOverWorld"); 
			}
			
	}
}
q