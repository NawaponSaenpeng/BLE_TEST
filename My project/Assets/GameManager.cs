using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject gameObject;
    public GameObject bleControll;
    
    private void Start()
    {
        ServerApi.InitAquaristaAPI();
        DontDestroyOnLoad(gameObject);
        DontDestroyOnLoad(bleControll);
    }
}
