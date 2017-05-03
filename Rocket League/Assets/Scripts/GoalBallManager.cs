using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalBallManager : MonoBehaviour
{
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Goal")
        {
            GameObject car = GameObject.Find("car_12");
            GameObject ball = GameObject.Find("Ball");
            ball.transform.position = GameObject.Find("BallPosition").transform.position;
            ball.GetComponent<Rigidbody>().velocity = Vector3.zero;
            car.transform.position = GameObject.Find("CarPosition").transform.position;
            car.GetComponent<Rigidbody>().velocity = Vector3.zero;
        }
    }

}