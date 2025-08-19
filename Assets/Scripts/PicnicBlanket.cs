using UnityEngine;

public class PicnicBlanket : MonoBehaviour
{
    [SerializeField] GameManager gm;

    void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Getting into a picnic blanket.");
        gm.StartRegen(0f, 40f);
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        gm.DrainStamina();
    }
}
