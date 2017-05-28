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
	public Text min;
	public Text sec;
	// Use this for initialization
	void Start () {
		//textTeam1 = GameObject.Find ("Team1").GetComponent<Text>();
		//textTeam2 = GameObject.Find ("Team2").GetComponent<Text>();
		scoreTeam1 = scoreTeam2 = 0;
	}

    public void OnTriggerEnter(Collider other)
    {
		GameObject car = GameObject.Find ("Player");
		GameObject enemy = GameObject.Find ("Player1");
		GameObject enemy2 = GameObject.Find ("Player2");
		GameObject ball = GameObject.Find ("Ball");
		if (other.gameObject.tag == "Goal_R") {
			ball.transform.position = GameObject.Find ("BallPosition").transform.position;
			ball.GetComponent<Rigidbody> ().velocity = Vector3.zero;
			++scoreTeam2;
			textTeam1.text = scoreTeam1.ToString();
		} else if (other.gameObject.tag == "Goal_L") {
			ball.transform.position = GameObject.Find ("BallPosition").transform.position;
			ball.GetComponent<Rigidbody> ().velocity = Vector3.zero;
			++scoreTeam1;
			textTeam2.text = scoreTeam2.ToString();
		}
    }

	void FixedUpdate(){
		sec.text = (System.Convert.ToSingle (sec.text) - Time.deltaTime).ToString ();
		if (System.Convert.ToSingle(sec.text) < 0.0f) {
			if(System.Convert.ToSingle(min.text) > 0.0f){
				sec.text = "59";
				min.text = (System.Convert.ToSingle (min.text) - 1).ToString ();
			}
		}
		if (System.Convert.ToSingle(min.text) <= 0.0f && System.Convert.ToSingle(sec.text) <= 0.0f) {
			Application.LoadLevel(0);
		}
	}
		

}