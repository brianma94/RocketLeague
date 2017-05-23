using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class goToBall : MonoBehaviour {
	public GameObject ball;
    float speed;
	void Start(){
		ball = GameObject.Find("Ball");
        speed = 30.0f;
    }
    void Update()
    {
        
        Transform target = ball.transform;
        // if (target.position.y <= 1.10f)
        // {
        //print(target.position.y);
        System.Random rnd = new System.Random();
        int number = rnd.Next(1, 50);
        if (number == 1)
        {

            this.transform.LookAt(target);
            this.transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);
        }
            //this.transform.position = Vector3.MoveTowards(transform.position, new Vector3(target.position.x + 1, 0, target.position.z + 1), Time.deltaTime * speed);
		GetComponent<Rigidbody>().AddForceAtPosition(2 * transform.forward, 
			transform.position);
       // }
		if (Input.GetKey(KeyCode.Escape)) // TEST
		{
			Application.Quit();
		}
    }
}
