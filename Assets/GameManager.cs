using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public int Score;

    private void Awake()
    {
        Instance = this;
    }

    public void GameOver()
    {
        Invoke("GameOver_", 2);
    }
    void GameOver_()
    {
        SceneManager.LoadScene(0);
    }
}
