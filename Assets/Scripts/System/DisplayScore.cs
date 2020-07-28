using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DisplayScore : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    static public int score;


    private void Start()
    {
    }

    void Update()
    {

        //score text
        score = GameManager.currentMoney * PlayerHealthManager.currentHealth;
        scoreText.text = "SCORE:" + "\r\n" +
                         score.ToString() + "!!!" + "\r\n" +
                         score.ToString() + "!!!" + "\r\n" +
                         score.ToString() + "!!!" + "\r\n" +
                         score.ToString() + "!!!";

    }
}
