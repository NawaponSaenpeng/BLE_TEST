using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DatabaseShop : MonoBehaviour
{
    public ThemeData IDs;
    private static DatabaseShop instance;

    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public static ThemeButtonSkinInfo GetID01(string ID)
    {
        
        foreach (ThemeButtonSkinInfo data in instance.IDs.skinData)
        {
            if (data.ID == ID)
            {
                return data;
                
            }
        }
        return null;

    }
}
