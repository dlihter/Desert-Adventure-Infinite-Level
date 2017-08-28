using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public Text TimeInGame;
    public Text TimerText;
    public Text CoinText;
    public float TimeSpent;
    private float CountdownTimer = 5.0f;
    [SerializeField]
    public int _gamescore;
    public float _passedTime;

    void Awake()
    {
        instance = this;
    }


    void Update()
    {
        CountdownTimer -= Time.deltaTime;
        _passedTime += Time.deltaTime;
        if (CountdownTimer <= 0.0f)
        {
            Application.LoadLevel(2);
        }
        TimerText.text = "Countdown: " + CountdownTimer.ToString("F");
        CoinText.text = "Coins: " + _gamescore.ToString();
        TimeInGame.text = "You survived: " + _passedTime.ToString("F");
    }

    private void UpdateGUI()
    {  
        TimerText.text = CountdownTimer.ToString();
    }
    public void AddScore(int amount)
    {
        _gamescore += amount;
        UpdateGUI();
    }
    public void AddTime(int amount)
    {
        CountdownTimer += amount;
        UpdateGUI();
    }
}
