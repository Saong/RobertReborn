using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour {
    public void ManipulateTime(float newTime, float duration)
    {
        if (Time.timeScale == 0)
            Time.timeScale = 0.1f;
    }
    // Use this for initialization
    void Start()
    {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
