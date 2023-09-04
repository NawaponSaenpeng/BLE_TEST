using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ThemeButtonSkinInfo", menuName = "ThemeItemInfo/ThemeButtonSkinInfo", order = 0)]
public class ThemeButtonSkinInfo : ScriptableObject

{
    public string ID;
    public bool alreadyBuy;
    public string itemName;
    public Sprite itemImg;
    public Sprite currencyIcon;
    public int price;
    public string itemDetail;
    
}
