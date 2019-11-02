using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowScore : MonoBehaviour
{
    string Mode = GameScene.getMode();
    float Score = GameScene.getScore();
    Text ScoreBoard;
    void Start()
    {
        ScoreBoard = this.GetComponent<Text>();
        ScoreBoard.text = "スコア:" +  Score;
    }
}
