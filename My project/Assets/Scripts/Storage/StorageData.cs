using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "StorageData", menuName = "My project/StorageData", order = 0)]
public class StorageData : ScriptableObject
{
    public StorageItems[] storageData;
}
