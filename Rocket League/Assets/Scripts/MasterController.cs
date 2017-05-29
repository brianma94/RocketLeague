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
		if (Input.GetKey(KeyCode.Escape))
		{
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
		visualWheelLeft.transform.rotation = rotationL;
		visualWheelRight.transform.rotation = rotationR;

	}

	public void FixedUpdate() {
        if (Input.GetKey(KeyCode.Space) && Physics.Raycast(transform.position, -transform.up, 2)) {
            GetComponent<Rigidbody>().AddForce(0, 50,0, ForceMode.Impulse);
        }
        string s = this.name;
        GameObject p = GameObject.Find(name + "/Particle");
        GameObject p1 = GameObject.Find(name + "/Particle1");
        if (Input.GetKey(KeyCode.UpArrow))
        {
            p.GetComponent<ParticleSystem>().enableEmission = true;
            p1.GetComponent<ParticleSystem>().enableEmission = true;

        }
        else
        {
            p.GetComponent<ParticleSystem>().enableEmission = false;
            p1.GetComponent<ParticleSystem>().enableEmission = false;
        }
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





