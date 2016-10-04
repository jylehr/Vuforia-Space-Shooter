using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class OnAwakeAddVelocity : MonoBehaviour {
	//the speed at which they will fly
	public float minSpeed;
	public float maxSpeed;

	//the direction vector
	public Vector3 direction;

	//the rigidbody refernce
	Rigidbody rb;
	// Use this for initialization
	void Start () {
		//get the reference
		rb = GetComponent<Rigidbody> ();
		//the speed that the object will fly at
		float speed;
		//randomize the speed
		speed = Random.Range (minSpeed, maxSpeed);

		//add the force
		rb.AddForce(new Vector3 (direction.x *speed,direction.y *speed,direction.z *speed),ForceMode.Impulse);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
