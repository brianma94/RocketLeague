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

	// Use this for initialization
	void Start () {
		GetComponent<Rigidbody>().centerOfMass = new Vector3(0.0f, -1.0f, 0.0f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void ApplyLocalPositionToVisuals(AxleLoadmasterCarInfo wheelPair) {
		/*wheelPair.leftWeelMesh.transform.Rotate (Vector3.right, Time.deltaTime * wheelPair.leftWheel.rpm * 10, Space.Self);
		wheelPair.rightWeelMesh.transform.Rotate (Vector3.right, Time.deltaTime * wheelPair.rightWheel.rpm * 10, Space.Self);

		Debug.Log(wheelPair.leftWeelMesh.transform.localRotation.eulerAngles.y); 
		if (Input.GetKey (KeyCode.LeftArrow) && wheelPair.steering && (wheelPair.leftWeelMesh.transform.localRotation.eulerAngles.y > 330.0f || wheelPair.leftWeelMesh.transform.localRotation.eulerAngles.y <= 30.1f)) {
			wheelPair.leftWeelMesh.transform.Rotate (Vector3.up, -30.0f, Space.Self);
			wheelPair.rightWeelMesh.transform.Rotate (Vector3.up, -30.0f, Space.Self);
		} else if (Input.GetKey (KeyCode.RightArrow) && wheelPair.steering && (wheelPair.rightWeelMesh.transform.localRotation.eulerAngles.y >= 330.0f || wheelPair.leftWeelMesh.transform.localRotation.eulerAngles.y < 30.0f)) {
			wheelPair.leftWeelMesh.transform.Rotate (Vector3.up, 30.0f, Space.Self);
			wheelPair.rightWeelMesh.transform.Rotate (Vector3.up, 30.0f, Space.Self);
			//Debug.Log("SUPUTAMADRE"); 
		} else if (!Input.GetKey (KeyCode.RightArrow) && !Input.GetKey (KeyCode.LeftArrow)) {
			if (wheelPair.steering) {
				wheelPair.leftWeelMesh.transform.localEulerAngles = Vector3.zero;
				wheelPair.rightWeelMesh.transform.localEulerAngles = Vector3.zero;
			}
		}*/

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
					Debug.Log ("hey jinny");
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





