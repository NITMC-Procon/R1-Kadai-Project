using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameScene : MonoBehaviour
{
    public static float Score;
    public static string Mode;
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
    
    void Update(){
        Debug.Log(1f / Time.deltaTime);
    }
}