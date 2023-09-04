using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CurrencyItemData", menuName = "CurrencyItemInfo/CurrencyItemData", order = 0)]
public class CurrencyItemData : ScriptableObject
{
    public TypesItmes types;
    public CurrencyItemInfo[] itemData;
}

public enum TypesItmes
{
    CoinData,
    DiamondData,
    StaminaData
}