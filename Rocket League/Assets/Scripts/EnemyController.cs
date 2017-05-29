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
			this.transform.LookAt(target);
			this.transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);


		float motor = maxMotorTorque;
		float steering;

		foreach (AxleLoadmasterCarInfo1 axleInfo in axleInfos1) {
			// Check the steering
			if (axleInfo.steering == true) {
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
