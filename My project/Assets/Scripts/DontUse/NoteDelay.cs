using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteDelay : MonoBehaviour
{
    public float DelayTime;
    public float BeatTempo;
    public bool Down;
    public bool Up;
    public bool LeftUp;
    public bool LeftDown;
    public bool RightUp;
    public bool RightDown;
    

    void Start()
    {
        BeatTempo = BeatTempo / 60f;
    }

    void Update()
    {   
        if (Down == true) {
            // Invoke("DelayNoteDown", DelayTime);
            this.Wait(DelayTime, DelayNoteDown);
        } else if (Up == true) {
            // Invoke("DelayNoteUp", DelayTime);
            this.Wait(DelayTime, DelayNoteUp);
        } else if (LeftUp == true) {
            // Invoke("DelayNoteLeftUp", DelayTime);
            this.Wait(DelayTime, DelayNoteLeftUp);
        } else if (LeftDown == true) {
            // Invoke("DelayNoteLeftDown", DelayTime);
            this.Wait(DelayTime, DelayNoteLeftDown);
        } else if (RightUp == true) {
            // Invoke("DelayNoteRightUp", DelayTime);
            this.Wait(DelayTime, DelayNoteRightUp);
        } else if (RightDown == true) {
            // Invoke("DelayNoteRightDown", DelayTime);
            this.Wait(DelayTime, DelayNoteRightDown);
        }
    }

    void DelayNoteDown() {
        transform.position -= new Vector3(0f, BeatTempo * Time.deltaTime, 0f);  
    }

    void DelayNoteUp() {
        transform.position += new Vector3(0f, BeatTempo * Time.deltaTime, 0f);
    }

    void DelayNoteLeftUp() {
        transform.position -= new Vector3((BeatTempo * Time.deltaTime), -(BeatTempo * Time.deltaTime), 0f);
    }

    void DelayNoteLeftDown() {
        transform.position += new Vector3(-(BeatTempo * Time.deltaTime), -(BeatTempo * Time.deltaTime), 0f);
    }
    
    void DelayNoteRightUp() {
        transform.position -= new Vector3(-(BeatTempo * Time.deltaTime), -(BeatTempo * Time.deltaTime), 0f);
    }

    void DelayNoteRightDown() {
        transform.position += new Vector3((BeatTempo * Time.deltaTime), -(BeatTempo * Time.deltaTime), 0f);
    }
}
