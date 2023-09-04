using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using System;

[CreateAssetMenu(fileName = "CurrencyData", menuName = "My project/CurrencyData", order = 0)]
public class CurrencyData : ScriptableObject
{
    public int energy;


    public int coins;
    public int diamonds;


    public void SaveEnergy(int num)
    {
        energy = num;
    }

    public void UpdateEnergy(TMP_Text energys)
    {
        energys.text = energy.ToString();
    }

    public void LoadEnergy(int energys)
    {
        energys = energy;
    }

    public void SaveCoins(int num)
    {
        coins = num;
    }
    
    public void UpdateCoins(TMP_Text coin)
    {
        coin.text = coins.ToString();
    }

    public void LoadCoins(int coin)
    {
        coin = coins;
    }

    public void SaveDiamonds(int num)
    {
        diamonds = num;
    }

    public void UpdateDiamonds(TMP_Text diamond)
    {
        diamond.text = diamonds.ToString();
    }

    public void LoadDiamonds(int diamond)
    {
        diamond = diamonds;
    }
}
