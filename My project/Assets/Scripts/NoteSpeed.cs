using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteSpeed : MonoBehaviour
{
    public static NoteSpeed instance;
    public float beatTempo;

    void Start()
    {
        beatTempo = (beatTempo / 60);
    }

}
