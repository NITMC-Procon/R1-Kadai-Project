using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeepSpeed : MonoBehaviour
{
    Text Score_Text;
    Text Text_Popup;
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
        Text_Popup = this.GetComponent<Manager>().Text_Popup.GetComponent<Text>();
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
        if(Limit<0)Limit = 0;
        TimeLeft = 120 - Time.time + StartedTime;
        if(TimeLeft>116) Text_Popup.text = "時速60km/h以上を維持する";
        else if(TimeLeft>115) Text_Popup.text = "";
        Score_Text.text = "残り時間:" + Mathf.Floor(TimeLeft) + "\nタイマー:" + Mathf.Floor(Limit*10)/10;
        if(Mathf.Floor(Limit*10)/10 <= 0 || TimeLeft <= 0) Score = 120 - TimeLeft;
        if(Score != -1){
            if(Score < 120)Text_Popup.text = "失敗!!";
            else Text_Popup.text = "クリア!!";
            Delay -= Time.deltaTime;
            if(Delay <= 0){
                this.GetComponent<GameScene>().Result(Mathf.Floor(Score));
            }
        }
    }
}
