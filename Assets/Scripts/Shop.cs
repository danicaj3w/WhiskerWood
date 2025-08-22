using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    [SerializeField] Image shop;
    [SerializeField] CoinManager coinManager;

    void Start()
    {

    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        // Open up the shop and set it to active
        shop.gameObject.SetActive(true);
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        // 
        shop.gameObject.SetActive(false);
    }

    public void AddCoins(int amount)
    {
        coinManager.Add(amount);
    }

    public void SubtractCoins(int amount)
    {
        coinManager.Subtract(amount);
    }
}
