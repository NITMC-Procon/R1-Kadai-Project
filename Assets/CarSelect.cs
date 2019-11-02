using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CarSelect : MonoBehaviour
{
    [SerializeField] Text Text;
    string CarName = "TestCarName";

    void Update()
    {
        switch(GameScene.Carnum)
        {
            case 0: CarName = "Avent";break;
            case 1: CarName = "Porsch";break;
            default: GameScene.Carnum = 0;break;
        }
        Text.text = "車:" + CarName;
    }

    public void CarChange(){
        GameScene.Carnum +=1;
        if(GameScene.Carnum > 1) GameScene.Carnum = 0;
    }
}
