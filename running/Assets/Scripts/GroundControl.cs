using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundControl : MonoBehaviour {
    public float Speed = 2f;
    public PlayerStats player;
    //地面预设体
    public GameObject[] Grounds;
    //找到玩家
    private PlayerControl playerControl;

	// Use this for initialization
	void Start () {
        playerControl = GameObject.FindWithTag("Player").GetComponent<PlayerControl>();
	}
	
	// Update is called once per frame
	void Update () {
        if (playerControl.Hp <= 0||playerControl.isSuccess == true) return; //人物死亡后背景不动
        if (player.Ring >= 1) { this.Speed = 2.3f; }
        if (player.Ring >= 2) { this.Speed = 2.6f; }
        Vector2 v = transform.localPosition;
        v.x -= Speed * Time.deltaTime;
        if (v.x < -7.2f)
        {
            v.x += 7.2f * 2;
            //切换地形
            //删除旧地形
            foreach (Transform trans in transform)
            {
                Destroy(trans.gameObject);
            }
            //创建新地形
            Instantiate(Grounds[Random.Range(0, Grounds.Length)], transform); //直接加载到父物体中
        }
        transform.localPosition = v;
	}
}
