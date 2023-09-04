using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;
using System;

public class DownArduino : MonoBehaviour
{
    private SerialPort sp = new SerialPort("\\\\.\\COM5", 115200);
    public Action<int> playButtons;
    public List<DownAreaClick> buttonTest;

    private void Start()
    {
        sp.Open();
        Debug.Log("open");
        sp.ReadTimeout = 1;
        playButtons += FindButtonsPlay;
    }

    private void FindButtonsPlay(int buttonId)
    { 
        DownAreaClick button = buttonTest.Find(s => s.id == buttonId);
        button.OnPointerDownDelegate();
    }

    private void Update()
    {
        if (sp.IsOpen)
        {
            try
            {
                int val = sp.ReadByte();
                if (val == 4)
                {
                    playButtons.Invoke(1);
                }
                if (val == 5)
                {
                    playButtons.Invoke(2);
                }
                if (val == 6)
                {
                    playButtons.Invoke(3);
                }
            }
            catch (System.Exception e)
            {
                //Debug.Log(e.Message);
            }
        }
    }
}
