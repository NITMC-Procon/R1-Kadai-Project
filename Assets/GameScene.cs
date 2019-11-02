using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using System.IO;

public class GameScene : MonoBehaviour
{
    public static float Score;
    public static uint Carnum;
    public static string Mode;
    void Start(){
        File.Delete("Assets/Resources/hoge.jpg");
        Carnum = 1;
    }
    public static string getMode() {
        return Mode;
    }
    public static float getScore() {
        return Score;
    }
    public void Game(string mode)
    {
        Mode = mode;
        SceneManager.LoadScene("Game");
    }

    public void Result(float score)
    {
        Score = score;
        SceneManager.LoadScene("Result");
    }

    public void Menu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void IIZK()
    {
        Mode = "IIZK";
        SceneManager.LoadScene("Result");
    }
}