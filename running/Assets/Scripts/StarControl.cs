using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarControl : MonoBehaviour {
    //设置分数，每颗星星一分
    public int starValue = 1;
    //private Animator ani;
	// Use this for initialization
	void Start () {
        //ani = GetComponent<Animator>(); //得到人物身上的animator组件
	}
	
	// Update is called once per frame
	void Update () {

	}
    //如果有人进入触发区域
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            AudioManager.Instance.PlaySound("金币");  //吃金币时有声音特效
            PlayerStats stats = collision.gameObject.GetComponent<PlayerStats>();  //从碰撞的对象中获取PlayerStats组件
            stats.CollectStar(this.starValue);  //收集星星后分数增加
          //  ani.SetTrigger("Eat");
            Destroy(this.gameObject);  //吃完金币金币被销毁
        }
    }
}
