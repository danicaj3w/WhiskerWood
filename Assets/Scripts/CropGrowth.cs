using UnityEngine;
using UnityEngine.Tilemaps;

public class CropGrowth : MonoBehaviour
{
    // [SerializeField] private TileBase plantableTile;
    
    private CropSO cropData;
    private Tilemap tilemap;
    private SpriteRenderer sr;
    
    private Vector3Int tilePosition;
    private float growthTimer;
    private int currentStage;

    public void InitializeCrop(Tilemap tilemap, Vector3Int tilePosition, CropSO cropData)
    {
        this.tilemap = tilemap;
        this.tilePosition = tilePosition;
        this.cropData = cropData;
        
        sr = gameObject.GetComponent<SpriteRenderer>();
        Debug.Log("Creating a crop");

        growthTimer = 0;
        currentStage = 0;
        
        UpdateGrowthStage();
    }

    private void Update()
    {
        // if (tilemap.GetTile(tilePosition) != plantableTile)
        // {
        //     Destroy(gameObject);
        //     return;
        // }

        if (currentStage < cropData.growthStages.Length - 1)
        {
            growthTimer += Time.deltaTime;
            
            float stageProgress = growthTimer / cropData.timeToGrow;
            int newStage = Mathf.FloorToInt(stageProgress * cropData.growthStages.Length);
            
            if (newStage != currentStage)
            {
                currentStage = newStage;
                UpdateGrowthStage();
            }
        }
    }

    private void UpdateGrowthStage()
    {
        if (currentStage >= 0 && currentStage < cropData.growthStages.Length)
        {
            Debug.Log("Plant growing");
            sr.sprite = cropData.growthStages[currentStage];
        }
    }
}