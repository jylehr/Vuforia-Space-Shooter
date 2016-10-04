using UnityEngine;
using System.Collections;

public class AsteroidSpawnSize : MonoBehaviour {
	//reference to the other asteroid script and the camera and the player
	 SpawnRandomAsteroids spawn;
	GameObject cam;
	Camera cama;
	 GameObject rob;
	//the public distance away from the player you want the asteroid to spawn
	public float zDist;
	//the public distance above and below the player asteroids can spawn
	public float yDist;
	//a variable to get the length of the screen as far as the player is
	private float xLength;
	// Use this for initialization
	void Start () {
		spawn = GetComponent<SpawnRandomAsteroids> ();
		cam = GameObject.FindGameObjectWithTag ("MainCamera");
		rob = GameObject.FindGameObjectWithTag ("Player");
		cama = cam.GetComponent<Camera> ();
	}
	
	// Update is called once per frame
	void Update () {
	
		//set the z distance of the asteroid spawner to be aas far away as the player plus some
		spawn.minZ = rob.transform.position.z +zDist;

		//set the y variable to be the proper numbers
		//spawn.minY = rob.transform.position.y - yDist;
		spawn.minY = rob.transform.position.y;
		spawn.maxY = rob.transform.position.y + yDist;

		//set the x values
		xLength = Mathf.Tan ((Mathf.PI/180f)*(cama.fieldOfView/2f)) * 
			Mathf.Sqrt( (Mathf.Pow(cam.transform.position.z- rob.transform.position.z,2f) + Mathf.Pow(cam.transform.position.y- rob.transform.position.y,2f)));
		spawn.minX = cam.transform.position.x - xLength - 1f;
		spawn.maxX = cam.transform.position.x + xLength + 1f;
	}
}
