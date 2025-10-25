using UnityEngine;
[System.Serializable]

[CreateAssetMenu(fileName = "InventoryItem", menuName = "Inevtory/Items")]
public class Item : ScriptableObject
{
    public string name;
    public int count;
    public GameObject prefab;

    public Item(string name, int count, GameObject prefab)
    {
        this.name = name;
        this.count = count;
        this.prefab = prefab;
    }
}
