using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour {

	//Cara pertama tapi gk paka menu
	/*public static bool gamePaused = false;
	public GameObject player;

	Rigidbody2D rb;

	private void Start()
	{
		rb = player.GetComponent<Rigidbody2D>();
	}

	// Update is called once per frame
	void Update ()
	{
		if (Input.GetKeyDown(KeyCode.P))
			gamePaused = !gamePaused;
		if (gamePaused == true)
			Time.timeScale = 0;
		else 
			Time.timeScale = 1;       
	}*/


	//Cara Dua Tapi Pake Menu
	public bool isPaused;

	public string mainMenu;

	public GameObject pauseMenuCanvas;

	private void Start()
	{
		isPaused = false;
	}


	void Update(){
		if (isPaused) {
			pauseMenuCanvas.SetActive (true);
			Time.timeScale = 0;
		} else {
			pauseMenuCanvas.SetActive (false);
			Time.timeScale = 1;
		}

		if (Input.GetKeyDown (KeyCode.Escape) || Input.GetKeyDown(KeyCode.P)) {
			isPaused = !isPaused;
		}
	}

	public void Resume(){
		isPaused = false;
	}

	public void Quit(){
		Application.LoadLevel (mainMenu);
	}
    public void pressPause()
    {
        isPaused = true;
    }
    
}
