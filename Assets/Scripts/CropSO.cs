using UnityEngine;

[CreateAssetMenu(fileName = "New Crop Data", menuName = "Crop/Crop Data")]
public class CropSO : ScriptableObject
{
    public string cropName;
    public int sellPrice;
    public float timeToGrow;
    public Sprite[] growthStages;
    public Sprite seedImg;
    public Sprite cropImg;

    public Sprite GetSeedImg()
    {
        return seedImg;
    }
    
    public Sprite GetCropImg()
    {
        return cropImg;
    }
}
