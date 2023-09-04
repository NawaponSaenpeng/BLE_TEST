using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SetActiveObject : MonoBehaviour
{
    public GameObject selectMusic, uiSelectMusic, uiButton, update, flashSale, modeQuit,  avartar, backMenu;
    void Start()
    {
        
    }

    public void Play()
    {
        uiButton.SetActive(false);
        update.SetActive(false);
        flashSale.SetActive(false);
        selectMusic.SetActive(true);
        uiSelectMusic.SetActive(true);
        backMenu.SetActive(true);
        avartar.SetActive(false);
        modeQuit.SetActive(true);
    }


    public void BackToLobby()
    {
        uiButton.SetActive(true);
        update.SetActive(true);
        flashSale.SetActive(true);
        selectMusic.SetActive(false);
        uiSelectMusic.SetActive(false);
        backMenu.SetActive(false);
        avartar.SetActive(true);
        modeQuit.SetActive(false);
        MusicButton.get = null;
    }

    public void ReturnToTitle()
    {
        SceneManager.LoadScene("Title");
    }
}
