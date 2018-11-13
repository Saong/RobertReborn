using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class game_over : MonoBehaviour {
    public PlayerControl player;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (player.isSuccess == true)
        {
            if (Input.GetKeyDown(KeyCode.N))
            {
                SceneManager.LoadScene("round2");
            }
            else if (Input.GetKeyDown(KeyCode.E))
            {
                Application.Quit();
            }
        }
        if (player.isDead == true)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene("game");
            }
            else if (Input.GetKeyDown(KeyCode.E))
            {
                Application.Quit();
            }
        }
	}
}
