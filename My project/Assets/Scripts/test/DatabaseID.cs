using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DataID", menuName = "My project/DatabaseID", order = 0)]
public class DatabaseID : ScriptableObject
{
    public List<DataID> names;
}
