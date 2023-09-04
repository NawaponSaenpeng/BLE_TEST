using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetNotesSong : MonoBehaviour
{   
    GetValue getValue;
    public List<GameObject> Notes;
    public static GetNotesSong instance;

    void Awake() {
        instance = this;    
    }
    
    public void NotesSong () {
        //getValue.Notes = Notes;
    }
}
