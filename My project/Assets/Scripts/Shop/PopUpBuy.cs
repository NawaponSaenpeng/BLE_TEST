using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PopUpBuy : MonoBehaviour
{
    private static PopUpBuy instance;

    public GameObject popUpBuy;
    public GameObject popUpFinsh;
    public string IdObject;
    private CurrencyData playerData;

    public void Buy()
    {

        if (ButtonSkinDisplay.get != null)
        {
            IdObject = ButtonSkinDisplay.get.ID;
            GetID(IdObject);
           
        }


        if (ItemDisplay.get == null)
        {

        } else
        {
            if (ItemDisplay.get.types == CurrencytypesItmes.Coin)
            {
                CoinsRefill();
                
                
            }
            else if (ItemDisplay.get.types == CurrencytypesItmes.Stamina)
            {
                EnergyRefill();
                
            }
            else if (ItemDisplay.get.types == CurrencytypesItmes.Diamond)
            {
                DiamondsRefill();
                
            }
        }
        Cancel();
        FinshBuy();
        
    }

    public void Cancel()
    {
        ItemDisplay.get = null;
        ButtonSkinDisplay.get = null;
        popUpBuy.SetActive(false);

    }

    void GetID(string ID)
    {
        IDObject id = new IDObject();
        id.idItem = ID;
        ServerApi.Test(id, (d) => { }, (e) => { });
    }
    public void DiamondsRefill()
    {
        ServerApi.GetPlayerData((d) => { playerData = d; }, (e) => { });

        int currencyDimonds = playerData.diamonds;
        currencyDimonds += ItemDisplay.get.itemValue;

        playerData.SaveDiamonds(currencyDimonds);
    }


    public void CoinsRefill()
    {
        ServerApi.GetPlayerData((d) => { playerData = d; }, (e) => { });

        int currencyDimonds = playerData.diamonds;
        int currencyCoins = playerData.coins;
        if (currencyDimonds >= ItemDisplay.get.price)
        {
            currencyDimonds -= ItemDisplay.get.price;
            playerData.SaveDiamonds(currencyDimonds);

            currencyCoins += ItemDisplay.get.itemValue;
            playerData.SaveCoins(currencyCoins);

        }

    }

    public void EnergyRefill()
    {
        ServerApi.GetPlayerData((d) => { playerData = d; }, (e) => { });
        int currencyDimonds = playerData.diamonds;
        int currencyEnergy = playerData.energy;
        if (currencyDimonds >= ItemDisplay.get.price)
        {
            currencyDimonds -= ItemDisplay.get.price;
            playerData.SaveDiamonds(currencyDimonds);

            currencyEnergy += ItemDisplay.get.itemValue;
            playerData.SaveEnergy(currencyEnergy);

        }

    }

    public void FinshBuy()
    {
        popUpFinsh.SetActive(true);
    }

    public void CloseFinshPopUp()
    {
        popUpFinsh.SetActive(false);
    }
}
