using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Database : MonoBehaviour
{
    public DatabaseID buttonIDs;
    private static Database instance;

    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public static DataID GetID(string ID)
    {
        //return instance.buttonIDs.dataIDs.FirstOrDefault(i => i.IDObject == ID);
        foreach (DataID data in instance.buttonIDs.names)
        {
            if (data.IDObject == ID)
            {
                return data;
            }
        }
        return null;
    }
}
