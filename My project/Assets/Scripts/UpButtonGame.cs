using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UpButtonGame : MonoBehaviour
{

    private SpriteRenderer theSR;
    [Header ("NOTE OBJECT DISPLAY")]
    public GameObject Square;
    public SpriteRenderer spiteRenderer;

    [HideInInspector]
    public enum NoteTypes
    {
        NormalNote,
        DoubleTapNote,
        DonotTap,
        MutiTap,
        LockNote
       
    }

    [HideInInspector]
    public NoteTypes noteType;
    

    [HideInInspector]
    public bool hit, subNote1, subNote2, subNote3, noteSp1, noteSp2, noteSp3, lock1, lock2, lock3;

    [HideInInspector]
    public int hp = 2;

    [HideInInspector]
    public GameObject obj;

    [HideInInspector]
    public List<GameObject> objs = new List<GameObject>();

    void Awake() {

        theSR = GetComponent<SpriteRenderer>();
    }

    void Start()
    {   
       
        hit = false;
        noteSp1 = false;
        noteSp2 = false;
        noteSp3 = false;
        lock1 = false;
        lock2 = false;
        lock3 = false;

        subNote1 = false;
        subNote2 = false;
        subNote3 = false;
        
        //theSR.color = Color.blue;
        Color color = theSR.material.color;
        color.a = 0.5f;
        theSR.material.color = color;

        Square.transform.localScale = new Vector3(0f, 0f, 1f);
        

    }

    public void CheckNoteInTypes()
    {
        if (hit == true)
        {
            Color color = spiteRenderer.material.color;
            color.a = 1f;
            spiteRenderer.material.color = color;
            spiteRenderer.sprite = GameControl.instance.types.defaultSprite;
        } else if (noteSp1 == true)
        {
            Color color = spiteRenderer.material.color;
            color.a = 1f;
            spiteRenderer.material.color = color;

            spiteRenderer.sprite = GameControl.instance.types.sp1;
        } else if (noteSp2 == true) {
            Color color = spiteRenderer.material.color;
            color.a = 1f;
            spiteRenderer.material.color = color;
            spiteRenderer.sprite = GameControl.instance.types.xTap;
        } else if (noteSp3 == true)
        {
            Color color = spiteRenderer.material.color;
            color.a = 1f;
            spiteRenderer.material.color = color; 
            spiteRenderer.sprite = GameControl.instance.types.multiTap;
        } else if (lock1 == true)
        {
            Color color = spiteRenderer.material.color;
            color.a = 0.8f;
            spiteRenderer.material.color = color;
            spiteRenderer.sprite = GameControl.instance.types.unlock1;
        } else if (lock2 == true)
        {
            Color color = spiteRenderer.material.color;
            color.a = 0.8f;
            spiteRenderer.material.color = color;
            spiteRenderer.sprite = GameControl.instance.types.lock2;
        } else if (lock3 == true)
        {
            Color color = spiteRenderer.material.color;
            color.a = 0.8f;
            spiteRenderer.material.color = color;
            spiteRenderer.sprite = GameControl.instance.types.lock3;
        }

    }

    public void CheckNoteOutTypes()
    {
        if (hit == false)
        {
            spiteRenderer.sprite = GameControl.instance.types.defaultSprite;
            Square.transform.localScale = new Vector3(0f, 0f, 1f);
        }
        else if (noteSp1 == false)
        {
            spiteRenderer.sprite = GameControl.instance.types.defaultSprite;
            Square.transform.localScale = new Vector3(0f, 0f, 1f);
        }
        else if (noteSp2 == false)
        {
            spiteRenderer.sprite = GameControl.instance.types.defaultSprite;
            Square.transform.localScale = new Vector3(0f, 0f, 1f);
        }
        else if (noteSp3 == false)
        {
            spiteRenderer.sprite = GameControl.instance.types.defaultSprite;
            Square.transform.localScale = new Vector3(0f, 0f, 1f);
        }
        else if (lock1 == false)
        {
            spiteRenderer.sprite = GameControl.instance.types.defaultSprite;
            Square.transform.localScale = new Vector3(0f, 0f, 1f);
        }
        else if (lock2 == false)
        {
            spiteRenderer.sprite = GameControl.instance.types.defaultSprite;
            Square.transform.localScale = new Vector3(0f, 0f, 1f);
        }
        else if (lock3 == false)
        {
            spiteRenderer.sprite = GameControl.instance.types.defaultSprite;
            Square.transform.localScale = new Vector3(0f, 0f, 1f);
        }

    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "NotesUp") {
            noteType = NoteTypes.NormalNote;
            hit = true;
            CheckNoteInTypes();
            subNote1 = true;
            Square.transform.localScale = new Vector3(0.35f, 0.35f, 1f);
            obj = other.gameObject;
            objs.Add(obj);
            
        } 

        if (other.gameObject.tag == "DoubleTapNoteUp")
        {
            noteType = NoteTypes.DoubleTapNote;
            noteSp1 = true;
            CheckNoteInTypes();
            Square.transform.localScale = new Vector3(1f, 1f, 1f);
            obj = other.gameObject;
            objs.Add(obj);
            
        } 
        
        if (other.gameObject.tag == "DonotTapUp")
        {
            noteType = NoteTypes.DonotTap;
            noteSp2 = true;
            CheckNoteInTypes();
            Square.transform.localScale = new Vector3(1f, 1f, 1f);
            obj = other.gameObject;
            objs.Add(obj);

        }

        if (other.gameObject.tag == "MutiTapUp")
        {
            noteType = NoteTypes.MutiTap;
            noteSp3 = true;
            CheckNoteInTypes();
            Square.transform.localScale = new Vector3(1f, 1f, 1f);
            obj = other.gameObject;
            objs.Add(obj);
        }

        if (other.gameObject.tag == "Lock1Up")
        {
            noteType = NoteTypes.LockNote;
            lock1 = true;
            CheckNoteInTypes();
            Square.transform.localScale = new Vector3(1f, 1f, 1f);
            obj = other.gameObject;
            objs.Add(obj);
        }

        if (other.gameObject.tag == "Lock2Up")
        {
            noteType = NoteTypes.LockNote;
            lock2 = true;
            CheckNoteInTypes();
            Square.transform.localScale = new Vector3(1f, 1f, 1f);
            obj = other.gameObject;
            objs.Add(obj);
        }

        if (other.gameObject.tag == "Lock3Up")
        {
            noteType = NoteTypes.LockNote;
            lock3 = true;
            CheckNoteInTypes();
            Square.transform.localScale = new Vector3(1f, 1f, 1f);
            obj = other.gameObject;
            objs.Add(obj);
        }


        if ((hit == true && subNote1 == true) || (noteSp1 == true && subNote1 == true) || 
            (noteSp2 == true && subNote1 == true) || (noteSp3 == true && subNote1 == true) || (lock1 == true && subNote1 == true) ||
            (lock2 == true && subNote1 == true) || (lock3 == true && subNote1 == true))
        {
            switch (noteType)
            {
                case NoteTypes.NormalNote:
                    if (other.gameObject.tag == "SubNote2Up")
                    {
                        subNote2 = true;
                        Square.transform.localScale = new Vector3(0.65f, 0.65f, 1f);
                    }
                    else if (other.gameObject.tag == "SubNote3Up")
                    {
                        subNote3 = true;
                        spiteRenderer.sprite = GameControl.instance.types.OneTap;
                        Square.transform.localScale = new Vector3(4.5f, 4.5f, 1f);
                    }
                    break;

                case NoteTypes.DoubleTapNote:
                    if (other.gameObject.tag == "SubNote2Up")
                    {
                        Square.transform.localScale = new Vector3(1f, 1f, 1f);
                    }
                    else if (other.gameObject.tag == "SubNote3Up")
                    {
                        Square.transform.localScale = new Vector3(1f, 1f, 1f);
                    }
                    break;

                case NoteTypes.DonotTap:
                    if (other.gameObject.tag == "SubNote2Up")
                    {
                        Square.transform.localScale = new Vector3(1f, 1f, 1f);
                    }
                    else if (other.gameObject.tag == "SubNote3Up")
                    {
                        Square.transform.localScale = new Vector3(1f, 1f, 1f);
                    }
                    break;

                case NoteTypes.MutiTap:
                    if (other.gameObject.tag == "SubNote2Up")
                    {
                        Square.transform.localScale = new Vector3(1f, 1f, 1f);
                    }
                    else if (other.gameObject.tag == "SubNote3Up")
                    {

                        Square.transform.localScale = new Vector3(1f, 1f, 1f);
                    }
                    break;

                case NoteTypes.LockNote:
                    if (other.gameObject.tag == "SubNote2Up")
                    {
                        Square.transform.localScale = new Vector3(1f, 1f, 1f);
                    }
                    else if (other.gameObject.tag == "SubNote3Up")
                    {
                        Square.transform.localScale = new Vector3(1f, 1f, 1f);
                    }
                    break;
            }
        }


    }


    void OnTriggerExit2D(Collider2D other) {
        if (other.gameObject.tag == "NotesUp") {
            objs.Remove(objs[0]);
            
            if (objs.Count != 0) {
                hit = true;
            } else {
                hit = false;
                CheckNoteOutTypes();

            }
        } 
        else if (other.gameObject.tag == "DoubleTapNoteUp")
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
        else if (other.gameObject.tag == "DonotTapUp")
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
        else if (other.gameObject.tag == "MutiTapUp")
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
                CheckNoteOutTypes();

            }
        }
        else if (other.gameObject.tag == "Lock1Up")
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
        else if (other.gameObject.tag == "Lock2Up")
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
        else if (other.gameObject.tag == "Lock3Up")
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
                if (other.gameObject.tag == "SubNote1Up")
                {
                    subNote1 = false;

                    spiteRenderer.sprite = GameControl.instance.types.defaultSprite;
                    Square.transform.localScale = new Vector3(0.65f, 0.65f, 1f);

                }
                else if (other.gameObject.tag == "SubNote2Up")
                {
                    subNote2 = false;

                    Square.transform.localScale = new Vector3(0.35f, 0.35f, 1f);
                }
                else if (other.gameObject.tag == "SubNote3Up")
                {
                    subNote3 = false;

                    Square.transform.localScale = new Vector3(0f, 0f, 1f);
                }
                break;

            case NoteTypes.DoubleTapNote:
                if (other.gameObject.tag == "SubNote1Up")
                {
                    subNote1 = false;
                    Color color = spiteRenderer.material.color;
                    color.a = 0.75f;
                    spiteRenderer.material.color = color;

                }
                else if (other.gameObject.tag == "SubNote2Up")
                {
                    subNote2 = false;

                    Color color = spiteRenderer.material.color;
                    color.a = 0.35f;
                    spiteRenderer.material.color = color;
                }
                else if (other.gameObject.tag == "SubNote3Up")
                {
                    subNote3 = false;

                    spiteRenderer.sprite = GameControl.instance.types.defaultSprite;
                    Color color = spiteRenderer.material.color;
                    color.a = 1f;
                    spiteRenderer.material.color = color;
                    Square.transform.localScale = new Vector3(0f, 0f, 1f);

                }
                break;

            case NoteTypes.DonotTap:
                if (other.gameObject.tag == "SubNote1Up")
                {
                    subNote1 = false;
                    Color color = spiteRenderer.material.color;
                    color.a = 0.75f;
                    spiteRenderer.material.color = color;

                }
                else if (other.gameObject.tag == "SubNote2Up")
                {
                    subNote2 = false;

                    Color color = spiteRenderer.material.color;
                    color.a = 0.35f;
                    spiteRenderer.material.color = color;
                }
                else if (other.gameObject.tag == "SubNote3Up")
                {
                    subNote3 = false;
                    Color color = spiteRenderer.material.color;
                    color.a = 1f;
                    spiteRenderer.material.color = color;

                    spiteRenderer.sprite = GameControl.instance.types.defaultSprite;
                    Square.transform.localScale = new Vector3(0f, 0f, 1f);

                }
                break;

            case NoteTypes.MutiTap:
                if (other.gameObject.tag == "SubNote1Up")
                {
                    subNote1 = false;
                    Color color = spiteRenderer.material.color;
                    color.a = 0.75f;
                    spiteRenderer.material.color = color;

                }
                else if (other.gameObject.tag == "SubNote2Up")
                {
                    subNote2 = false;

                    Color color = spiteRenderer.material.color;
                    color.a = 0.35f;
                    spiteRenderer.material.color = color;
                }
                else if (other.gameObject.tag == "SubNote3Up")
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
                if (other.gameObject.tag == "SubNote1Up")
                {
                    subNote1 = false;
                    Color color = spiteRenderer.material.color;
                    color.a = 0.75f;
                    spiteRenderer.material.color = color;

                }
                else if (other.gameObject.tag == "SubNote2Up")
                {
                    subNote2 = false;

                    Color color = spiteRenderer.material.color;
                    color.a = 0.35f;
                    spiteRenderer.material.color = color;
                }
                else if (other.gameObject.tag == "SubNote3Up")
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

    public void DestroyNote() {
        Destroy(objs[0]);
        CheckNoteOutTypes();
    }


    void ShowScore() {
        Score.instance.ShowScore();
    }



}