using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;


[CreateAssetMenu(fileName = "CurrencyItemInfo", menuName = "CurrencyItemInfo/CurrencyItemInfo", order = 0)]
public class CurrencyItemInfo : ScriptableObject
{
    public CurrencytypesItmes types;
    public string ID;
    public string itemName;
    public int itemValue;
    public Sprite itemImg;
    public Sprite currencyIcon;
    public int price;
    public int timelimit;


}

public enum CurrencytypesItmes
{
    Stamina,
    DailyStamina,
    Coin,
    DailyCoin,
    Diamond,
    DailyDiamond
}