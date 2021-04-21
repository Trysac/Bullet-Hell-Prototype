using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int Score { get; set; }
    public int Coins { get; set; }


    void Start()
    {
        Score = 0;
        Coins = 0;
    }

    void Update()
    {
        
    }

    public void AddToScore(int points) 
    {
        Score += points;
    }
    public void AddCoins(int contity)
    {
        Coins += contity;
    }
}
