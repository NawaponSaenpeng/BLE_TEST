using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemShow : MonoBehaviour
{
    [Header("LimitItem")]
    public ItemDisplay itemLimitPrefab;

    [Header("Item")]
    public ItemDisplay itemPrefab;
    public string path;
    public GameObject buttonParent;
    public CurrencyItemData getData;
    public GameObject popUpBuy;

    private void Start()
    {
        getData = Resources.Load<CurrencyItemData>(path);
        
        
        for (int i = 0; i < getData.itemData.Length; i++)
        {   
            if(getData.itemData[i].types == CurrencytypesItmes.DailyCoin || getData.itemData[i].types == CurrencytypesItmes.DailyDiamond ||
                getData.itemData[i].types == CurrencytypesItmes.DailyStamina)
            {
                ItemDisplay newButton = Instantiate(itemLimitPrefab, buttonParent.transform);
                newButton.name = $"ItemLimit{i}";
                newButton.info = getData.itemData[i];
            } 
            else if (getData.itemData[i].types == CurrencytypesItmes.Coin || getData.itemData[i].types == CurrencytypesItmes.Diamond ||
                getData.itemData[i].types == CurrencytypesItmes.Stamina)
            {
                ItemDisplay newButton = Instantiate(itemPrefab, buttonParent.transform);
                newButton.name = $"Item{i}";
                newButton.info = getData.itemData[i];
                newButton.popUpBuy = popUpBuy;
            } 
            


        }
    }

    
}
