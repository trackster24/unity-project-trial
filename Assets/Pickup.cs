using UnityEngine;

using UnityEngine;

public class Pickup : MonoBehaviour
{
    public string itemName = "Item Name";
    public int itemCount = 1;
    public GameObject itemPrefab;

    void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Player"))
        {
            Item newItem = new Item(itemName, itemCount, itemPrefab);
            Inventory.instance.AddItem(newItem);
            Destroy(gameObject);
        }
    }
}
