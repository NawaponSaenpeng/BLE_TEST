using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteInNode : MonoBehaviour
{
    public int time;
    public bool open;
    public string endtarget;

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
