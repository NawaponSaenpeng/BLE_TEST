using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    public DataID dataID;
    public static test instance;
    public string ID;

    private void Awake()
    {
        instance = this;
        ID = dataID.IDObject;
    }
}
