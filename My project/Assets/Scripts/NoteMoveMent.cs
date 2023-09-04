using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteMoveMent : MonoBehaviour
{   
    public NoteSpeed noteSpeed;
    public bool Up;
    public bool Down;

    void Start()
    {
        noteSpeed = FindObjectOfType<NoteSpeed>();
    }

    void Update()
    {   
        if (Up == true)
        {
            transform.position += new Vector3(0f, noteSpeed.beatTempo * Time.deltaTime, 0f);
        }
        else if (Down == true)
        {

            transform.position -= new Vector3(0f, noteSpeed.beatTempo * Time.deltaTime, 0f);
        }
    }
}
