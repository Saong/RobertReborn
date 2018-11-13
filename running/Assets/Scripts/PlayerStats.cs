using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour {
    public int health = 6;
    public int Ring = 0;
    public int starsCollected = 0;
    public float maxEnergy = 500.0f;
    public float Energy = 500.0f;
    public void CollectStar(int starValue)
    {
        this.starsCollected = this.starsCollected + starValue;
    }
    public void CollectCoin(float starValue)
    {
        this.Energy = this.Energy + starValue;
    }
    public void CollectRing(int ringValue)
    {
        this.Ring = this.Ring + ringValue;
    }
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
