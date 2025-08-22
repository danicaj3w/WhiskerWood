using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinManager : MonoBehaviour
{
    private int totalCoins;

    void Start()
    {
        totalCoins = 0;
    }

    public void Add(int amount)
    {
        totalCoins += amount;
    }

    public void Subtract(int amount)
    {
        totalCoins -= amount;
    }

    public int GetTotalCoins()
    {
        return totalCoins;
    }
}
