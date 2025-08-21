using UnityEngine;
// using UnityEngine.InputSystem;
using UnityEngine.Tilemaps;
using System.Collections.Generic;

public class TilemapManager : MonoBehaviour
{
    [SerializeField] private Tilemap groundTilemap;
    [SerializeField] private Tilemap plantableTilemap; // plantable layer
    [SerializeField] private GameObject plantPrefab;
    // [SerializeField] private CropSO cropToPlant;

    private Dictionary<Vector3Int, GameObject> plantDictionary = new Dictionary<Vector3Int, GameObject>();
    // private Vector2 mousePosition;

    // public void OnMousePosition(InputValue value)
    // {
    //     mousePosition = value.Get<Vector2>();
    // }

    // public void OnFire()
    // {
    //     Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(mousePosition);
    //     Vector3Int tilePosition = groundTilemap.WorldToCell(mouseWorldPos);
    //     bool isPlantable = plantableTilemap.HasTile(tilePosition);

    //     Debug.Log("Planting a seed");

    //     if (isPlantable && !plantDictionary.ContainsKey(tilePosition))
    //     {
    //         SpawnPlant(tilePosition);
    //     }
    // }

    public void PlantOnTile(Vector3 dropPosition, CropSO cropToPlant)
    {
        Vector3Int tilePosition = groundTilemap.WorldToCell(dropPosition);
        bool isPlantable = plantableTilemap.HasTile(tilePosition);

        if (isPlantable && !plantDictionary.ContainsKey(tilePosition))
        {
            SpawnPlant(tilePosition, cropToPlant);
        }
    }

    private void SpawnPlant(Vector3Int tilePosition, CropSO cropToPlant)
    {
        GameObject newPlant = Instantiate(plantPrefab, plantableTilemap.CellToWorld(tilePosition), Quaternion.identity);
        CropGrowth CropGrowthScript = newPlant.GetComponent<CropGrowth>();

        CropGrowthScript.InitializeCrop(plantableTilemap, tilePosition, cropToPlant);
        plantDictionary.Add(tilePosition, newPlant);
    }

    public Tilemap GetPlantableTilemap()
    {
        return plantableTilemap;
    }
}