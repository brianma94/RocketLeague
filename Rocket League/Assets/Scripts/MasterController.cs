using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class AxleLoadmasterCarInfo {
	public WheelCollider leftWheel;
	public GameObject leftWheelMesh;
	public WheelCollider rightWheel;
	public GameObject rightWheelMesh;
	public bool motor;				// is the wheel attached to the motor?
	public bool steering;  			// does this wheel apply steer angle?
}

public class MasterController : MonoBehaviour {

	public List<AxleLoadmasterCarInfo> axleInfos; 		// List of all wheel pairs
	public float maxMotorTorque;						// Maximum torque the motor can apply to the wheels
	public float maxSteeringAngle;						// MAximum steering angle of the wheels
	public float brake;
	/*public Camera cam0;
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
	public GameObject car5;*/


	// Use this for initialization
	void Start () {
		GetComponent<Rigidbody>().centerOfMass = new Vector3(0.0f, -1.0f, 0.0f);
		/*cam0 = GameObject.Find ("Player/Camera").GetComponent<Camera>();
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
		}*/
		/*if (car == 0) {
			cam0.enabled = true;
			cam2.enabled = false;
			cam1.enabled = false;

			car0.GetComponent<MasterController> ().enabled = true;
			car0.GetComponent<EnemyController> ().enabled = false;
			car1.GetComponent<MasterController> ().enabled = false;
			car1.GetComponent<EnemyController> ().enabled = true;
			car2.GetComponent<MasterController> ().enabled = false;
			car2.GetComponent<EnemyController> ().enabled = true;
		} else if (car == 1) {
			cam0.enabled = false;
			cam1.enabled = true;
			cam2.enabled = false;
			car1.GetComponent<MasterController> ().enabled = true;
			car1.GetComponent<EnemyController> ().enabled = false;
			car0.GetComponent<MasterController> ().enabled = false;
			car0.GetComponent<EnemyController> ().enabled = true;
			car2.GetComponent<MasterController> ().enabled = false;
			car2.GetComponent<EnemyController> ().enabled = true;
		} else if (car == 2) {
			cam0.enabled = false;
			cam1.enabled = false;
			cam2.enabled = true;
			car2.GetComponent<MasterController> ().enabled = true;
			car2.GetComponent<EnemyController> ().enabled = false;
			car0.GetComponent<MasterController> ().enabled = false;
			car0.GetComponent<EnemyController> ().enabled = true;
			car1.GetComponent<MasterController> ().enabled = false;
			car1.GetComponent<EnemyController> ().enabled = true;
		}*/
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey(KeyCode.Escape))
		{
			//Application.Quit ();
			Application.LoadLevel(0);
		}
	}

	public void ApplyLocalPositionToVisuals(AxleLoadmasterCarInfo wheelPair) {

		Transform visualWheelLeft = wheelPair.leftWheelMesh.transform;
		Transform visualWheelRight = wheelPair.rightWheelMesh.transform;

		Vector3 positionL;
		Quaternion rotationL;
		wheelPair.leftWheel.GetWorldPose (out positionL, out rotationL);
		Vector3 positionR;
		Quaternion rotationR;
		wheelPair.rightWheel.GetWorldPose (out positionR, out rotationR);
		//visualWheelLeft.transform.position = positionL;
		//visualWheelRight.transform.position = positionR;
		visualWheelLeft.transform.rotation = rotationL;
		visualWheelRight.transform.rotation = rotationR;

	}

	public void FixedUpdate() {
		float motor = maxMotorTorque * Input.GetAxis ("Vertical");
		float steering = maxSteeringAngle * Input.GetAxis ("Horizontal");


		foreach (AxleLoadmasterCarInfo axleInfo in axleInfos) {

			// Check the steering
			if (axleInfo.steering == true) {
				axleInfo.leftWheel.steerAngle = steering;
				axleInfo.rightWheel.steerAngle = steering;
			}

			// Check the motor
			if (axleInfo.motor == true) {
				if (!Input.GetKey (KeyCode.UpArrow) && !Input.GetKey (KeyCode.DownArrow)) {
					axleInfo.leftWheel.motorTorque = axleInfo.rightWheel.motorTorque = 0.0f;
					axleInfo.leftWheel.brakeTorque = axleInfo.rightWheel.brakeTorque = brake;
				} else {
					axleInfo.leftWheel.motorTorque = motor;
					axleInfo.rightWheel.motorTorque = motor;
					axleInfo.leftWheel.brakeTorque = axleInfo.rightWheel.brakeTorque = 0.0f;
				}
			}

			ApplyLocalPositionToVisuals (axleInfo);
		}
	}
}





