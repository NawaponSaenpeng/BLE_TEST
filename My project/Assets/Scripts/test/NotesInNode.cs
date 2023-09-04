using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotesInNode : MonoBehaviour
{
    public int time;
    public bool open;
    public GameObject obj;
    public string nameEndtarget;
    public string endtarget;
    DataID data;
    GameObject pos;


    private void Start()
    {
        GetID(nameEndtarget);
        if (endtarget == "B1")
        {
            obj.transform.Rotate(0f, 0f, -135f);
            obj.transform.position = pos.transform.position;
                        
        }
        else if (endtarget == "B2")
        {
            obj.transform.Rotate(0f, 0f, 135f);
            obj.transform.position = pos.transform.position;
        }
        else if (endtarget == "B3")
        {
            obj.transform.Rotate(0f, 0f, -90f);
            obj.transform.position = pos.transform.position;
        }
        else if (endtarget == "B4")
        {
            obj.transform.Rotate(0f, 0f, 90f);
            obj.transform.position = pos.transform.position;
        }
        else if (endtarget == "B5")
        {
            obj.transform.Rotate(0f, 0f, 305f);
            obj.transform.position = pos.transform.position;
        }
        else if (endtarget == "B6")
        {

            obj.transform.Rotate(0f, 0f, -305f);
            obj.transform.position = pos.transform.position;

        }
    }

    public void GetID(string target)
    {
        data = Database.GetID(target);
        pos = data.button;
        endtarget = data.IDObject;
    }
    public string GetTargetEnd()
    {
        return endtarget;
    }

    private void OnDisable()
    {
        open = false;
    }

    private void OnEnable()
    {
        open = true;
    }
}
