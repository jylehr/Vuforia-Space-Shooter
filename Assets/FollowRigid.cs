using UnityEngine;
using System.Collections;

public class FollowRigid : MonoBehaviour {

	//the object you want this attached object to follow
	public GameObject target;
	//the speed at which you want to follow them
	public float speed;
	//the distance in unity units of how close to your target you are "OK" with
	public float marginOfError;
	//Your object needs to have a rigidbody attached
	private Rigidbody rb;
	//private vriables to represnt the position offset from your target
	 Vector3 direction;
	 float x;
	 float y;
	 float z;

	// Use this for initialization
	void Start () {
		//find the rigidbody for easy and effiecient refernce later
		rb = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {
		//set the difference in the x direction
		x = target.transform.position.x - transform.position.x;
		//set the difference in the y direction
		y = target.transform.position.y - transform.position.y;
		//set the difference in the z direction
		z = target.transform.position.z - transform.position.z;

		//make sure it is worth moving in each direction individually
		if (x <= marginOfError && x >= -marginOfError) {
			x = 0;
		}
		if (y <= marginOfError && y >= -marginOfError) {
			y = 0;
		}
		if (z <= marginOfError && z >= -marginOfError) {
			z = 0;
		}

		//build the direction vector
		direction = new Vector3 (x*speed,y*speed,z*speed);

		//set the velocity through the rigidbody
		rb.velocity = direction;

		Vector3 euler = transform.localEulerAngles;
		Vector3 euler2 = target.transform.localEulerAngles;
		euler.y = Mathf.LerpAngle (euler.y, euler2.y, 5.0f * Time.deltaTime);
		//rotate it!
		transform.localEulerAngles = euler;
	}
}
