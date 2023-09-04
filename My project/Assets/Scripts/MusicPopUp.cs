using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicPopUp : MonoBehaviour
{
    public MusicButton buttonPrefab;
    public GameObject buttonParent;
    public AllMusicData getValue;

    void Start()
    {
        
        getValue = Resources.Load<AllMusicData>("Music/MusicData");
        
        for (int i = 0; i < getValue.getMusicData.Length; i++)
        {
            MusicButton newButton = Instantiate(buttonPrefab, buttonParent.transform);
            newButton.name = $"Music{i}";
            newButton.musicData = getValue.getMusicData[i];

            if (i == 0)
            {
                newButton.SetDataMusic(getValue.getMusicData[i]);
            }
            
        }
        
    }

  


}
