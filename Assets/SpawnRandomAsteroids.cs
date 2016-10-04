using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpawnRandomAsteroids : MonoBehaviour {
	//your multiple asteroid prefabs
	public GameObject[] asteroid = new GameObject[7];
	//the time inbetween each ateroid spawn, this can be changed by other scripts
	public float timeInBetween;
	//are we shooting atm?
	public bool shoot;
	//the range of the spawning asteroids
	public float minX;
	public float maxX;
	public float minY;
	public float maxY;
	public float minZ;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		//the object that will be spawned
		GameObject spawnd;
		//chooses a random object from our array
		spawnd = asteroid [Random.Range (0, asteroid.Length)];
		//the random location we will use to spawn at
		Vector3 randomPoint;
		//randomizes the location between set values
		randomPoint= new Vector3 (Random.Range(minX,maxX),Random.Range(minY,maxY),minZ);
		//checks to see if its time to shoot
		if (shoot) {
			//spawns the object at the location
			Instantiate(spawnd, randomPoint, new Quaternion (Random.Range(0,360),Random.Range(0,360),Random.Range(0,360), 1));
			//so we don't imediately shoot again
			shoot = false;
			//start the timer
			StartCoroutine("SpawnTimer");
		}
	}
	//the timer
	IEnumerator SpawnTimer(){
		//wait for some time
		yield return new WaitForSeconds (timeInBetween);
		//tell the update functions its time to shoot
		shoot = true;
	}
}
