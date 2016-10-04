using UnityEngine;
using System.Collections;

public class FollowLerply : MonoBehaviour {
	public float speedSorta;
	public float rotSpeed;
	public GameObject invisibleShip;
	float x;
	float y;
	float z;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		

		x = Mathf.Lerp (transform.position.x, invisibleShip.transform.position.x, speedSorta);
		y = Mathf.Lerp (transform.position.y, invisibleShip.transform.position.y, speedSorta);
		z = Mathf.Lerp (transform.position.z, invisibleShip.transform.position.z, speedSorta);

		transform.position = new Vector3 (x, y, z);
		transform.rotation = Quaternion.Lerp (transform.rotation, 
			new Quaternion (invisibleShip.transform.rotation.x,invisibleShip.transform.rotation.y,invisibleShip.transform.rotation.z,invisibleShip.transform.rotation.w), rotSpeed);
	}
}
