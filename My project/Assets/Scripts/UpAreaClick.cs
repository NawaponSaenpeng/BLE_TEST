using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UpAreaClick : MonoBehaviour
{
    public int id;
    [Header ("BUTTON SCRIPTS")]
    public UpButtonGame button;
    public UpButtonGame button1;
    public UpButtonGame button2;

    [Header ("AREA SCRIPTS")]
    public UpAreaClick click1;
    public UpAreaClick click2;

    [Header ("EFFECT")]
    public ParticleSystem particEffect;
    public AudioSource soundFX;

    [HideInInspector]
    public bool unlock2 = false, unlock3 = false;

    void Start()
    {
        EventTrigger trigger = GetComponent<EventTrigger>();
        EventTrigger.Entry entry = new EventTrigger.Entry();
        entry.eventID = EventTriggerType.PointerDown;
        entry.callback.AddListener((data) => { OnPointerDownDelegate(); });
        trigger.triggers.Add(entry);
        
    }

    public void OnPointerDownDelegate()
    {
        soundFX.Play();
        particEffect.Play();
        if (button.hit == true)
        {
            if ((button.subNote1 == true && button.subNote2 == true && button.subNote3 == true))
            {
                Score.instance.ScoreCalculationCase(Score.GetScore.Perfect);
                Score.instance.ScoreCalculationCase(Score.GetScore.Combo);
            }
            else if ((button.subNote1 == true && button.subNote2 == false && button.subNote3 == false) ||
                      (button.subNote3 == true && button.subNote2 == false && button.subNote1 == false))
            {
                Score.instance.ScoreCalculationCase(Score.GetScore.Bad);
                Score.instance.ScoreCalculationCase(Score.GetScore.Combo);
            }
            else
            {
                Score.instance.ScoreCalculationCase(Score.GetScore.Good);
                Score.instance.ScoreCalculationCase(Score.GetScore.Combo);
            }
            button.DestroyNote();
            GameControl.instance.EventTime();

        }
        else if (button.noteSp1 == true)
        {
            button.hp -= 1;
            Score.instance.ScoreCalculationCase(Score.GetScore.Combo);
            Score.instance.ScoreCalculationCase(Score.GetScore.Perfect);
            if (button.hp == 0)
            {
                button.DestroyNote();
            } 
            else if (button.hp == 1)
            {
                button.spiteRenderer.sprite = GameControl.instance.types.sp2;
            }
            GameControl.instance.EventTime();
        }
        else if (button.noteSp2 == true)
        {
            Score.instance.ScoreCalculationCase(Score.GetScore.Miss);
            Score.instance.ScoreCalculationCase(Score.GetScore.ResetCombo);
            button.DestroyNote();
            GameControl.instance.EventTime();
        }
        else if (button.noteSp3 == true)
        {
            Score.instance.ScoreCalculationCase(Score.GetScore.Combo);
            Score.instance.ScoreCalculationCase(Score.GetScore.Perfect);   
        }

        else if (button.lock1 == true)
        {
            Score.instance.ScoreCalculationCase(Score.GetScore.Combo);
            Score.instance.ScoreCalculationCase(Score.GetScore.Perfect);
            button.DestroyNote();
            if (button1.lock2 == true)
                {
                    button1.spiteRenderer.sprite = GameControl.instance.types.unlock2;
                    unlock2 = true;
            } else if (button2.lock2 == true)
                {
                    button2.spiteRenderer.sprite = GameControl.instance.types.unlock2;
                    unlock2 = true;
                }              
            
        }
        else if (button.lock2 == true && (click1.unlock2 == true || click2.unlock2 == true))
        {
            Score.instance.ScoreCalculationCase(Score.GetScore.Combo);
            Score.instance.ScoreCalculationCase(Score.GetScore.Perfect);
            button.DestroyNote();

                if (button1.lock3 == true)
                {
                    button1.spiteRenderer.sprite = GameControl.instance.types.unlock3;
                    unlock3 = true;
                }
                else if (button2.lock3 == true)
                {
                    button2.spiteRenderer.sprite = GameControl.instance.types.unlock3;
                    unlock3 = true;
                }
            
        } 
        else if (button.lock3 == true && (click1.unlock3 == true || click2.unlock3 == true))
        {
            Score.instance.ScoreCalculationCase(Score.GetScore.Combo);
            Score.instance.ScoreCalculationCase(Score.GetScore.Perfect);
            button.DestroyNote();
        }


    }
}
