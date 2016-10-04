using UnityEngine;
using System.Collections;

public class DontMove : MonoBehaviour {
	public bool isChild;
	public GameObject ship;
	public bool switchedOn = true;
	MeshRenderer mr;
	Vector3 position;


	void Start () {
		mr = gameObject.GetComponent<MeshRenderer> ();
		float x;
		float y;
		float z;
		x = transform.position.x - ship.transform.position.x;
		y = transform.position.y - ship.transform.position.y;
		z = transform.position.z - ship.transform.position.z;

		position = new Vector3 (x, y, z);
	}
	
	// Update is called once per frame
	void Update () {
		isChild = !ship.GetComponentInChildren<MeshRenderer> ().enabled;

		if (isChild && switchedOn) {
			
			switchedOn = false;
			mr.enabled = false;

			//transform.parent = ship.transform;
		}

		if (!isChild && !switchedOn) {

			switchedOn = true;

			mr.enabled = true;

			transform.position = new Vector3 (ship.transform.position.x + position.x, ship.transform.position.y + position.y, ship.transform.position.z + position.z);
			//transform.parent = null;
		}
	}
}
