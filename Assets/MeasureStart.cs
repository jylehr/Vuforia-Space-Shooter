using UnityEngine;
using System.Collections;

public class MeasureStart : MonoBehaviour {
	public float length;
	public float tryeLength;
	public float factor;
	public GameObject end;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		length = Mathf.Sqrt( (Mathf.Pow(transform.position.x-end.transform.position.x,2f)+Mathf.Pow(transform.position.y-end.transform.position.y,2f)+Mathf.Pow(transform.position.z-end.transform.position.z,2f)));
		length = length - 0.5f - (2.3712f / 2f);
		tryeLength = factor * length;
	}
}
