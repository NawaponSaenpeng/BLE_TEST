using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ThemeData", menuName = "ThemeItemInfo/ThemeData", order = 0)]

public class ThemeData : ScriptableObject
{
    public List<ThemeButtonSkinInfo> skinData;

    public void Remove(ThemeButtonSkinInfo name)
    {
        skinData.Remove(name);
    }

    public void Add(ThemeButtonSkinInfo name)
    {
        skinData.Add(name);
    }

    public void Save(ThemeData themeData)
    {
        skinData = themeData.skinData;
    }
}
