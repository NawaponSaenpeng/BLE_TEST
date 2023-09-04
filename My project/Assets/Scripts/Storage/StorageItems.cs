using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "StorageData", menuName = "My project/StorageItems", order = 0)]
public class StorageItems : ScriptableObject
{
    public string ID;
    public Sprite itemImg;
    public Sprite preViewImg;
    public string itemName;
    public string itemData;
}
