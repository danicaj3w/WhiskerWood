using UnityEngine;

public class Shop : MonoBehaviour
{
    [SerializeField] GameObject buttonPrefab;

    public void Start()
    {
        gameObject.SetActive(false);
    }

    public void InitializeShop(CropSO[] allCrops)
    {
        // Initialize button prefabs and fill in the appropriate information
        foreach (CropSO crop in allCrops)
        {
            GameObject button = Instantiate(buttonPrefab, transform);
            ShopButton shopButton = button.GetComponent<ShopButton>();
            shopButton.InitializeButton(crop);
        }
    }

    public void Show()
    {
        gameObject.SetActive(true);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }
}
