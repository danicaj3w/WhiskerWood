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

        // Creates a copy of the item we're dragging
        visualDragObject = new GameObject("VisualDragItem", typeof(Image));
        visualDragObject.GetComponent<Image>().sprite = item.GetComponent<Image>().sprite;
        visualDragObject.GetComponent<Image>().SetNativeSize();

        visualDragObject.transform.SetParent(transform); // Note that the parent needs to be a Canvas to render
        visualDragObject.transform.localScale = item.transform.localScale;
        visualDragObject.transform.position = eventData.position;
    }

    public void UpdateDrag(PointerEventData eventData)
    {
        if (visualDragObject != null)
        {
            visualDragObject.transform.position = eventData.position;

            // Find the tile under the cursor
            Vector3 worldPosition = Camera.main.ScreenToWorldPoint(eventData.position);
            RaycastHit2D hit = Physics2D.Raycast(worldPosition, Vector2.zero);

            if (hit.collider != null && hit.collider.gameObject == tilemapManager.GetPlantableTilemap().gameObject)
            {
                tilemapManager.PlantOnTile(worldPosition, currentDraggedItem.GetCropSO());
            }
        }
    }

    public void EndDrag(PointerEventData eventData)
    {
        if (currentDraggedItem != null)
        {
            currentDraggedItem.GetComponent<CanvasGroup>().blocksRaycasts = true;
        }

        // Destroy the clone
        if (visualDragObject != null)
        {
            Destroy(visualDragObject);
        }

        currentDraggedItem = null;
        plantedTiles.Clear();
    }
}