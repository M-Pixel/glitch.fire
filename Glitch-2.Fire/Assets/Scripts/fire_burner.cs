using UnityEngine;
using System.Collections;

public class fire_burner : MonoBehaviour {
	public float moveSpeed; 
	public GameObject gameOver; 
	// Use this for initialization
	void Start () {
		moveSpeed = 0.0001f; 
	
	}
	
	// Update is called once per frame
	void Update () {
		gameObject.transform.Translate(Vector3.up*moveSpeed); 
		moveSpeed += 0.000002f;
	}

	void OnTriggerEnter(Collider otherCollider)
	{
		/*
		if(otherCollider.gameObject.name.Contains("Player")){
			Instantiate(gameOver, new Vector3(Camera.main.gameObject.transform.position), new Quaternion(0,0,0,0)); 
				Time.timeScale = 0; 

			}
			*/ 
	}
}
