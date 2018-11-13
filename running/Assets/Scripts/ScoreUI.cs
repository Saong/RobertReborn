using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreUI : MonoBehaviour {
    public Text starText;
    public int score_num;
    public PlayerStats player;
	// Use this for initialization
	void Start () {
        //score_num = PlayerPrefs.GetInt("score",0);
	}
	
	// Update is called once per frame
	void Update () {
        DrawStar();
	}

    public void DrawStar()
    {
        /*if (player.starsCollected > star) {
            starText.GetComponentInParent<Animation>().Play();
        }
        star = player.starsCollected;*/
        starText.text = "最终得分: " + (player.Ring*10+player.starsCollected);
    }
}
