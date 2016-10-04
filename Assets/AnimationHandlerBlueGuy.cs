using UnityEngine;
using System.Collections;

public class AnimationHandlerBlueGuy : MonoBehaviour {
	//make refernces for the special parts of the gameobject
	private Rigidbody rb;
	private Animator anim;
	//a public facing float value to tell the script how much movement is required for animation
	public float sensitivity;
	//another float to tell when youve reached fast foreword speed
	public float fastSpeed;
	//yet another float to tell the object how much to tilt
	public float tilt;



	//debugging variables
	public float xx;
	public float yy;
	public float zz;
	// Use this for initialization
	void Start () {
	//get those refernces from earlier
		rb = GetComponent<Rigidbody>();
		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		xx = rb.velocity.x;
		yy = rb.velocity.y;
		zz = rb.velocity.z;

		//set all bools to false to make sure that our object is still moving
		anim.SetBool ("Right", false);
		anim.SetBool ("Left", false);
		anim.SetBool ("Forward", false);
		anim.SetBool ("Back",  false);
		anim.SetBool ("FastForward", false);


		//check your velocity in assorted direction and then set the animator bools
		if (transform.InverseTransformDirection(rb.velocity).x >= sensitivity) {
			anim.SetBool ("Right", true);
		}

		if (transform.InverseTransformDirection(rb.velocity).x <= -sensitivity) {
			anim.SetBool ("Left", true);
		}

		if (transform.InverseTransformDirection(rb.velocity).z >= sensitivity) {
			anim.SetBool ("Forward", true);
		}

		if (transform.InverseTransformDirection(rb.velocity).z <= -sensitivity) {
			anim.SetBool ("Back", true);
		}

		if (transform.InverseTransformDirection(rb.velocity).z >= fastSpeed) {
			anim.SetBool ("FastForward", true);
		}

		//if your object is moving forward or back and sideways, then we want to make it use the forward.backward animation and tilt the dirction its going.

		if (anim.GetBool ("Forward") || anim.GetBool ("Back")) {
			if (anim.GetBool ("Left")) {
				//create a vector3
				Vector3 euler = transform.localEulerAngles;
				//set the z value to be the tilt amount multiplied by your speed
				euler.z = Mathf.LerpAngle (euler.z, tilt, 2.0f * Time.deltaTime);
				//rotate it!
				transform.localEulerAngles = euler;
			} else if (anim.GetBool ("Right")) {
				//create a vector3
				Vector3 euler = transform.localEulerAngles;
				//set the z value to be the tilt amount multiplied by your speed
				euler.z = Mathf.LerpAngle (euler.z, -tilt, 2.0f * Time.deltaTime);
				//rotate it!
				transform.localEulerAngles = euler;
			} 
			//rotate it back to zero
			if (!anim.GetBool ("Left") && !anim.GetBool ("Right")) {
				Vector3 euler = transform.localEulerAngles;
				euler.z = Mathf.LerpAngle (euler.z, 0f, 2.0f * Time.deltaTime);
				//rotate it!
				transform.localEulerAngles = euler;
			}
		}
		//rotate it back to zero
		if (!anim.GetBool ("Back") && !anim.GetBool ("Forward")) {
			Vector3 euler = transform.localEulerAngles;
			euler.z = Mathf.LerpAngle (euler.z, 0f, 2.0f * Time.deltaTime);
			//rotate it!
			transform.localEulerAngles = euler;
		}

	}
}
