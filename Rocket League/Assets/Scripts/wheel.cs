using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wheel : MonoBehaviour {

	public float rotationMag = 3.0f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKey(KeyCode.UpArrow)) {
			transform.Rotate(Vector3.right);
		}
		if(Input.GetKey(KeyCode.DownArrow)) {
			transform.Rotate(Vector3.left);
		}
	}
}
