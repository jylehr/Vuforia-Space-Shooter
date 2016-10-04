using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {
	//The amount of hits you can take max
	public float maxHealth;
	//the amount of hits you have left
	public float health;
	//are we dead?
	public bool dead;

	//how long must you wait before being hit again
	public float invTime;
	//are we hitable
	public bool hitable;
	// Use this for initialization
	void Start () {
		health = maxHealth;
	}
	
	// Update is called once per frame
	void Update () {
		//confirm whether you are dead or not
		dead = false;
		if (health <= 0f) {
			dead = true;
		}


	}

	//check if we get hit
	void OnTriggerEnter (Collider other){
		if (other.gameObject.CompareTag ("Asteroid") && hitable) {
			health -= 1f;
			hitable = false;
		}
	}

	//the timer function for how long you can't be hit
	IEnumerator HitWait (){
		yield return new WaitForSeconds (invTime);
		hitable = true;
	}
}
