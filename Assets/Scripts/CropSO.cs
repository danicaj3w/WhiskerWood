using UnityEngine;

[CreateAssetMenu(fileName = "New Crop Data", menuName = "Crop/Crop Data")]
public class CropSO : ScriptableObject
{
    public string cropName;
    public int sellPrice;
    public float timeToGrow;
    public Sprite[] growthStages;
}
