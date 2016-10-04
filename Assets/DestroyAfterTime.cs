using UnityEngine;
using System.Collections;

public class DestroyAfterTime : MonoBehaviour {
	public float tim;
	// Use this for initialization
	void Start () {
		StartCoroutine ("KillTimer");
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	IEnumerator KillTimer(){
		//wait for some time
		yield return new WaitForSeconds (tim);
		//destroy this object
		Destroy(gameObject);
	}
}
