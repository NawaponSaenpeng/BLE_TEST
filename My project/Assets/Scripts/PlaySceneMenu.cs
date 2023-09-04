using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using System;

public class PlaySceneMenu : MonoBehaviour
{
    public static PlaySceneMenu instance;
    public GameObject setting;
    public GameObject pause;
    public GameObject popUpRetry;
    public GameObject alertPopUp;
    public TMP_Text currencyTypes;
    CurrencyData playerData;
    int currentEnergy;

    [Header("LoadScene")]
    public GameObject load;
    public Image loadImage;
    public TMP_Text levelMode;

    [HideInInspector]
    public int selectMode;

    [HideInInspector]
    public string scene;

    [HideInInspector]
    public int menu = 1;

    void Start()
    {
        instance = this;
        
    }

    public void Resume()
    {
        ContinousGame.instance.Coutinous();
    }

    public void Pause()
    {
        pause.SetActive(true);
        Time.timeScale = 0f;
        AudioSource[] audio = FindObjectsOfType<AudioSource>();
        foreach (AudioSource a in audio)
        {
            a.Pause();
        }
    }

    private int GetCurrentBuildIndex()
    {
        return SceneManager.GetActiveScene().buildIndex;
    }

    public void ReturnMenuMusic()
    {
        menu = SetObject.instance.whatScene + 1;
        StateScene.menu = menu;
        Time.timeScale = 1f;
        scene = "Menu";
        StartCoroutine("LoadScene");

    }

    public void ReturnToLobby()
    {
        menu = 0;
        StateScene.menu = menu;
        Time.timeScale = 1f;
        scene = "Menu";
        StartCoroutine("LoadScene");
    }

    public IEnumerator LoadScene()
    {
        load.SetActive(true);
        selectMode = GameControl.instance.getMode;
        AsyncOperation loadScene = SceneManager.LoadSceneAsync(scene, LoadSceneMode.Single);
        while (!loadScene.isDone)
        {
            loadImage.GetComponent<Image>().sprite = MusicButton.get.image;
            if (selectMode == 0)
            {
                levelMode.text = "Easy";
            }
            else if (selectMode == 1)
            {
                levelMode.text = "Normal";
            }
            else if (selectMode == 2)
            {
                levelMode.text = "Hard";
            }
            yield return null;
        }
    }

    public void PopUpRetry()
    {
        popUpRetry.SetActive(true);
    }

    public void ClosePopUpRetry()
    {
        popUpRetry.SetActive(false);
    }

    public void Retry()
    {
        ServerApi.GetPlayerData((d) => { playerData = d; }, (e) => { });
        currentEnergy = playerData.energy;
        if (currentEnergy >= 1)
        {
            currentEnergy--;
          
            playerData.SaveEnergy(currentEnergy);
            //if (Energy.instance.isRestoring == false)
            //{
                //if (Energy.instance.currentEnergy + 1 == Energy.instance.maxEnergy)
                //{
                    //Energy.instance.nextEnergyTime = Energy.instance.AddDuration(DateTime.Now, Energy.instance.restoreDuration);
                //}

                //StartCoroutine(Energy.instance.RestoreEnergy());
            //}
            Time.timeScale = 1f;
            StartCoroutine("LoadRetry");
            selectMode = GameControl.instance.getMode;
        }
        else
        {
            alertPopUp.SetActive(true);
            currencyTypes.text = "Energy";
        }

    }

    public void CloseAlert()
    {
        alertPopUp.SetActive(false);
    }


    public IEnumerator LoadRetry()
    {
        load.SetActive(true);
        AsyncOperation loadScene = SceneManager.LoadSceneAsync(GetCurrentBuildIndex(), LoadSceneMode.Single);
        while (!loadScene.isDone)
        {
            loadImage.GetComponent<Image>().sprite = MusicButton.get.image;
            if (selectMode == 0)
            {
                levelMode.text = "Easy";
            }
            else if (selectMode == 1)
            {
                levelMode.text = "Normal";
            }
            else if (selectMode == 2)
            {
                levelMode.text = "Hard";
            }
            yield return null;
        }
    }

    public void SettingVoloum()
    {
        pause.SetActive(false);
        setting.SetActive(true);
    }

    public void BackToPause()
    {
        pause.SetActive(true);
        setting.SetActive(false);
    }
}
