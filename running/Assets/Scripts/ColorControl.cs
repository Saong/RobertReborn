using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ColorControl : MonoBehaviour {
    public PlayerStats player;
    public GameObject change;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        changeColor();
	}
    public void changeColor()
    {
        if (player.Energy > 250) { change.GetComponent<Image>().color = new Color(3.0f/255, 86.0f/255, 13.0f/255); }//
        else if (player.Energy > 100 && player.Energy <= 250) { change.GetComponent<Image>().color = new Color(162.0f/255, 177.0f/255, 64.0f/255); }
        else { change.GetComponent<Image>().color = new Color(177.0f/255, 45.0f/255, 45.0f/255); }
    }
}
