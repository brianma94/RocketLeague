using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuScript : MonoBehaviour {

	public Canvas startMenu;
	public Canvas quitMenu;
	public Button startButton;
	public Button selectCarButton;
	public Button exitButton;

	// Use this for initialization
	void Start () {
		startMenu = startMenu.GetComponent<Canvas> ();
		quitMenu = quitMenu.GetComponent<Canvas> ();
		startButton = startButton.GetComponent<Button> ();
		selectCarButton = selectCarButton.GetComponent<Button> ();
		exitButton = exitButton.GetComponent<Button> ();

		quitMenu.enabled = false;
	}

	public void ExitPress() {
		quitMenu.enabled = true;
		startButton.enabled = false;
		exitButton.enabled = false;
	}

	public void NoPress() {
		quitMenu.enabled = false;
		startButton.enabled = true;
		exitButton.enabled = true;
	}

	public void ExitGame() {
		Application.Quit ();
	}

	// Update is called once per frame
	void Update () {
		
	}
}
