using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteDetetor : MonoBehaviour
{
    public GameObject left, right;

    void Start()
    {
        left.SetActive(false);
        right.SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "NotesLeft")
        {
            left.SetActive(true);
        } 
        
        if (other.gameObject.tag == "NotesRight")
        {
            right.SetActive(true);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "NotesLeft")
        {
            left.SetActive(false);
        }
        
        if (other.gameObject.tag == "NotesRight")
        {
            right.SetActive(false);
        }
    }
}
