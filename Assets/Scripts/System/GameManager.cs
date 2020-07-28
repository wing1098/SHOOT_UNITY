using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    private int startMoney  = 0;
    private int startWave   = 0;
    private int startScore  = 0;

    private int startBulletBuff = 0;
    [SerializeField]
    public static int currentMoney;

    public static int wave;

    public TextMeshProUGUI enemyText;
    public TextMeshProUGUI moneyText;


    private void Start()
    {
        currentMoney = startMoney;

        //Reset date
        wave = startWave;
        DisplayScore.score = startScore;

        PistolController.bulletDamage  = startBulletBuff;
        RifleController.bulletDamage   = startBulletBuff;
        ShotGunController.bulletDamage = startBulletBuff;
    }

    void Update()
    {
        //Money Counter
        moneyText.text = "$" + currentMoney.ToString();
        
        //Wave Counter
        enemyText.text = "Wave:" + wave.ToString() ;

        if (wave == 0)
            enemyText.text = "GAME START.";

        if (wave == 3)
           enemyText.text = "BOSS WAVE!!!" ;

        if (wave == 4)
            enemyText.text = "GOAL!!!";
    }
}
