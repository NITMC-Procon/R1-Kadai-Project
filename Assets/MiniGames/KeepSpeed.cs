using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeepSpeed : MonoBehaviour
{
    Text Score_Text;
    GameObject Manager;
    GameObject Car;
    Rigidbody Car_Rigidbody;
    float Speed = 0;
    float TimeLeft;
    float StartedTime;
    float Limit = 4.0f;
    float Delay = 2.0f;
    float Score = -1;
    bool GameStarted = false;
    void Start()
    {
        Score_Text = this.GetComponent<Manager>().Text_Object.GetComponent<Text>();
        Car = this.GetComponent<Manager>().Car;
        Car_Rigidbody = Car.GetComponent<Rigidbody>();
        StartedTime = Time.time;
    }

    // Update is called once per frame
    public void Game()
    {
        Speed = Car.GetComponent<Rigidbody>().velocity.magnitude * 3.6f;
        if(GameStarted == false){
            if(Speed>60f){
                GameStarted = true;
            }
            StartedTime = Time.time;
        }
        if(GameStarted == true && Speed<60f) {
            if(Limit>0) Limit -= Time.deltaTime;
        }else if(Speed>60f) Limit = 4.0f;
        TimeLeft = 120 - Time.time + StartedTime;
        Score_Text.text = "TimeLeft:" + Mathf.Floor(TimeLeft) + "\nExprode:" + Mathf.Floor(Limit*10)/10;
        if(Mathf.Floor(Limit*10)/10 < 0 || TimeLeft < 0) Score = 120 - TimeLeft;
        if(Score != -1){
            Delay -= Time.deltaTime;
            if(Delay <= 0){
                this.GetComponent<GameScene>().Result(Mathf.Floor(Score));
            }
        }
    }
}
