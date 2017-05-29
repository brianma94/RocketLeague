using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalScript : MonoBehaviour {

	public Camera cam0;
	public Camera cam1;
	public Camera cam2;
	public Camera cam3;
	public Camera cam4;
	public Camera cam5;
	public GameObject car0;
	public GameObject car1;
	public GameObject car2;
	public GameObject car3;
	public GameObject car4;
	public GameObject car5;


	// Use this for initialization
	void Start () {
		cam0 = GameObject.Find ("Player/Camera").GetComponent<Camera>();
		cam1 = GameObject.Find ("Player1/Camera").GetComponent<Camera>();
		cam2 = GameObject.Find ("Player2/Camera").GetComponent<Camera>();
		cam3 = GameObject.Find ("Player3/Camera").GetComponent<Camera>();
		cam4 = GameObject.Find ("Player4/Camera").GetComponent<Camera>();
		cam5 = GameObject.Find ("Player5/Camera").GetComponent<Camera>();
		car0 = GameObject.Find ("Player");
		car1 = GameObject.Find ("Player1");
		car2 = GameObject.Find ("Player2");
		car3 = GameObject.Find ("Player3");
		car4 = GameObject.Find ("Player4");
		car5 = GameObject.Find ("Player5");
		int mode = PlayerPrefs.GetInt ("Mode");
		int car = PlayerPrefs.GetInt ("Car");

		if (mode == 1) {
			if (car == 0) {
				cam0.enabled = true;
				cam1.enabled = false;
				car0.GetComponent<MasterController> ().enabled = true;
				car0.GetComponent<EnemyController> ().enabled = false;
				car1.GetComponent<MasterController> ().enabled = false;
				car1.GetComponent<EnemyController> ().enabled = true;
				car2.SetActive(false);
				car3.SetActive(false);
				car4.SetActive(false);
				car5.SetActive(false);
			} else if (car == 1) {
				cam1.enabled = true;
				cam2.enabled = false;
				car1.GetComponent<MasterController> ().enabled = true;
				car1.GetComponent<EnemyController> ().enabled = false;
				car0.SetActive (false);
				car2.GetComponent<MasterController> ().enabled = false;
				car2.GetComponent<EnemyController> ().enabled = true;
				car3.SetActive(false);
				car4.SetActive(false);
				car5.SetActive(false);
			} else if (car == 2) {
				cam0.enabled = false;
				cam2.enabled = true;
				car2.GetComponent<MasterController> ().enabled = true;
				car2.GetComponent<EnemyController> ().enabled = false;
				car0.GetComponent<MasterController> ().enabled = false;
				car0.GetComponent<EnemyController> ().enabled = true;
				car1.SetActive (false);
				car3.SetActive(false);
				car4.SetActive(false);
				car5.SetActive(false);
			}
		} else if (mode == 2) {
			if (car == 0) {
				cam0.enabled = true;
				cam1.enabled = false;
				cam4.enabled = false;
				cam5.enabled = false;
				car0.GetComponent<MasterController> ().enabled = true;
				car0.GetComponent<EnemyController> ().enabled = false;
				car1.GetComponent<MasterController> ().enabled = false;
				car1.GetComponent<EnemyController> ().enabled = true;
				car5.GetComponent<MasterController> ().enabled = false;
				car5.GetComponent<EnemyController> ().enabled = true;
				car4.GetComponent<MasterController> ().enabled = false;
				car4.GetComponent<EnemyController> ().enabled = true;
				car2.SetActive(false);
				car3.SetActive (false);
			} else if (car == 1) {
				cam1.enabled = true;
				cam4.enabled = false;
				cam2.enabled = false;
				cam3.enabled = false;
				car1.GetComponent<MasterController> ().enabled = true;
				car1.GetComponent<EnemyController> ().enabled = false;
				car0.SetActive (false);
				car5.SetActive (false);
				car2.GetComponent<MasterController> ().enabled = false;
				car2.GetComponent<EnemyController> ().enabled = true;
				car4.GetComponent<MasterController> ().enabled = false;
				car4.GetComponent<EnemyController> ().enabled = true;
				car3.GetComponent<MasterController> ().enabled = false;
				car3.GetComponent<EnemyController> ().enabled = true;
			} else if (car == 2) {
				cam0.enabled = false;
				cam2.enabled = true;
				cam5.enabled = false;
				cam4.enabled = false;
				car2.GetComponent<MasterController> ().enabled = true;
				car2.GetComponent<EnemyController> ().enabled = false;
				car0.GetComponent<MasterController> ().enabled = false;
				car0.GetComponent<EnemyController> ().enabled = true;
				car5.GetComponent<MasterController> ().enabled = false;
				car5.GetComponent<EnemyController> ().enabled = true;
				car4.GetComponent<MasterController> ().enabled = false;
				car4.GetComponent<EnemyController> ().enabled = true;
				car1.SetActive (false);
				car3.SetActive (false);
			}
		} else if (mode == 3) {
			if (car == 0) {
				cam0.enabled = true;
				cam1.enabled = false;
				cam2.enabled = false;
				cam3.enabled = false;
				cam4.enabled = false;
				cam5.enabled = false;
				car0.GetComponent<MasterController> ().enabled = true;
				car0.GetComponent<EnemyController> ().enabled = false;
				car1.GetComponent<MasterController> ().enabled = false;
				car1.GetComponent<EnemyController> ().enabled = true;
				car5.GetComponent<MasterController> ().enabled = false;
				car5.GetComponent<EnemyController> ().enabled = true;
				car4.GetComponent<MasterController> ().enabled = false;
				car4.GetComponent<EnemyController> ().enabled = true;
				car3.GetComponent<MasterController> ().enabled = false;
				car3.GetComponent<EnemyController> ().enabled = true;
				car2.GetComponent<MasterController> ().enabled = false;
				car2.GetComponent<EnemyController> ().enabled = true;
			} else if (car == 1) {
				cam0.enabled = false;
				cam1.enabled = true;
				cam4.enabled = false;
				cam5.enabled = false;
				cam2.enabled = false;
				cam3.enabled = false;
				car1.GetComponent<MasterController> ().enabled = true;
				car1.GetComponent<EnemyController> ().enabled = false;
				car2.GetComponent<MasterController> ().enabled = false;
				car2.GetComponent<EnemyController> ().enabled = true;
				car4.GetComponent<MasterController> ().enabled = false;
				car4.GetComponent<EnemyController> ().enabled = true;
				car3.GetComponent<MasterController> ().enabled = false;
				car3.GetComponent<EnemyController> ().enabled = true;
				car0.GetComponent<MasterController> ().enabled = false;
				car0.GetComponent<EnemyController> ().enabled = true;
				car5.GetComponent<MasterController> ().enabled = false;
				car5.GetComponent<EnemyController> ().enabled = true;
			} else if (car == 2) {
				cam0.enabled = false;
				cam1.enabled = false;
				cam2.enabled = true;
				cam3.enabled = false;
				cam5.enabled = false;
				cam4.enabled = false;
				car2.GetComponent<MasterController> ().enabled = true;
				car2.GetComponent<EnemyController> ().enabled = false;
				car0.GetComponent<MasterController> ().enabled = false;
				car0.GetComponent<EnemyController> ().enabled = true;
				car5.GetComponent<MasterController> ().enabled = false;
				car5.GetComponent<EnemyController> ().enabled = true;
				car4.GetComponent<MasterController> ().enabled = false;
				car4.GetComponent<EnemyController> ().enabled = true;
				car1.GetComponent<MasterController> ().enabled = false;
				car1.GetComponent<EnemyController> ().enabled = true;
				car3.GetComponent<MasterController> ().enabled = false;
				car3.GetComponent<EnemyController> ().enabled = true;
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
