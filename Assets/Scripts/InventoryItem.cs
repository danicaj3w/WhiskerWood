using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class InventoryItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private Inventory inventory;
    private CropSO crop;

    public void InitializeItem(Inventory inventoryManager, CropSO cropSO)
    {
        inventory = inventoryManager;
        crop = cropSO;

        GetComponent<Image>().sprite = cropSO.GetSeedImg(); // Get it from an object that's being passed in
        GetComponent<Image>().SetNativeSize();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        inventory.StartDrag(this, eventData);
    }

    public void OnDrag(PointerEventData eventData)
    {
        inventory.UpdateDrag(eventData);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        inventory.EndDrag(eventData);
    }

    public CropSO GetCropSO()
    {
        return crop;
    }
}