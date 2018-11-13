using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraControl : MonoBehaviour {
    public GameObject robot;
    public Camera cam;
    private Animator ani;
    private AnimatorStateInfo aniInfo;
    private Transform trans;
    private bool isOver = false;
    private Vector3 tarPos;
    private float tarFlo;
    private float tarTime;
	// Use this for initialization
	void Start () {
        ani = robot.GetComponent<Animator>();
        trans = cam.GetComponentInParent<Transform>();
        tarPos = new Vector3(0f, -0.06f, -10f);
        tarFlo = 1.96f;
        tarTime = 0f;
	}
	
	// Update is called once per frame
	void Update () {
        if (isOver)
        {
            trans.position = Vector3.Lerp(trans.position, tarPos, Time.deltaTime);
            cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, tarFlo, Time.deltaTime);
            tarTime += Time.deltaTime;
            if (tarTime > 1.5f)
            { SceneManager.LoadScene("game"); }
            
        }
            
        aniInfo = ani.GetCurrentAnimatorStateInfo(0);
        if (aniInfo.normalizedTime > 0.9f)
        {
            ani.enabled = false;
            isOver = true;    
        }
	}
}
