using UnityEngine;
// using UnityEngine.InputSystem;
using UnityEngine.Tilemaps;
using System.Collections.Generic;

public class TilemapManager : MonoBehaviour
{
    [SerializeField] private Tilemap groundTilemap;
    [SerializeField] private Tilemap plantableTilemap;
    [SerializeField] private GameObject plantPrefab;

    private Dictionary<Vector3Int, GameObject> plantDictionary = new Dictionary<Vector3Int, GameObject>();

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