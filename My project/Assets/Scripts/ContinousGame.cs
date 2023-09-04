using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ContinousGame : MonoBehaviour
{   
    public static ContinousGame instance;
    public GameObject popUpPause, score, combo, button;

    [Header ("COUNDOWN TEXT")]
    public TMP_Text countDownText;
    int countDownTime = 3;

    void Awake() {
        instance = this;
    }  

    void Start() {
        score.SetActive(true);
        combo.SetActive(true);
        button.SetActive(true);
        popUpPause.SetActive(false);
    }

    IEnumerator CountDownToStart() {
        while (countDownTime > 0) {
            countDownText.text = countDownTime.ToString();

            yield return new WaitForSecondsRealtime(1f);

            countDownTime-- ;
        }

        yield return new WaitForSecondsRealtime(1f);

        countDownText.gameObject.SetActive(false);
        Time.timeScale = 1f;
        AudioSource[] audio = FindObjectsOfType<AudioSource>();
        foreach (AudioSource a in audio) {
            a.Play();
        }
    }

    public void Coutinous() {
        countDownTime = 3;
        countDownText.gameObject.SetActive(true);
        popUpPause.SetActive(false);
        StartCoroutine(CountDownToStart());
    }

    public void PasueGame()
    {
        //score.SetActive(false);
        //combo.SetActive(false);
        //button.SetActive(false);
        popUpPause.SetActive(true);
    }

    public void BackToGame()
    {
        //score.SetActive(true);
        //combo.SetActive(true);
        //button.SetActive(true);
        popUpPause.SetActive(false);
    }
}
