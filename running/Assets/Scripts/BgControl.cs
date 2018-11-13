using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BgControl : MonoBehaviour {
    public float Speed = 0.1f;
    private PlayerControl playerControl;
    public PlayerStats player;
    public Sprite sp1;
    public Sprite sp2;
	// Use this for initialization
	void Start () {
        playerControl = GameObject.FindWithTag("Player").GetComponent<PlayerControl>();
	}
	
	// Update is called once per frame
	void Update () {
        if (playerControl.Hp <= 0 || playerControl.isSuccess == true) return; //人物死亡后背景不动
        //背景持续滚动
        Vector2 v = transform.localPosition;
        v.x -= Speed * Time.deltaTime; //一秒钟走0.2帧
        //判断如果出了屏幕，就移动到新位置
        if (v.x < -7.2f)
        {
            if (player.Ring >= 1) { this.GetComponentInParent<SpriteRenderer>().sprite = sp1; }
            if (player.Ring >= 2) { this.GetComponentInParent<SpriteRenderer>().sprite = sp2; }
            v.x += 7.2f * 2;
        }
        transform.localPosition = v;
	}
}
