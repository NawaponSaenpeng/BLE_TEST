using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class NoteData : MonoBehaviour
{
    public List<NoteNode> noteNodes = new List<NoteNode>();
    

    private void Start()
    {
        noteNodes = gameObject.GetComponentsInParent<NoteNode>().ToList();
    }
}
