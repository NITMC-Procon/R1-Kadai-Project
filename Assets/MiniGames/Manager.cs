using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Manager : MonoBehaviour
{
    public string Mode;
    public GameObject Car;
    public GameObject Text_Object;
    float Score;
    void Start()
    {
        Mode = GameScene.Mode;
        Score = 0.0f;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(Mode == "topspeed") this.GetComponent<TopSpeed>().Game();
        if(Mode == "timeattack") this.GetComponent<TimeAttack>().Game();
        if(Mode == "keepspeed") this.GetComponent<KeepSpeed>().Game();
        if (Input.GetKey(KeyCode.Escape)) this.GetComponent<GameScene>().Menu();
    }
}
