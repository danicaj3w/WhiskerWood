using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopButton : MonoBehaviour
{
    [SerializeField] Image plantImage;
    [SerializeField] TextMeshProUGUI itemLabel;
    [SerializeField] TextMeshProUGUI amountLabel;

    public void InitializeButton(CropSO item)
    {
        plantImage.sprite = item.GetCropImg();
        itemLabel.text = item.GetName();
        amountLabel.text = item.GetSellPrice().ToString();
    }
}
