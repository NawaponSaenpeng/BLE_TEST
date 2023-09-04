using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteNode : MonoBehaviour
{
    public List<NoteGameObject> gameObjects = new List<NoteGameObject>();



    private void Test1()
    {
        var target = gameObjects.Find(s => s.targetID == "1");

        for (int i = 0; i < gameObjects.Count; i++)
        {
            var node = Instantiate(gameObjects[i]);
        }
    }

    private void Test2()
    {
        for (int i = 0; i < gameObjects.Count; i++)
        {
            CNote(gameObjects[i].noteInNodes);
        }
    }

    private void CNote(List<NoteInNode> noteInNodes)
    {
        for (int i = 0; i < noteInNodes.Count; i++)
        {
            if (noteInNodes[i].open)
            {
                StartCoroutine(WaitAndPrint(noteInNodes[i]));
            }

        }
    }

    IEnumerator WaitAndPrint(NoteInNode note)
    {
     

        yield return new WaitForSeconds(note.time);
        var s =Instantiate(note);
       



        var target = gameObjects.Find(w => w.targetID == s.GetTargetEnd());
    }
}

