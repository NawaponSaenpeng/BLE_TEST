using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteMissDestroyRight : MonoBehaviour
{
    GameObject obj;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "NotesDown")
        {
            obj = other.gameObject;
            GameControl.instance.HpDecrease();
            Score.instance.ScoreCalculationCase(Score.GetScore.Miss);
            Score.instance.ScoreCalculationCase(Score.GetScore.ResetCombo);
            Destroy(obj);
        }
        else if (other.gameObject.tag == "DoubleTapNoteDown")
        {
            obj = other.gameObject;
            GameControl.instance.HpDecrease();
            Score.instance.ScoreCalculationCase(Score.GetScore.Miss);
            Score.instance.ScoreCalculationCase(Score.GetScore.ResetCombo);
            Destroy(obj);
        }
        else if (other.gameObject.tag == "DonotTapDown")
        {
            obj = other.gameObject;
            Score.instance.ScoreCalculationCase(Score.GetScore.Perfect);
            Score.instance.ScoreCalculationCase(Score.GetScore.Combo);
            Destroy(obj);

        }
        else if (other.gameObject.tag == "MutiTapDown")
        {
            obj = other.gameObject;
            Destroy(obj);

        }
        else if (other.gameObject.tag == "Lock1Down")
        {
            obj = other.gameObject;
            GameControl.instance.HpDecrease();
            Score.instance.ScoreCalculationCase(Score.GetScore.Miss);
            Score.instance.ScoreCalculationCase(Score.GetScore.ResetCombo);
            Destroy(obj);
        }
        else if (other.gameObject.tag == "Lock2Down")
        {
            obj = other.gameObject;
            GameControl.instance.HpDecrease();
            Score.instance.ScoreCalculationCase(Score.GetScore.Miss);
            Score.instance.ScoreCalculationCase(Score.GetScore.ResetCombo);
            Destroy(obj);
        }
        else if (other.gameObject.tag == "Lock3Down")
        {
            obj = other.gameObject;
            GameControl.instance.HpDecrease();
            Score.instance.ScoreCalculationCase(Score.GetScore.Miss);
            Score.instance.ScoreCalculationCase(Score.GetScore.ResetCombo);
            Destroy(obj);
        }

    }

    void ShowScore()
    {
        Score.instance.ShowScore();
    }

}
