using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuScript : MonoBehaviour {

	public Canvas startMenu;
	public Canvas quitMenu;
	public Canvas creditsMenu;
	public Canvas returnMenu;
	public Canvas selectModeMenu;
	public Button startButton;
	public Button selectCarButton;
	public Button exitButton;
	public Camera cameraMenu;
	public Camera cameraSelection;
	public GameObject player;
	public GameObject player1;
	public GameObject player2;

	// Use this for initialization
	void Start () {
		startMenu = startMenu.GetComponent<Canvas> ();
		quitMenu = quitMenu.GetComponent<Canvas> ();
		creditsMenu = creditsMenu.GetComponent<Canvas> ();
		returnMenu = returnMenu.GetComponent<Canvas> ();
		selectModeMenu = selectModeMenu.GetComponent<Canvas> ();
		startButton = startButton.GetComponent<Button> ();
		selectCarButton = selectCarButton.GetComponent<Button> ();
		exitButton = exitButton.GetComponent<Button> ();

		quitMenu.enabled = false;
		creditsMenu.enabled = false;
		returnMenu.enabled = false;
		selectModeMenu.enabled = false;

		cameraMenu.enabled = true;
		cameraSelection.enabled = false;

	}

	public void ExitPress() {
		quitMenu.enabled = true;
		startMenu.enabled = false;
	}

	public void CreditsPress() {
		creditsMenu.enabled = true;
		startMenu.enabled = false;
	}

	public void NoPress() {
		quitMenu.enabled = false;
		creditsMenu.enabled = false;
		startMenu.enabled = true;
	}

	public void ExitGame() {
		Application.Quit ();
	}

	public void PlayButtonPressed() {
		selectModeMenu.enabled = true;
	}

	public void SelectionButtonPressed() {
		cameraMenu.enabled = false;
		cameraSelection.enabled = true;
		startMenu.enabled = false;
		returnMenu.enabled = true;
	}

	public void ReturnButtonPressed() {
		cameraMenu.enabled = true;
		cameraSelection.enabled = false;
		startMenu.enabled = true;
		returnMenu.enabled = false;
	}

	// Update is called once per frame
	void Update () {
		if (cameraSelection.enabled) {
			if (Input.GetKey (KeyCode.Escape)) {
				cameraMenu.enabled = true;
				cameraSelection.enabled = false;
				startMenu.enabled = true;
				returnMenu.enabled = false;
			}
			int car = PlayerPrefs.GetInt ("Car");
			if (car == 0) {
				player.transform.Rotate (Vector3.up, 0.5f, Space.Self);
				player1.transform.localEulerAngles = new Vector3 (0, 180, 0);
				player2.transform.localEulerAngles = new Vector3 (0, 180, 0);
			} else if (car == 1) {
				player1.transform.Rotate (Vector3.up, 0.5f, Space.Self);
				player.transform.localEulerAngles = new Vector3 (0, 180, 0);
				player2.transform.localEulerAngles = new Vector3 (0, 180, 0);
		 	} else if (car == 2) {
				player2.transform.Rotate (Vector3.up, 0.5f, Space.Self);
				player.transform.localEulerAngles = new Vector3 (0, 180, 0);
				player1.transform.localEulerAngles = new Vector3 (0, 180, 0);
			}
		} else {
			player.transform.localEulerAngles = new Vector3 (0, 180, 0);
			player1.transform.localEulerAngles = new Vector3 (0, 180, 0);
			player2.transform.localEulerAngles = new Vector3 (0, 180, 0);
		}
	}
}
