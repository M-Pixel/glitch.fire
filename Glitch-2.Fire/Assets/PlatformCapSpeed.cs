using UnityEngine;
using System.Collections;

public class PlatformCapSpeed : MonoBehaviour {

	// Use this for initialization
	void Start () {
		rigidbody.maxAngularVelocity = rigidbody.constantForce.torque.y;
		rigidbody.AddTorque(0, rigidbody.maxAngularVelocity, 0);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void FixedUpdate () {
		rigidbody.WakeUp();
	}
}
