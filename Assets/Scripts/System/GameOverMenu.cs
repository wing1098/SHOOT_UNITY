using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour
{
    [SerializeField]
    private GameObject bgm;

    private void Start()
    {
        bgm = GameObject.FindGameObjectWithTag("BGM");
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        //GameManager.wave = 0;
        //DisplayScore.score = 0;
        //GameManager.currentMoney = 0;
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 2);
        Destroy(bgm);
    }
}
