using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class PlayerControl : MonoBehaviour {
    private Rigidbody2D rBody;
    private bool isGround = false;
    public int Hp = 1;
    private Animator ani;
    public PlayerStats player;
    private float m_timer;
    public GameObject cam;
    public GameObject UI_fail;
    public GameObject UI_success;
    public bool isDead = false;
    public bool isSuccess = false;
    public GameObject playerani;
	// Use this for initialization
	void Start () {
        rBody = GetComponent<Rigidbody2D>();
        ani = GetComponent<Animator>(); //得到人物身上的animator组件
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Jump"))
        {
          if (isGround == true && Hp>0)
          {
            player.Energy -= 15.0f;
            //给一个力 方向*数值
            rBody.AddForce(Vector2.up * 400);
            AudioManager.Instance.PlaySound("跳");
          }
        }
        //没有能量后死亡
        if ((player.Energy < -10 || Hp<=0)&&isDead == false )
        {
            isDead = true;
            Hp = 0;
            ani.SetBool("Die", true);
            AudioManager.Instance.PlaySound("Boss死了");
            UI_fail.GetComponent<Animation>().Play();
            Destroy(rBody);
            //SceneManager.LoadScene("game_over");
            //Time.timeScale = 0;  //使所有动画暂停
        }
        if (player.Ring == 3)
        {
            if (isSuccess == true) return;
            isSuccess = true;
            //cam.GetComponent<BlackAndWhite>().enabled = false;
            //cam.GetComponent<WhiteToBlack>().enabled = true;
            UI_success.GetComponent<Animation>().Play();
            //Time.timeScale = 0;
            //playerani.GetComponent<Animation>().enabled = false;
           // SceneManager.LoadScene("game_success");
        }
	}
    public void ShowWord()
    {
        Debug.Log("I love you");
    }
    //跳跃方法
/*    public void Jump()
    {


    }*/
    //发生碰撞
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //碰到地面
        if (collision.collider.tag == "Ground")
        {
            isGround = true;
            //
            ani.SetBool("Jump", false);
        }
    }

    //结束碰撞
    private void OnCollisionExit2D(Collision2D collision)
    { 
        //离开地面
        if (collision.collider.tag == "Ground")
        {
            isGround = false;
            //播放跳跃动画
            ani.SetBool("Jump", true);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //如果碰到了敌人
        if (collision.tag == "Enemy"  && Hp > 0) 
        {
            Hp--;
          /*  if (Hp <= 0)
            {
                ani.SetBool("Die", true);
                AudioManager.Instance.PlaySound("Boss死了");
                Destroy(rBody);
            }*/
        }
    }
    // 利用A和D实现左右移动
    void FixedUpdate() {
        if (isDead || isSuccess) return;
        float move = Input.GetAxis("Horizontal");
        if (move >= 0) { Direction(0); } else { Direction(1);}
        rBody.velocity = new Vector2(move * 2f, rBody.velocity.y);

    
    }
    public void Direction(int i)
    {
        transform.eulerAngles = new Vector3(0, 180 * i, 0);
    }
}
