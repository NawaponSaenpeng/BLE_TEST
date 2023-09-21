using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Android;
using UnityEngine.UI;



public class BluetoothTest : MonoBehaviour
{
    public static bool isConnected;
    public static string dataRecived = "";
    // Start is called before the first frame update
    void Start()
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
       
    }

    // Update is called once per frame
    /*void Update()
    {
        if (isConnected) {
            try
            {
               string datain =  BluetoothService.ReadFromBluetooth();
               dataRecived = datain;
               BluetoothService.Toast(dataRecived);
                

            }
            catch (Exception e)
            {
                BluetoothService.Toast("Error in connection");
            }
        }
        
    }*/

    public void GetDevicesButton()
    {
       string[] devices = BluetoothService.GetBluetoothDevices();

        foreach(var d in devices)
        {
            Debug.Log(d);
        }
    }

    public void StartButton()
    {
        if (!isConnected)
        {
            isConnected =  BluetoothService.StartBluetoothConnection("ESP32-TEST");
            BluetoothService.Toast("ESP32-TEST"+" status: " + isConnected);
            BluetoothService.WritetoBluetooth(isConnected ? "connect" : "Not connected");
        }
    }

    public void SendButton()
    {
        if (isConnected)
        {
            BluetoothService.WritetoBluetooth("connect");
        }else {
            BluetoothService.WritetoBluetooth("Not connected");
        }
            
    }


    public void StopButton()
    {
        if (isConnected)
        {
            BluetoothService.StopBluetoothConnection();
        }
        Application.Quit();
    }
}
