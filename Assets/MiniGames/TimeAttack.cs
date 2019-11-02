using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeAttack : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private int NumberOfLaps;
    Text Score_Text;
    Text Text_Popup;
    public GameObject Marker;
    int Lap = 0;
    int MarkerPoint = 0;
    float ElapsedTime;
    float[] LapTimeList = new float[6] {0f,0f,0f,0f,0f,0f};
    float LatestLapTime;
    float StartedTime;
    float TimeCount　= 2;
    void Start(){
        Score_Text = this.GetComponent<Manager>().Text_Object.GetComponent<Text>();
        Text_Popup = this.GetComponent<Manager> ().Text_Popup.GetComponent<Text> ();
        StartedTime = Time.time;
    }
    float LapTime(int count){
        float All =0;
        for(int i = 1;i<count;i++) All += LapTimeList[i];
        return ElapsedTime - All;
    }
    void UpdateMarker()
    {
        switch(MarkerPoint){
            case 0: Marker.transform.position = new Vector3(-93.0f,7f,301.5f);break;
            case 1: Marker.transform.position = new Vector3(263f,7f,267f);break;
            case 2: Marker.transform.position = new Vector3(236f,7f,188f);break;
            case 3: Marker.transform.position = new Vector3(189.5f,7f,169f);break;
            case 4: Marker.transform.position = new Vector3(206f,7f,122f);break;
            case 5: Marker.transform.position = new Vector3(244f,7f,109f);break;
            case 6: Marker.transform.position = new Vector3(225f,7f,-30f);break;
            case 7: Marker.transform.position = new Vector3(-103f,5.5f,-10f);break;
            case 8:
            if(Lap == NumberOfLaps){
                Marker.transform.position = new Vector3(-168f,5.5f,-8f);
                LapTimeList[NumberOfLaps] = LatestLapTime = LapTime(NumberOfLaps);
                Marker.GetComponent<MarkerController>().MarkerPoint +=1;
                break;
            }else {
                Marker.GetComponent<MarkerController>().MarkerPoint = 0;
                LapTimeList[Lap] = LatestLapTime = LapTime(Lap);
                Marker.GetComponent<MarkerController>().Lap += 1;
                break;
            }
            case 10:
                Text_Popup.text = "ゴール!!";
                TimeCount -= Time.deltaTime;
                Marker.transform.position = new Vector3(0f,-5000f,0f);
                if(TimeCount <= 0){
                    Marker.GetComponent<MarkerController>().MarkerPoint = 0;
                    Marker.GetComponent<MarkerController>().Lap += 1;
                }
                break;
        }
    }
    public void Game()
    {
        Lap = Marker.GetComponent<MarkerController>().Lap;
        MarkerPoint = Marker.GetComponent<MarkerController>().MarkerPoint;
        UpdateMarker();
        ElapsedTime = Time.time - StartedTime;
        if(ElapsedTime<4) Text_Popup.text = "マーカーを追いかける";
        else if(ElapsedTime<7) Text_Popup.text = "";
        Score_Text.text = "ラップ:" + Lap + "\nタイム:" + Mathf.Round(ElapsedTime*1000f)/1000f + "\nラップタイム:" + Mathf.Round(LatestLapTime*1000f)/1000f;
        if(Lap >= NumberOfLaps+1){
            float Ave = 0;
            for(int i = 1;i<=NumberOfLaps;i++){
                Ave += LapTimeList[i];
            }
            Ave /= (NumberOfLaps);
            this.GetComponent<GameScene>().Result(Mathf.Round(Ave*1000f)/1000f);
        }
    }
}
