using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class AxleLoadmasterCarInfo {
	public WheelCollider leftWheel;
	public GameObject leftWeelMesh;
	public WheelCollider rightWheel;
	public GameObject rightWeelMesh;
	public bool motor;				// is the wheel attached to the motor?
	public bool steering;  			// does this wheel apply steer angle?
}

public class MasterController : MonoBehaviour {

	public List<AxleLoadmasterCarInfo> axleInfos; 		// List of all wheel pairs
	public float maxMotorTorque;						// Maximum torque the motor can apply to the wheels
	public float maxSteeringAngle;						// MAximum steering angle of the wheels

	// Use this for initialization
	void Start () {
		GetComponent<Rigidbody>().centerOfMass = new Vector3(0.0f, -0.5f, 0.0f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void ApplyLocalPositionToVisuals(AxleLoadmasterCarInfo wheelPair) {
		wheelPair.leftWeelMesh.transform.Rotate (Vector3.right, Time.deltaTime * wheelPair.leftWheel.rpm * 10, Space.Self);
		wheelPair.rightWeelMesh.transform.Rotate (Vector3.right, Time.deltaTime * wheelPair.rightWheel.rpm * 10, Space.Self);
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
				axleInfo.leftWheel.motorTorque = motor;
				axleInfo.rightWheel.motorTorque = motor;
			}

			ApplyLocalPositionToVisuals (axleInfo);
		}
	}
}
