using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class AxleLoadmasterCarInfo1 {
	public WheelCollider leftWheel;
	public GameObject leftWeelMesh;
	public WheelCollider rightWheel;
	public GameObject rightWeelMesh;
	public bool motor;				// is the wheel attached to the motor?
	public bool steering;  			// does this wheel apply steer angle?
}

public class EnemyController : MonoBehaviour {

	public List<AxleLoadmasterCarInfo1> axleInfos1; 		// List of all wheel pairs
	public float maxMotorTorque;						// Maximum torque the motor can apply to the wheels
	public float maxSteeringAngle;						// MAximum steering angle of the wheels

	public GameObject ball;

	// Use this for initialization
	void Start () {
		GetComponent<Rigidbody>().centerOfMass = new Vector3(0.0f, -0.5f, 0.0f);
		ball = GameObject.Find("Ball");
	}

	// Update is called once per frame
	void Update () {
		
	}

	public void ApplyLocalPositionToVisuals(AxleLoadmasterCarInfo1 wheelPair) {
		wheelPair.leftWeelMesh.transform.Rotate (Vector3.right, Time.deltaTime * wheelPair.leftWheel.rpm * 10, Space.Self);
		wheelPair.rightWeelMesh.transform.Rotate (Vector3.right, Time.deltaTime * wheelPair.rightWheel.rpm * 10, Space.Self);
	}

	public void FixedUpdate() {

		Transform target = ball.transform;
		System.Random rnd = new System.Random();

		int number = rnd.Next(1, 100);
		if (number == 1)
		{

			this.transform.LookAt(target);
			this.transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);
		}
		//this.transform.position = Vector3.MoveTowards(transform.position, new Vector3(target.position.x + 1, 0, target.position.z + 1), Time.deltaTime * speed);
		//GetComponent<Rigidbody>().AddForceAtPosition(30 * transform.forward, 
			//transform.position);
		// }

		float motor = maxMotorTorque;
		float steering;
		/*int number1 = rnd.Next(1, 2);
		if (number1 == 1) {
			if (target.transform.localPosition.z > this.transform.localPosition.z) {
				steering = maxSteeringAngle * 1.0f;
			} else if (target.transform.localPosition.z < this.transform.localPosition.z) {
				steering = maxSteeringAngle * -1.0f;
			} else {
				steering = 0.0f;
			}
		}*/

		foreach (AxleLoadmasterCarInfo1 axleInfo in axleInfos1) {
			// Check the steering
			if (axleInfo.steering == true) {
				//axleInfo.leftWheel.steerAngle = steering;
				//axleInfo.rightWheel.steerAngle = steering;
			}

			// Check the motor
			if (axleInfo.motor == true) {
				axleInfo.leftWheel.motorTorque = motor;
				axleInfo.rightWheel.motorTorque = motor;
			}

			ApplyLocalPositionToVisuals (axleInfo);
		}
	}
}
