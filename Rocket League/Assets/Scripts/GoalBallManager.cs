using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalBallManager : MonoBehaviour
{
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Goal")
        {
            GameObject car = GameObject.Find("CC_ME_R4");
            GameObject enemy = GameObject.Find("enemy");
            GameObject ball = GameObject.Find("Ball");
            ball.transform.position = GameObject.Find("BallPosition").transform.position;
            ball.GetComponent<Rigidbody>().velocity = Vector3.zero;
            car.transform.position = GameObject.Find("CarPosition").transform.position;
            enemy.transform.position = GameObject.Find("enemyCarPosition").transform.position;
            car.GetComponent<Rigidbody>().velocity = Vector3.zero;
            enemy.transform.position = GameObject.Find("enemyCarPosition").transform.position;
        }
    }

}