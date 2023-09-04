using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using System;

public class Coins : MonoBehaviour
{
    public static Coins instance;
    [SerializeField] TMP_Text coinsText;
    [HideInInspector]
    public int currentCoin;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        if (!PlayerPrefs.HasKey("currentCoin"))
        {
            PlayerPrefs.SetInt("currentCoin", 100);
            Load();
            UpdateCoin();

        }
        else
        {
            Load();
            UpdateCoin();
        }
    }

    // Update is called once per frame
    private void Update()
    {
        Load();
        UpdateCoin();
    }

    public void UpdateCoin()
    {
        coinsText.text = currentCoin.ToString();
        Save();
    }

    public void Load()
    {
        currentCoin = PlayerPrefs.GetInt("currentCoin");
        
    }

    public void Save()
    {
        PlayerPrefs.SetInt("currentCoin", currentCoin);
    }

    public void Reset()
    {
        currentCoin = 100;
        UpdateCoin();
        Save();
    }
}
