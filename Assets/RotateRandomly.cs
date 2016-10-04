using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RotateRandomly : MonoBehaviour {
	
	//the random rotation
	private Vector3 direction;
	float x = 0;
	float y = 0;
	float z = 0;
	// Use this for initialization
	void Start () {
		direction = new Vector3 (Random.Range (0f, 5f), Random.Range (0f, 5f), Random.Range (0f, 5f));
	}
	
	// Update is called once per frame
	void Update () {
		
		//use temp variables to lerp the rotations randomly
		//x = Mathf.LerpAngle (x, direction.x, Random.Range (0.01f, 0.2f));
		//y = Mathf.LerpAngle (y, direction.y, Random.Range (0.01f, 0.2f));
		//z = Mathf.LerpAngle (z, direction.z, Random.Range (0.01f, 0.2f));
		//set the rotation
		//transform.localEulerAngles = new Vector3 (x,y,z);
		transform.Rotate (direction);
	}
}
