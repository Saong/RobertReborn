using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class MainUI : MonoBehaviour {
    public Text starText;
    public PlayerStats player;
    public Text ringText;
    public Image gameover;
    //private int star = 0;
    public RectTransform Energy;
    private PlayerControl playerControl;
	// Use this for initialization
	void Start () {
		playerControl = GameObject.FindWithTag("Player").GetComponent<PlayerControl>();
	}
	
	// Update is called once per frame
	void Update () {
        DrawRing();
        if (playerControl.isDead || playerControl.isSuccess == true) return;
        DrawStar();
        Hurt();
        DrawEnergy();
	}
    public void Hurt()
    {
        
        player.Energy -= 50.0f * Time.deltaTime;
    }
    public void DrawStar()
    {
        /*if (player.starsCollected > star) {
            starText.GetComponentInParent<Animation>().Play();
        }
        star = player.starsCollected;*/
        starText.text = "x " + player.starsCollected;
        PlayerPrefs.SetInt("score", player.starsCollected);
    }
    public void DrawRing()
    {
        /*if (player.starsCollected > star) {
            starText.GetComponentInParent<Animation>().Play();
        }
        star = player.starsCollected;*/
        ringText.text = "x " + player.Ring;
    }
    public void DrawEnergy()
    {
        float enr = player.Energy;
        if (playerControl.Hp <= 0) return;  //人物死亡后能量条不动
        if (enr > 500) { enr = 500; player.Energy = 500; }  //确保能量不会溢出
        Energy.sizeDelta = new Vector2(Mathf.Lerp(Energy.sizeDelta.x,enr,0.12f), 47.92f);
    }
}
