using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoalBallManager : MonoBehaviour
{

	private int scoreTeam1;
	private int scoreTeam2;
	public Text textTeam1;
	public Text textTeam2;
	// Use this for initialization
	void Start () {
		//textTeam1 = GameObject.Find ("Team1").GetComponent<Text>();
		//textTeam2 = GameObject.Find ("Team2").GetComponent<Text>();
		scoreTeam1 = scoreTeam2 = 0;
	}

    public void OnTriggerEnter(Collider other)
    {
		Debug.Log (other.gameObject.tag, other);
		if (other.gameObject.tag == "Goal_R") {
			GameObject car = GameObject.Find ("CC_ME_R4");
			GameObject enemy = GameObject.Find ("enemy");
			GameObject ball = GameObject.Find ("Ball");
			ball.transform.position = GameObject.Find ("BallPosition").transform.position;
			ball.GetComponent<Rigidbody> ().velocity = Vector3.zero;
			car.transform.position = GameObject.Find ("CarPosition").transform.position;
			enemy.transform.position = GameObject.Find ("enemyCarPosition").transform.position;
			car.GetComponent<Rigidbody> ().velocity = Vector3.zero;
			enemy.transform.position = GameObject.Find ("enemyCarPosition").transform.position;
			++scoreTeam1;
			textTeam1.text = scoreTeam1.ToString();
		} else if (other.gameObject.tag == "Goal_L") {
			GameObject car = GameObject.Find ("CC_ME_R4");
			GameObject enemy = GameObject.Find ("enemy");
			GameObject ball = GameObject.Find ("Ball");
			ball.transform.position = GameObject.Find ("BallPosition").transform.position;
			ball.GetComponent<Rigidbody> ().velocity = Vector3.zero;
			car.transform.position = GameObject.Find ("CarPosition").transform.position;
			enemy.transform.position = GameObject.Find ("enemyCarPosition").transform.position;
			car.GetComponent<Rigidbody> ().velocity = Vector3.zero;
			enemy.transform.position = GameObject.Find ("enemyCarPosition").transform.position;
			++scoreTeam2;
			textTeam2.text = scoreTeam2.ToString();
		}
    }
		

}