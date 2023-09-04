using System.Collections.Generic;
using UnityEngine;
using TMPro;    



public class GameControl : MonoBehaviour 
{   
    [Header ("TYPES NOTE DATA")]
    public TypesNote types;
    List<NoteData> NotesEasy = new List<NoteData>();
    List<NoteData> NotesNormal = new List<NoteData>();
    List<NoteData> NotesHard = new List<NoteData>();
    List<NoteData> NotesEvent = new List<NoteData>();
    public static GameControl instance;

    [Header ("SYNC NOTE")]
    public SpriteRenderer borderGame;
    
    [Header ("TARGET SCORE")]
    public TMP_Text targetScore;
    int goalScore;

    bool haveHp = false;
    float speed;


    [Header ("HP BAR")]
    [SerializeField] GameObject CheckHp;
    public int maxHealth = 100;
    int currentHealth;
    public HealthBar healthBar;

    [HideInInspector]
    public float musicPlayTime;

    [HideInInspector]
    public int getMode;

    [HideInInspector]
    public bool eventTime;
    
    void Awake() {
        instance = this;
        NotesEasy = MusicButton.get.Easy;
        NotesNormal = MusicButton.get.Normal;
        NotesHard = MusicButton.get.Hard;
        getMode = MenuButton.instance.selectMode;
        NotesEvent = MusicButton.get.Event;
        goalScore = MusicButton.get.targetScore;
        
    }

    void Start()
    {
        Debug.Log(getMode);
        GameModeCheck();
        HpSetAtStart(); 
        MusicTimeCount();
        targetScore.text = $"Target: {goalScore}";
      
    }

    void MusicTimeCount()
    {
        if (eventTime == true)
        {
            if (musicPlayTime < 3)
            {
                borderGame.color = Color.green;
                for (int i = 0; i < NotesHard.Count; i++)
                {

                    if (i == 0)
                    {
                        speed = -MusicButton.get.eventSpeed;
                    }
                    else if (i == 1)
                    {
                        speed = MusicButton.get.eventSpeed;
                    }
                    var note = Instantiate(NotesEvent[i]);
                    note.gameObject.AddComponent<NoteSpeedUp>().setSpeed(speed);
                }
                eventTime = false;
                musicPlayTime += 5;
            }
        }


        if (musicPlayTime > 0)
        {   
            musicPlayTime--;
            Invoke("MusicTimeCount", 1.0f);
        }
        else
        {
            this.Wait(2f, ShowScore);
            MusicScript.instance.StopMusic();
        }
    }

    void GameModeCheck()
    {
        if (getMode == 2)
        {

            for (int i = 0; i < NotesHard.Count; i++)
            {

                if (i == 0)
                {
                    speed = -MusicButton.get.hardSpeed;
                }
                else if (i == 1)
                {
                    speed = MusicButton.get.hardSpeed;
                }
                var note = Instantiate(NotesHard[i]);
                note.gameObject.AddComponent<NoteSpeedUp>().setSpeed(speed);
                
            }
            haveHp = true;
            CheckHp.SetActive(true);
            musicPlayTime = MusicButton.get.timerHard + MusicButton.get.delay;

        }
        else if (getMode == 1)
        {
            
            for (int i = 0; i < NotesNormal.Count; i++)
            {

                if (i == 0)
                {
                    speed = -MusicButton.get.normalSpeed;
                }
                else if (i == 1)
                {
                    speed = MusicButton.get.normalSpeed;
                }
                var note = Instantiate(NotesNormal[i]);
                note.gameObject.AddComponent<NoteSpeedUp>().setSpeed(speed);
            }
            haveHp = false;
            CheckHp.SetActive(false);
            musicPlayTime = MusicButton.get.timerNormal + MusicButton.get.delay;

        } else if (getMode == 0)
        {

            for (int i = 0; i < NotesEasy.Count; i++)
            {

                if (i == 0)
                {
                    speed = -MusicButton.get.easySpeed;
                }
                else if (i == 1)
                {
                    speed = MusicButton.get.easySpeed;
                }
                var note = Instantiate(NotesEasy[i]);
                note.gameObject.AddComponent<NoteSpeedUp>().setSpeed(speed);
            }
            haveHp = false;
            CheckHp.SetActive(false);
            musicPlayTime = MusicButton.get.timerEasy + MusicButton.get.delay;
        }
    }


    public void HpDecrease(int damage = 10)
    {
        if (haveHp)
        {
            currentHealth -= damage;
            healthBar.SetHealth(currentHealth);
            if (currentHealth <= 0)
            {
                this.Wait(1f, ShowScore);
         
                MusicScript.instance.StopMusic();
            }
        }
       
    }
   
    
    void HpSetAtStart()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        
    }

    void ShowScore()
    {
        Score.instance.ShowScore();
    }

    public void EventTime()
    {
        if (Score.instance.TotalScore >= MusicButton.get.targetScore)
        {
            eventTime = true;
        }
    }

}
