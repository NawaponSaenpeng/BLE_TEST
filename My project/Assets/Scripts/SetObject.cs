using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SetObject : MonoBehaviour
{
    public static SetObject instance;


    [Header("SCENCE")]
    public GameObject menuScene;
    public GameObject selectMusicScene;
    public GameObject shopScene;

    [Header("MENU POPUP")]
    public GameObject helpPopUp;
    public GameObject settingPopUp;
    public GameObject storagePopUp;

    [Header("MENU SCENE")]
    public GameObject proflie;
    public GameObject returnBtn;
    public GameObject update;
    public GameObject flashSale;
    public GameObject buttonUI;

    [Header("STORAGE TEXT AND MENU")]
    public TMP_Text buttonStorageText;
    public TMP_Text themeStorageText;
    public TMP_Text musicStorageText;
    public GameObject buttonStorage;
    public GameObject themeStorage;
    public GameObject musicStorage;
    int itemCountButtonSkin;
    ThemeData data;
    ThemeData currentButtonSkin;

    [Header("PLAY POPUP")]
    public GameObject helpPanel;

    [Header("SHOP MENU")]
    public GameObject special;
    public GameObject theme;
    public GameObject currency;
    public GameObject energyPack;

    [Header("SHOP TEXT")]
    public TMP_Text specialText;
    public TMP_Text themeText;
    public TMP_Text currencyText;
    public TMP_Text energyPackText;

    [Header("THEME")]
    public GameObject button;
    public TMP_Text buttonText;
    public GameObject noteSkin;
    public TMP_Text noteText;
    public GameObject effect;
    public TMP_Text effectText;
    public GameObject themeSet;
    public TMP_Text themeMenuText;

    [Header("CURRENCY")]
    public GameObject coin;
    public TMP_Text coinText;
    public GameObject diamond;
    public TMP_Text diamondText;

    [HideInInspector]
    public int whatScene;

    int test;
    bool menu = true;
    bool play = false;
    bool help = false;
    public void Awake()
    {
        instance = this;
    }
    public void Start()
    {
        ServerApi.GetStorageButtonSkinData((d) => { data = d; }, (e) => { });
        itemCountButtonSkin = data.skinData.Count;
        test = StateScene.menu;
        if (whatScene != test)
        {
            menuScene.SetActive(false);
            selectMusicScene.SetActive(true);
        }
    }



    public void Play()
    {
        menu = false;
        play = true;
        menuScene.SetActive(false);
        selectMusicScene.SetActive(true);

    }

    public void Help()
    {
        if (menu == true)
        {
            if (help == true)
            {
                helpPopUp.SetActive(false);
                help = false;
            }
            else
            {
                help = true;
                helpPopUp.SetActive(true);
            }
        } else if (play == true)
        {
            if (help == true)
            {
                helpPanel.SetActive(false);
                help = false;
            }
            else
            {
                help = true;
                helpPanel.SetActive(true);
            }
        }

    }

    public void Storage()
    {
        storagePopUp.SetActive(true);
        returnBtn.SetActive(true);
        buttonStorageText.color = new Color32(253, 6, 83, 255);
        themeStorageText.color = Color.white;
        musicStorageText.color = Color.white;
        buttonStorage.SetActive(true);
        themeStorage.SetActive(false);
        musicStorage.SetActive(false);
        proflie.SetActive(false);
        update.SetActive(false);
        flashSale.SetActive(false);
        buttonUI.SetActive(false);
        
        ServerApi.GetStorageButtonSkinData((d) => { currentButtonSkin = d; }, (e) => { });

        if (itemCountButtonSkin < currentButtonSkin.skinData.Count)
        {
            StorageShow.instance.CheckSkin("Storage/Button/ThemeData");
        }
        
    }
    public void ReturnLobby()
    {

        play = false;
        menu = true;
        menuScene.SetActive(true);
        selectMusicScene.SetActive(false);
        storagePopUp.SetActive(false);
        returnBtn.SetActive(false);
        proflie.SetActive(true);
        update.SetActive(true);
        flashSale.SetActive(true);
        buttonUI.SetActive(true);

    }

    public void StorageButton()
    {
        
        buttonStorageText.color = new Color32(253, 6, 83, 255);
        themeStorageText.color = Color.white;
        musicStorageText.color = Color.white;
        buttonStorage.SetActive(true);
        themeStorage.SetActive(false);
        musicStorage.SetActive(false);
    }

    public void StorageTheme()
    {
        buttonStorageText.color = Color.white;
        themeStorageText.color = new Color32(253, 6, 83, 255);
        musicStorageText.color = Color.white;
        buttonStorage.SetActive(false);
        themeStorage.SetActive(true);
        musicStorage.SetActive(false);
    }

    public void StorageMusic()
    {
        buttonStorageText.color = Color.white;
        themeStorageText.color = Color.white;
        musicStorageText.color = new Color32(253, 6, 83, 255);
        buttonStorage.SetActive(false);
        themeStorage.SetActive(false);
        musicStorage.SetActive(true);
    }

    public void Setting()
    {
        settingPopUp.SetActive(true);
    }

    public void QuitSetting()
    {
        settingPopUp.SetActive(false);
    }

    public void Shop()
    {
        menuScene.SetActive(false);
        selectMusicScene.SetActive(false);
        shopScene.SetActive(true);
        special.SetActive(true);
        theme.SetActive(false);
        currency.SetActive(false);
        energyPack.SetActive(false);
        specialText.color = Color.white;
        themeText.color = new Color32(253, 6, 83, 255);
        currencyText.color = new Color32(253, 6, 83, 255);
        energyPackText.color = new Color32(253, 6, 83, 255);


    }

    public void exitShop()
    {
        shopScene.SetActive(false);
        if (play == true)
        {
            selectMusicScene.SetActive(true);
        } else if (menu == true)
        {
            menuScene.SetActive(true);
        }

    }

    public void Speaical()
    {
        menuScene.SetActive(false);
        selectMusicScene.SetActive(false);
        shopScene.SetActive(true);
        special.SetActive(true);
        theme.SetActive(false);
        currency.SetActive(false);
        energyPack.SetActive(false);
        specialText.color = Color.white;
        themeText.color = new Color32(253, 6, 83, 255);
        currencyText.color = new Color32(253, 6, 83, 255);
        energyPackText.color = new Color32(253, 6, 83, 255);
    }

    public void EnergyMenu()
    {
        menuScene.SetActive(false);
        selectMusicScene.SetActive(false);
        shopScene.SetActive(true);
        special.SetActive(false);
        theme.SetActive(false);
        currency.SetActive(false);
        energyPack.SetActive(true);
        specialText.color = new Color32(253, 6, 83, 255);
        themeText.color = new Color32(253, 6, 83, 255);
        currencyText.color = new Color32(253, 6, 83, 255);
        energyPackText.color = Color.white;
    }

    public void CoinMenu()
    {
        menuScene.SetActive(false);
        selectMusicScene.SetActive(false);
        shopScene.SetActive(true);
        special.SetActive(false);
        theme.SetActive(false);
        currency.SetActive(true);
        energyPack.SetActive(false);
        specialText.color = new Color32(253, 6, 83, 255);
        themeText.color = new Color32(253, 6, 83, 255);
        currencyText.color = Color.white;
        energyPackText.color = new Color32(253, 6, 83, 255);

        coin.SetActive(true);
        diamond.SetActive(false);
        coinText.color = Color.white;
        diamondText.color = new Color32(253, 6, 83, 255);
    }

    public void DiaondMenu()
    {
        menuScene.SetActive(false);
        selectMusicScene.SetActive(false);
        shopScene.SetActive(true);
        special.SetActive(false);
        theme.SetActive(false);
        currency.SetActive(true);
        energyPack.SetActive(false);
        specialText.color = new Color32(253, 6, 83, 255);
        themeText.color = new Color32(253, 6, 83, 255);
        currencyText.color = Color.white;
        energyPackText.color = new Color32(253, 6, 83, 255);

        coin.SetActive(false);
        diamond.SetActive(true);
        coinText.color = new Color32(253, 6, 83, 255);
        diamondText.color = Color.white;
    }

    public void ThemeMenu()
    {
        menuScene.SetActive(false);
        selectMusicScene.SetActive(false);
        shopScene.SetActive(true);
        special.SetActive(false);
        theme.SetActive(true);
        currency.SetActive(false);
        energyPack.SetActive(false);
        specialText.color = new Color32(253, 6, 83, 255);
        themeText.color = Color.white;
        currencyText.color = new Color32(253, 6, 83, 255);
        energyPackText.color = new Color32(253, 6, 83, 255);
        ButtonMenu();
    }

    public void ButtonMenu()
    {
        button.SetActive(true);
        buttonText.color = Color.white;
        noteSkin.SetActive(false);
        noteText.color = new Color32(253, 6, 83, 255);
        effect.SetActive(false);
        effectText.color = new Color32(253, 6, 83, 255);
        themeSet.SetActive(false);
        themeMenuText.color = new Color32(253, 6, 83, 255);
        
    }

    public void NoteSkinMenu()
    {
        button.SetActive(false);
        buttonText.color = new Color32(253, 6, 83, 255);
        noteSkin.SetActive(true);
        noteText.color = Color.white;
        effect.SetActive(false);
        effectText.color = new Color32(253, 6, 83, 255);
        themeSet.SetActive(false);
        themeMenuText.color = new Color32(253, 6, 83, 255);
    }

    public void EffectMenu()
    {
        button.SetActive(false);
        buttonText.color = new Color32(253, 6, 83, 255);
        noteSkin.SetActive(false);
        noteText.color = new Color32(253, 6, 83, 255);
        effect.SetActive(true);
        effectText.color = Color.white;
        themeSet.SetActive(false);
        themeMenuText.color = new Color32(253, 6, 83, 255);
    }

    public void SubThemeMenu()
    {
        button.SetActive(false);
        buttonText.color = new Color32(253, 6, 83, 255);
        noteSkin.SetActive(false);
        noteText.color = new Color32(253, 6, 83, 255);
        effect.SetActive(false);
        effectText.color = new Color32(253, 6, 83, 255);
        themeSet.SetActive(true);
        themeMenuText.color = Color.white;
    }

}

