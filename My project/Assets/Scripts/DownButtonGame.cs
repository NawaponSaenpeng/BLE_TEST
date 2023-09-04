using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DownButtonGame : UpButtonGame
{
   
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "NotesDown")
        {
            noteType = NoteTypes.NormalNote;
            hit = true;
            CheckNoteInTypes();
            subNote1 = true;
            Square.transform.localScale = new Vector3(0.35f, 0.35f, 1f);
            obj = other.gameObject;
            objs.Add(obj);

        }

        if (other.gameObject.tag == "DoubleTapNoteDown")
        {
            noteType = NoteTypes.DoubleTapNote;
            noteSp1 = true;
            CheckNoteInTypes();
            Square.transform.localScale = new Vector3(1f, 1f, 1f);
            obj = other.gameObject;
            objs.Add(obj);

        }

        if (other.gameObject.tag == "DonotTapDown")
        {
            noteType = NoteTypes.DonotTap;
            noteSp2 = true;
            CheckNoteInTypes();
            Square.transform.localScale = new Vector3(1f, 1f, 1f);
            obj = other.gameObject;
            objs.Add(obj);

        }

        if (other.gameObject.tag == "MutiTapDown")
        {
            noteType = NoteTypes.MutiTap;
            noteSp3 = true;
            CheckNoteInTypes();
            Square.transform.localScale = new Vector3(1f, 1f, 1f);
            obj = other.gameObject;
            objs.Add(obj);
        }

        if (other.gameObject.tag == "Lock1Down")
        {
            noteType = NoteTypes.LockNote;
            lock1 = true;
            CheckNoteInTypes();
            Square.transform.localScale = new Vector3(1f, 1f, 1f);
            obj = other.gameObject;
            objs.Add(obj);
        }

        if (other.gameObject.tag == "Lock2Down")
        {
            noteType = NoteTypes.LockNote;
            lock2 = true;
            CheckNoteInTypes();
            Square.transform.localScale = new Vector3(1f, 1f, 1f);
            obj = other.gameObject;
            objs.Add(obj);
        }

        if (other.gameObject.tag == "Lock3Down")
        {
            noteType = NoteTypes.LockNote;
            lock3 = true;
            CheckNoteInTypes();
            Square.transform.localScale = new Vector3(1f, 1f, 1f);
            obj = other.gameObject;
            objs.Add(obj);
        }


        if ((hit == true && subNote1 == true) || (noteSp1 == true && subNote1 == false) ||
            (noteSp2 == true && subNote1 == false) || (noteSp3 == true && subNote1 == false) || (lock1 == true && subNote1 == true) ||
            (lock2 == true && subNote1 == true) || (lock3 == true && subNote1 == true))
        {
            switch (noteType)
            {
                case NoteTypes.NormalNote:
                    if (other.gameObject.tag == "SubNote2Down")
                    {
                        subNote2 = true;

                        Square.transform.localScale = new Vector3(0.65f, 0.65f, 1f);
                    }
                    else if (other.gameObject.tag == "SubNote3Down")
                    {
                        subNote3 = true;

                        spiteRenderer.sprite = GameControl.instance.types.OneTap;
                        Square.transform.localScale = new Vector3(4.5f, 4.5f, 1f);
                    }
                    break;

                case NoteTypes.DoubleTapNote:
                    if (other.gameObject.tag == "SubNote2Down")
                    {

                        Square.transform.localScale = new Vector3(1f, 1f, 1f);
                    }
                    else if (other.gameObject.tag == "SubNote3Down")
                    {

                        Square.transform.localScale = new Vector3(1f, 1f, 1f);
                    }
                    break;

                case NoteTypes.DonotTap:
                    if (other.gameObject.tag == "SubNote2Down")
                    {

                        Square.transform.localScale = new Vector3(1f, 1f, 1f);
                    }
                    else if (other.gameObject.tag == "SubNote3Down")
                    {

                        Square.transform.localScale = new Vector3(1f, 1f, 1f);
                    }
                    break;

                case NoteTypes.MutiTap:
                    if (other.gameObject.tag == "SubNote2Down")
                    {

                        Square.transform.localScale = new Vector3(1f, 1f, 1f);
                    }
                    else if (other.gameObject.tag == "SubNote3Down")
                    {

                        Square.transform.localScale = new Vector3(1f, 1f, 1f);
                    }
                    break;

                case NoteTypes.LockNote:
                    if (other.gameObject.tag == "SubNote2Down")
                    {
                        Square.transform.localScale = new Vector3(1f, 1f, 1f);
                    }
                    else if (other.gameObject.tag == "SubNote3Down")
                    {
                        Square.transform.localScale = new Vector3(1f, 1f, 1f);
                    }
                    break;
            }
        }

    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "NotesDown")
        {
            objs.Remove(objs[0]);
            noteType = NoteTypes.NormalNote;
            
            if (objs.Count != 0)
            {
                hit = true;
            }
            else
            {
                hit = false;
                CheckNoteOutTypes();

            }
        }
        else if (other.gameObject.tag == "DoubleTapNoteDown")
        {
            objs.Remove(objs[0]);
            hp = 2;
            noteType = NoteTypes.DoubleTapNote;

            if (objs.Count != 0)
            {
                noteSp1 = true;
            }
            else
            {
                noteSp1 = false;
                CheckNoteOutTypes();

            }
        }
        else if (other.gameObject.tag == "DonotTapDown")
        {
            objs.Remove(objs[0]);

            noteType = NoteTypes.DonotTap;

            if (objs.Count != 0)
            {
                noteSp2 = true;
            }
            else
            {
                noteSp2 = false;
                CheckNoteOutTypes();

            }
        }
        else if (other.gameObject.tag == "MutiTapDown")
        {
            objs.Remove(objs[0]);

            noteType = NoteTypes.MutiTap;

            if (objs.Count != 0)
            {
                noteSp3 = true;
            }
            else
            {
                noteSp3 = false;
                spiteRenderer.sprite = GameControl.instance.types.defaultSprite;
                Square.transform.localScale = new Vector3(0f, 0f, 1f);

            }
        }
        else if (other.gameObject.tag == "Lock1Down")
        {
            objs.Remove(objs[0]);

            noteType = NoteTypes.LockNote;

            if (objs.Count != 0)
            {
                lock1 = true;
            }
            else
            {
                lock1 = false;
                CheckNoteOutTypes();

            }
        }
        else if (other.gameObject.tag == "Lock2Down")
        {
            objs.Remove(objs[0]);

            noteType = NoteTypes.LockNote;

            if (objs.Count != 0)
            {
                lock2 = true;
            }
            else
            {
                lock2 = false;
                CheckNoteOutTypes();

            }
        }
        else if (other.gameObject.tag == "Lock3Down")
        {
            objs.Remove(objs[0]);

            noteType = NoteTypes.LockNote;

            if (objs.Count != 0)
            {
                lock3 = true;
            }
            else
            {
                lock3 = false;
                CheckNoteOutTypes();

            }
        }

        switch (noteType)
        {
            case NoteTypes.NormalNote:
                if (other.gameObject.tag == "SubNote1Down")
                {
                    subNote1 = false;
                    spiteRenderer.sprite = GameControl.instance.types.defaultSprite;
                    Square.transform.localScale = new Vector3(0.65f, 0.65f, 1f);

                }
                else if (other.gameObject.tag == "SubNote2Down")
                {
                    subNote2 = false;

                    Square.transform.localScale = new Vector3(0.35f, 0.35f, 1f);
                }
                else if (other.gameObject.tag == "SubNote3Down")
                {
                    subNote3 = false;

                    Square.transform.localScale = new Vector3(0f, 0f, 1f);
                }
                break;

            case NoteTypes.DoubleTapNote:
                if (other.gameObject.tag == "SubNote1Down")
                {
                    subNote1 = false;
                    Color color = spiteRenderer.material.color;
                    color.a = 0.75f;
                    spiteRenderer.material.color = color;

                }
                else if (other.gameObject.tag == "SubNote2Down")
                {
                    subNote2 = false;

                    Color color = spiteRenderer.material.color;
                    color.a = 0.35f;
                    spiteRenderer.material.color = color;
                }
                else if (other.gameObject.tag == "SubNote3Down")
                {
                    subNote3 = false;
                    Color color = spiteRenderer.material.color;
                    color.a = 1f;
                    spiteRenderer.material.color = color;
                    spiteRenderer.sprite = GameControl.instance.types.defaultSprite;
                    Square.transform.localScale = new Vector3(0f, 0f, 1f);

                }
                break;

            case NoteTypes.DonotTap:
                if (other.gameObject.tag == "SubNote1Down")
                {
                    subNote1 = false;
                    Color color = spiteRenderer.material.color;
                    color.a = 0.75f;
                    spiteRenderer.material.color = color;

                }
                else if (other.gameObject.tag == "SubNote2Down")
                {
                    subNote2 = false;

                    Color color = spiteRenderer.material.color;
                    color.a = 0.35f;
                    spiteRenderer.material.color = color;
                }
                else if (other.gameObject.tag == "SubNote3Down")
                {
                    subNote3 = false;
                    spiteRenderer.sprite = GameControl.instance.types.defaultSprite;
                    
                    Color color = spiteRenderer.material.color;
                    color.a = 1f;
                    spiteRenderer.material.color = color;                    
                    Square.transform.localScale = new Vector3(0f, 0f, 1f);

                }
                break;

            case NoteTypes.MutiTap:
                if (other.gameObject.tag == "SubNote1Down")
                {
                    subNote1 = false;
                    Color color = spiteRenderer.material.color;
                    color.a = 0.75f;
                    spiteRenderer.material.color = color;

                }
                else if (other.gameObject.tag == "SubNote2Down")
                {
                    subNote2 = false;

                    Color color = spiteRenderer.material.color;
                    color.a = 0.35f;
                    spiteRenderer.material.color = color;
                }
                else if (other.gameObject.tag == "SubNote3Down")
                {
                    subNote3 = false;
                    Color color = spiteRenderer.material.color;
                    color.a = 1f;
                    spiteRenderer.material.color = color;
                    spiteRenderer.sprite = GameControl.instance.types.defaultSprite;
                    Square.transform.localScale = new Vector3(0f, 0f, 1f);

                }
                break;

            case NoteTypes.LockNote:
                if (other.gameObject.tag == "SubNote1Down")
                {
                    subNote1 = false;
                    Color color = spiteRenderer.material.color;
                    color.a = 0.75f;
                    spiteRenderer.material.color = color;

                }
                else if (other.gameObject.tag == "SubNote2Down")
                {
                    subNote2 = false;

                    Color color = spiteRenderer.material.color;
                    color.a = 0.35f;
                    spiteRenderer.material.color = color;
                }
                else if (other.gameObject.tag == "SubNote3Down")
                {
                    subNote3 = false;
                    Color color = spiteRenderer.material.color;
                    color.a = 1f;
                    spiteRenderer.material.color = color;
                    spiteRenderer.sprite = GameControl.instance.types.defaultSprite;

                    Square.transform.localScale = new Vector3(0f, 0f, 1f);

                }
                break;
        }

    }

}
