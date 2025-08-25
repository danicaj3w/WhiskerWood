using UnityEngine;

public class Farmer : MonoBehaviour
{
    [SerializeField] Shop shop;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        shop.Show();
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        shop.Hide();
    }
}
