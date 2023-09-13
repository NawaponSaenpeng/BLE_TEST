using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject gameObject;
    public GameObject bleControll;
    private static GameManager instance;
    private void Start()
    {
        ServerApi.InitAquaristaAPI();
        if (instance != null)
        {
            Debug.Log("Destroy");
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            DontDestroyOnLoad(bleControll);
        }
        
    }
}
