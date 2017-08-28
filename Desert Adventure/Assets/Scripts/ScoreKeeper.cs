using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreKeeper : MonoBehaviour
{
    public float KeepTime;
    public int KeepCoins;

    public Text FinalTime;
    public Text FinalCoins;

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

	// Use this for initialization
	void Start ()
    {
        FinalTime.text = "YOU SURVIVED: " + KeepTime.ToString("F");
        FinalCoins.text = "YOU COLLECTED: " + KeepCoins.ToString("F");	
	}
	
	// Update is called once per frame
	void Update ()
    {
        KeepTime = GetComponent<GameManager>()._passedTime;
        KeepCoins = GetComponent<GameManager>()._gamescore;
    }
}
