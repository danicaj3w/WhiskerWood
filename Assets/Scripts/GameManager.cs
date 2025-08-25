using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] StaminaBar staminaBar;
    [SerializeField] CropSO[] allCrops;
    [SerializeField] Shop shop;
    [SerializeField] CoinManager coinManager;

    void Start()
    {
        shop.InitializeShop(allCrops);
    }

    public void DrainStamina()
    {
        staminaBar.DrainStamina();
    }

    public void StartRegen(float regenDelay, float staminaRegenRate)
    {
        staminaBar.StartRegen(regenDelay, staminaRegenRate);
    }

    public float GetCurrentStamina()
    {
        return staminaBar.GetCurrentStamina();
    }

    public void AddCoins(int amount)
    {
        coinManager.Add(amount);
    }

    public void SubtractCoins(int amount)
    {
        coinManager.Subtract(amount);
    }

    // ! Used by shop buttons for transactions
    // Fix this, shop buttons shouldn't take in an indiv crop because it's a lot of trouble
    public void PurchaseItem(CropSO crop)
    {
        coinManager.Subtract(crop.GetBuyPrice());
    }

    public void SellItem(CropSO crop)
    {
        coinManager.Add(crop.GetSellPrice());
    }
}
