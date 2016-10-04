using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TellLength : MonoBehaviour {
	public GameObject length;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		GetComponent<Text> ().text = length.GetComponent<MeasureStart> ().tryeLength.ToString();
	}
}
