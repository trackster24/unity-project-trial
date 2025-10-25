using UnityEngine;

public class EquipmentManager : MonoBehaviour
{
    public Transform weaponHoldPoint;
    private GameObject currentWeapon;

    public void EquipItem(Item item)
    {
        if (item.prefab == null)
        {
            Debug.LogWarning("Item has no prefab to equip!");
            return;
        }

        if (currentWeapon != null)
        {
            Destroy(currentWeapon);
        }

        currentWeapon = Instantiate(item.prefab, weaponHoldPoint);
        currentWeapon.transform.localPosition = Vector3.zero;
        currentWeapon.transform.localRotation = Quaternion.identity;

        Debug.Log("Equipped " + item.name);
    }
}
