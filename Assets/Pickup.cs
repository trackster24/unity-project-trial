using UnityEngine;

using UnityEngine;

public class Pickup : MonoBehaviour
{
    public Item item = new Item("Item Name", 1);
    public GameObject itemPrefab;

    void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Player"))
        {
            Inventory.instance.AddItem(item);
            Destroy(gameObject);
        }
    }
}
