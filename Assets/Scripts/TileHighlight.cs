using UnityEngine;
using UnityEngine.Tilemaps;

// Source - https://youtu.be/YVgJ4HtH6bo?si=kftjm1vtYksr1dCi
public class TileHighlight : MonoBehaviour
{
    public Tilemap plantableTilemap;
    public TileBase highlightTile;
    public Tilemap highlightTilemap;

    private Vector3Int previousHoveredTile = Vector3Int.one * -1;

    void Start()
    {
        // highlightTilemap = transform.Find("HighlightTilemap")?.GetComponent<Tilemap>();

        if (highlightTilemap == null)
        {
            Debug.LogError("HighlightTilemap was not found! Please check its name and hierarchy.");
        }
    }

    void Update()
    {
        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3Int currentHoveredTile = plantableTilemap.WorldToCell(mouseWorldPos);

        if (currentHoveredTile != previousHoveredTile)
        {
            if (previousHoveredTile.x >= 0)
            {
                highlightTilemap.SetTile(previousHoveredTile, null);
            }

            if (plantableTilemap.HasTile(currentHoveredTile))
            {
                highlightTilemap.SetTile(currentHoveredTile, highlightTile);
            }

            previousHoveredTile = currentHoveredTile;
        }
    }
}
