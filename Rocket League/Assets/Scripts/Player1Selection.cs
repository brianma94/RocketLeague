﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1Selection : MonoBehaviour {


	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}

	void OnMouseDown() {
		PlayerPrefs.SetInt ("Car", 1);
		Application.LoadLevel(1);
	}
}
