using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections.Generic;

public class Inventory : MonoBehaviour
{
    [SerializeField] GameObject itemPrefab;
    [SerializeField] CropSO[] allCrops;
    [SerializeField] GameObject[] itemSlots;
    public TilemapManager tilemapManager;
    
    private InventoryItem currentDraggedItem;
    private GameObject visualDragObject;
    private HashSet<GameObject> plantedTiles = new HashSet<GameObject>();

    void Awake()
    {
        for (int i = 0; i < itemSlots.Length; i++)
        {
            GameObject crop = Instantiate(itemPrefab, itemSlots[i].transform);
            InventoryItem newCrop = crop.GetComponent<InventoryItem>();
            newCrop.InitializeItem(this, allCrops[i]);
        }
    }

    public void StartDrag(InventoryItem item, PointerEventData eventData)
    {
        currentDraggedItem = item;

        // Disable raycasts on the original item so we can click through it
        item.GetComponent<CanvasGroup>().blocksRaycasts = false;

        if (itemPrefab != null)
        {
            Debug.LogWarning("Inventory: itemPrefab is null!");
        }

        // Creates a copy of the item we're dragging
        visualDragObject = new GameObject("VisualDragItem", typeof(Image));
        visualDragObject.GetComponent<Image>().sprite = item.GetComponent<Image>().sprite;
        visualDragObject.GetComponent<Image>().SetNativeSize();

        visualDragObject.transform.SetParent(transform); // Note that the crop needs to be inside the parent canvas
        visualDragObject.transform.localScale = item.transform.localScale;
        visualDragObject.transform.position = eventData.position;
    }

    public void UpdateDrag(PointerEventData eventData)
    {
        if (visualDragObject != null)
        {
            visualDragObject.transform.position = eventData.position;

            // Perform a raycast to find the tile under the cursor
            List<RaycastResult> results = new List<RaycastResult>();
            EventSystem.current.RaycastAll(eventData, results);
            
            foreach (RaycastResult result in results)
            {
                if (!plantedTiles.Contains(result.gameObject))
                {
                    Debug.Log("Hovering over a plantable tile!");
                    Vector3 worldPosition = result.gameObject.transform.position;
                    
                    tilemapManager.PlantOnTile(worldPosition, currentDraggedItem.GetCropSO());
                    plantedTiles.Add(result.gameObject);
                }
            }
        }
    }

    public void EndDrag(PointerEventData eventData)
    {
        // Re-enable raycasts on the original item.
        if (currentDraggedItem != null)
        {
            currentDraggedItem.GetComponent<CanvasGroup>().blocksRaycasts = true;
        }

        // Destroy the clone
        if (visualDragObject != null)
        {
            // Destroy(visualDragObject);
        }

        currentDraggedItem = null;
        plantedTiles.Clear();
    }
}