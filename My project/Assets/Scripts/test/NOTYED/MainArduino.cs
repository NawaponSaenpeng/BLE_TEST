using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Android;
using UnityEngine.UI;

public class MainArduino : MonoBehaviour
{
    public Action<int> playButtonsUp;
    public Action<int> playButtonsDown;
    public List<UpAreaClick> buttonUpTest;
    public List<DownAreaClick> buttonDownTest;
    public static string dataRecived = "";

    private void Start()
    {
        #if UNITY_2020_2_OR_NEWER
        #if UNITY_ANDROID
        if (!Permission.HasUserAuthorizedPermission(Permission.CoarseLocation)
          || !Permission.HasUserAuthorizedPermission(Permission.FineLocation)
          || !Permission.HasUserAuthorizedPermission("android.permission.BLUETOOTH_SCAN")
          || !Permission.HasUserAuthorizedPermission("android.permission.BLUETOOTH_ADVERTISE")
          || !Permission.HasUserAuthorizedPermission("android.permission.BLUETOOTH_CONNECT"))
                    Permission.RequestUserPermissions(new string[] {
                        Permission.CoarseLocation,
                            Permission.FineLocation,
                            "android.permission.BLUETOOTH_SCAN",
                            "android.permission.BLUETOOTH_ADVERTISE",
                             "android.permission.BLUETOOTH_CONNECT"
                    });
        #endif
        #endif
        
        BluetoothService.CreateBluetoothObject();
        playButtonsUp += FindButtonsPlay;
        playButtonsDown += FindButtonsPlay2;
    }

    private void FindButtonsPlay(int buttonId)
    { 
        UpAreaClick button = buttonUpTest.Find(s => s.id == buttonId);
        button.OnPointerDownDelegate();
    }
    
    private void FindButtonsPlay2(int buttonId)
    { 
        DownAreaClick button = buttonDownTest.Find(s => s.id == buttonId);
        button.OnPointerDownDelegate();
    }
    
    
    // Update is called once per frame
    void Update()
    {
        if (BluetoothTest.IsConnected) {
            try
            {
                string datain =  BluetoothService.ReadFromBluetooth();
                if (datain == "1")
                {
                    dataRecived = datain;
                    BluetoothService.Toast(dataRecived);
                    playButtonsUp.Invoke(1);
                }
                if (datain == "2")
                {
                    dataRecived = datain;
                    BluetoothService.Toast(dataRecived);
                    playButtonsUp.Invoke(2);
                }
                if (datain == "3")
                {
                    dataRecived = datain;
                    BluetoothService.Toast(dataRecived);
                    playButtonsUp.Invoke(3);
                }
                if (datain == "4")
                {
                    dataRecived = datain;
                    BluetoothService.Toast(dataRecived);
                    playButtonsDown.Invoke(4);
                }
                if (datain == "5")
                {
                    dataRecived = datain;
                    BluetoothService.Toast(dataRecived);
                    playButtonsDown.Invoke(5);
                }
                if (datain == "6")
                {
                    dataRecived = datain;
                    BluetoothService.Toast(dataRecived);
                    playButtonsDown.Invoke(6);
                }

            }
            catch (Exception e)
            {
                BluetoothService.Toast("Error in connection");
            }
        }
        
    }
}