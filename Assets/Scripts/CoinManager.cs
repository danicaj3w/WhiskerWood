using TMPro;
using UnityEngine;

public class CoinManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI coinText;
    private int totalCoins;

    void Start()
    {
        totalCoins = 0;
        SetCoinText();
    }

    public void Add(int amount)
    {
        totalCoins += amount;
        SetCoinText();
    }

    public void Subtract(int amount)
    {
        totalCoins -= amount;
        SetCoinText();
    }

    public int GetTotalCoins()
    {
        return totalCoins;
    }

    public void SetCoinText()
    {
        coinText.text = totalCoins.ToString();
    }
}
