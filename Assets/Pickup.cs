using UnityEngine;

using UnityEngine;

public class Pickup : MonoBehaviour
{
    public Item itemData;

    void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Player"))
        {
            Inventory.instance.AddItem(itemData);
            Destroy(gameObject);
        }
    }
}
