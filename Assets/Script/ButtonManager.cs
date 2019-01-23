using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManager : MonoBehaviour {

    public GameObject currentCheckpoint;

    private Player player;

	public int playerLives;

    // Use this for initialization
    void Start()
    {
        player = FindObjectOfType<Player>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void NewGameBtn(string newGameLevel1)
    {
		PlayerPrefs.SetInt ("PlayerCurrentLives", playerLives);
		Application.LoadLevel(newGameLevel1);
    }

    public void RespawnPlayer()
    {
		PlayerPrefs.SetInt ("PlayerCurrentLives", playerLives);
        Debug.Log("Player Respawn");
        player.transform.position = currentCheckpoint.transform.position;
    }

    public void ExitGameBtn()
    {
        Application.Quit();
    }
}
