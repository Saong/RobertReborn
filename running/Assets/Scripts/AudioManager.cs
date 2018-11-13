using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {
    public static AudioManager Instance;  //单例模式，相当于静态变量
    //音乐播放器
    public AudioSource MusicPlayer;
    //音效播放器
    public AudioSource SoundPlayer;
	// Use this for initialization
	void Start () {
        Instance = this;
	}
	
	//播放音乐
    public void PlayMusic(string name){
        if(MusicPlayer.isPlaying == false){
          AudioClip clip = Resources.Load<AudioClip>(name);
          MusicPlayer.clip = clip;
          MusicPlayer.Play();
        }
    }
    //停止播放音乐
    public void StopMusic(){
            MusicPlayer.Stop();
        }
    //播放音效
    public void PlaySound(string name)
    {
        //if (SoundPlayer.isPlaying == false)
        //{
            AudioClip clip = Resources.Load<AudioClip>(name);
            SoundPlayer.PlayOneShot(clip);  //音效的播放方法，可以同一时间播放多种音效
       // }
    }

}
