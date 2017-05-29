using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadOnClick : MonoBehaviour {

	void start() {
		
	}

	public void LoadScene(int mode) {
		PlayerPrefs.SetInt ("Mode", mode);
		Application.LoadLevel(1);
	}
}
