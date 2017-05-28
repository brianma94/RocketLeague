using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadOnClick : MonoBehaviour {

	void start() {
		
	}

	public void LoadScene(int level) {
		Application.LoadLevel(level);

	}
}
