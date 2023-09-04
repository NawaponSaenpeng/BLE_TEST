using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeInNotes : MonoBehaviour
{
    SpriteRenderer note;
     

    void Start()
    {
        note = GetComponent<SpriteRenderer>();
        Color color = note.material.color;
        color.a = 0f;
        note.material.color = color;
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "FadeDetetor")
        {
            Color color = note.material.color;
            color.a = 0.25f;
            note.material.color = color;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "FadeDetetor")
        {
            Color color = note.material.color;
            color.a = 1f;
            note.material.color = color;
        }
    }
}
