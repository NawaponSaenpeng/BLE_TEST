using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject gameObject;
    
    private void Start()
    {
        ServerApi.InitAquaristaAPI();
        DontDestroyOnLoad(gameObject);
    }
}
