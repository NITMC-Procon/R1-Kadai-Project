using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TopSpeed : MonoBehaviour
{

    Text Score_Text;
    GameObject Manager;
    GameObject Car;
    Rigidbody Car_Rigidbody;
    public float MaxSpeed = 0;
    float Speed = 0;
    float Previous_Speed = 0;
    int Crash = 0;
    int Drift = 0;
    float TimeLeft;
    float StartedTime;
    void Start()
    {
        Score_Text = this.GetComponent<Manager>().Text_Object.GetComponent<Text>();
        Car = this.GetComponent<Manager>().Car;
        Car_Rigidbody = Car.GetComponent<Rigidbody>();
        StartedTime = Time.time;
    }

    public void Game()
    {
        Speed = Car.GetComponent<Rigidbody>().velocity.magnitude * 3.6f;
        if(MaxSpeed<Speed){
            MaxSpeed = Speed;
        }
        if(Previous_Speed - Speed >= 20) Crash ++;
        Vector3 Forward = new Vector3(Car.transform.forward.x,0.0f,Car.transform.forward.z);
        if(Vector3.Angle(Forward, Car_Rigidbody.velocity) > 20f && Vector3.Angle(Forward, Car_Rigidbody.velocity) < 80f && Car_Rigidbody.velocity.magnitude*3.6f > 21) Drift ++;
        TimeLeft = 120 - Time.time + StartedTime;
        Score_Text.text = "TimeLeft:" + Mathf.Floor(TimeLeft) + "\nMaxSpeed:" + Mathf.Floor(MaxSpeed) + "\nCrash:" + Crash +"\nDrift:" + Drift;
        Previous_Speed = Speed;

        
        if(TimeLeft <= 0.0f){
            this.GetComponent<GameScene>().Result(Mathf.Floor(MaxSpeed));
        }
    }
}
