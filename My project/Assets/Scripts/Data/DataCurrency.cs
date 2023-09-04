using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using System;

public class DataCurrency : MonoBehaviour
{
    public static DataCurrency instance;
    public CurrencyData getData;

    [SerializeField] TMP_Text coinsText;
    [SerializeField] TMP_Text diamondsText;
    [SerializeField] TMP_Text energyText;
 
    void Start()
    {
        instance = this;
        getData = Resources.Load<CurrencyData>("Currency/CurrencyData");
    }

    void Update()
    {
        getData.UpdateCoins(coinsText);
        getData.UpdateDiamonds(diamondsText);
        getData.UpdateEnergy(energyText);
    }

}
