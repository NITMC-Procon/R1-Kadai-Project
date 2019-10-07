using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameScene : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("Game");
    }
}