using UnityEngine;


public class NoteMissDestroyLeft : MonoBehaviour
{   
    GameObject obj;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "NotesUp")
        {
            obj = other.gameObject;
            GameControl.instance.HpDecrease();
            Score.instance.ScoreCalculationCase(Score.GetScore.Miss);
            Score.instance.ScoreCalculationCase(Score.GetScore.ResetCombo);
            Destroy(obj);
        }
        else if (other.gameObject.tag == "DoubleTapNoteUp")
        {
            obj = other.gameObject;
            GameControl.instance.HpDecrease();
            Score.instance.ScoreCalculationCase(Score.GetScore.Miss);
            Score.instance.ScoreCalculationCase(Score.GetScore.ResetCombo);
            Destroy(obj);
        }
        else if (other.gameObject.tag == "DonotTapUp")
        {
            obj = other.gameObject;
            Score.instance.ScoreCalculationCase(Score.GetScore.Perfect);
            Score.instance.ScoreCalculationCase(Score.GetScore.Combo);
            Destroy(obj);

        }
        else if (other.gameObject.tag == "MutiTapUp")
        {
            obj = other.gameObject;
            Destroy(obj);

        }
        else if (other.gameObject.tag == "Lock1Up")
        {
            obj = other.gameObject;
            GameControl.instance.HpDecrease();
            Score.instance.ScoreCalculationCase(Score.GetScore.Miss);
            Score.instance.ScoreCalculationCase(Score.GetScore.ResetCombo);
            Destroy(obj);
        }
        else if (other.gameObject.tag == "Lock2Up")
        {
            obj = other.gameObject;
            GameControl.instance.HpDecrease();
            Score.instance.ScoreCalculationCase(Score.GetScore.Miss);
            Score.instance.ScoreCalculationCase(Score.GetScore.ResetCombo);
            Destroy(obj);
        }
        else if (other.gameObject.tag == "Lock3Up")
        {
            obj = other.gameObject;
            GameControl.instance.HpDecrease();
            Score.instance.ScoreCalculationCase(Score.GetScore.Miss);
            Score.instance.ScoreCalculationCase(Score.GetScore.ResetCombo);
            Destroy(obj);
        }
    }

    void ShowScore() {
        Score.instance.ShowScore();
    }

}
