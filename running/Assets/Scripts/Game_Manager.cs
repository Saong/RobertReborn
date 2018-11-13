using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
public class GameManager : MonoBehaviour {
    public GameObject playerPrefab; //游戏主角原型体
    private GameObject player; //游戏主角
    public Text ContinueText; //引导玩家重新开始游戏的文本组件
    private float blinkTime = 0f; //文字闪烁时间
    private bool blink; //判断文字是否闪烁
    public Text scoreText;//创建得分组件变量
    private float timeElapsed = 0f; //当前得分
    private float bestTime = 0f; //最佳得分
    private bool gameStarted = true;
    string FormatTime(float value)
    {
        TimeSpan t = TimeSpan.FromSeconds(value);
        return string.Format("{0:D2}:{1:D2}",t.Minutes,t.Seconds);
    }
	// Use this for initialization
	void Start () {
        ResetGame();
        ContinueText.text = "PRESS ANY KEY TO START";
	}
	
	// Update is called once per frame
    void ResetGame()
    {
        GameObject newplayer = Instantiate(playerPrefab, new Vector2(-2, -1), Quaternion.identity) as GameObject;
        timeElapsed = 0;
        ContinueText.canvasRenderer.SetAlpha(0);
      //  player = GameObjectUtil.Instantiate(PlayerPrefs, new Vector3(0, (Screen.height / PiexelPerfectCamera.pixelToUnit) / 2, 0));
    }
    void Update()
    {
        if (!gameStarted)
        {
            /*控制文字闪烁
            blinkTime++;
            if (blinkTime % 148 == 0)
            {
                blink = !blink;
            }
            ContinueText.canvasRenderer.SetAlpha(blink ? 0 : 1);*/

            //拼装当前得分与最佳得分字符串
            scoreText.text = "Time:" + FormatTime(timeElapsed) + "\nBest:" + FormatTime(bestTime);
        }
        else {
            timeElapsed += Time.deltaTime;
            scoreText.text = "TIME:" + FormatTime(timeElapsed);
        }
    }
}
