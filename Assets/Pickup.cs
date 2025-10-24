using UnityEngine;

using UnityEngine;

public class Pickup : MonoBehaviour
{
    public string itemName = "Item Name";
    public int itemCount = 1;

    void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Player"))
        {
            Inventory.instance.AddItem(item);
            Destroy(gameObject);
        }
    }
}
