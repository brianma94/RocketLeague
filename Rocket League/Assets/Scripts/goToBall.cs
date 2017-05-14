using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class goToBall : MonoBehaviour {
	public GameObject ball;
	void Start(){
		ball = GameObject.Find("Ball"); 
	}
	void Update()
	{
		Transform target = ball.transform;
		float moveSpeed = 5; 
		float speed = (float)0.3;
		float rotationSpeed = 5;
		this.transform.LookAt(target);
		this.transform.position = Vector3.Lerp( new Vector3(transform.position.x,0,transform.position.z), new Vector3(target.position.x, 0, target.position.z), Time.deltaTime );	
	}
}
