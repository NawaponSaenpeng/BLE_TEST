using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapToStart : MonoBehaviour
{
    public GameObject tapToStart, play, credits;
    void Update()
    {
        MenuScene();
    }

    void MenuScene()
    {
        if (Input.GetMouseButtonDown(0))
        {
            tapToStart.SetActive(false);
            play.SetActive(true);
            credits.SetActive(true);
        }
    }
}
