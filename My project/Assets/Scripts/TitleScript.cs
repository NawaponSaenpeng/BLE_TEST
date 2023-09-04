using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TitleScript : MonoBehaviour
{
    public GameObject gameName, play, credits, aboutUs;

    [Header("LoadScene")]
    public GameObject load;
    public Image loadImage;

    void start()
    {
        gameName.SetActive(true);
        play.SetActive(false);
        credits.SetActive(false);
        aboutUs.SetActive(false);
    }

    public void Play()
    {
        StartCoroutine("Load");
    }

    public IEnumerator Load()
    {   
        load.SetActive(true);
        AsyncOperation loadScene = SceneManager.LoadSceneAsync("Menu", LoadSceneMode.Single);
        while(!loadScene.isDone)
        {
            loadImage.fillAmount = loadScene.progress;
            yield return null;
        }
    }

    public void ShowCredit()
    {
        gameName.SetActive(false);
        play.SetActive(false);
        credits.SetActive(false);
        aboutUs.SetActive(true);
    }

    public void Back()
    {
        gameName.SetActive(true);
        play.SetActive(true);
        credits.SetActive(true);
        aboutUs.SetActive(false);
    }
}
