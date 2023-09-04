using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using System;

public class Diamond : MonoBehaviour
{
    public static Diamond instance;
    [SerializeField] TMP_Text diamondText;
    [HideInInspector]
    public int currentDiamond;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        if (!PlayerPrefs.HasKey("currentDiamond"))
        {
            PlayerPrefs.SetInt("currentDiamond", 500);
            Load();
            UpdateDiamond();

        }
        else
        {
            Load();
            UpdateDiamond();
        }
    }

    // Update is called once per frame
    private void Update()
    {
        Load();
        UpdateDiamond();
    }

    public void UpdateDiamond()
    {
        diamondText.text = currentDiamond.ToString();
        Save();
    }

    public void Load()
    {
        currentDiamond = PlayerPrefs.GetInt("currentDiamond");

    }

    public void Save()
    {
        PlayerPrefs.SetInt("currentDiamond", currentDiamond);
    }

    public void Reset()
    {
        currentDiamond = 500;
        UpdateDiamond();
        Save();
    }
}
