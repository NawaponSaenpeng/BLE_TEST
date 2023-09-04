using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Score : MonoBehaviour
{   
    [Header ("SHOW SCORE POPUP")]
    [SerializeField] GameObject popUp;

    [Header ("HIDE OBJECT WHEN ENDGAME")]
    [SerializeField] List<GameObject> hide = new List<GameObject>();

    [Header ("EFFECT")]
    public GameObject goodEffect;
    public GameObject perfectEffect;
    public GameObject missEffect;
    public GameObject badEffect;


    [Header ("SCORE DATA")]
    public ScoreSetting point;
    public static Score instance;

    [Header ("TEXT")]
    public TMP_Text MissNoteScoreText;
    public TMP_Text GoodScoreText;
    public  TMP_Text PerfectScoreText;
    public TMP_Text TotalScoreText;
    public TMP_Text ShowScoreText;
    public TMP_Text BadScoreText;
    public TMP_Text ComboText;
    public TMP_Text maxComboText;
    public TMP_Text coinsText;
    
    
    public enum GetScore
    {
        Miss,
        Good,
        Perfect,
        Bad,
        Combo,
        ResetCombo
    }

    [HideInInspector]
    public int TotalScore = 0;

    int MissNoteScore = 0;
    int GoodScore = 0;
    int PerfectScore = 0;
    int BadScore = 0;
    int Combo = 0;
    int maxCombo = 0;

    CurrencyData currencyData;
    private void Awake(){
        instance = this;
    }
    
    void Start()
    {
        BadScoreText.text = BadScore.ToString();
        MissNoteScoreText.text = MissNoteScore.ToString();
        GoodScoreText.text = GoodScore.ToString();
        PerfectScoreText.text = PerfectScore.ToString();
        TotalScoreText.text = (TotalScore < 10) ? "0" + TotalScore : TotalScore.ToString();
        ComboText.text = "COMBO: x" + Combo.ToString();
        popUp.SetActive(false);
    }

    public void ScoreCalculationCase(GetScore get)
    {
        switch (get)
        {
            case GetScore.Miss:
                MissNoteScore += 1;
                TotalScore -= point.missScore;
                MissNoteScoreText.text = $"{MissNoteScore}";
                Instantiate(missEffect, new Vector3(0f, 4.2f, 0f), Quaternion.identity);
                break;

            case GetScore.Good:
                GoodScore += 1;
                TotalScore += point.goodScore;
                GoodScoreText.text = $"{GoodScore}";
                Instantiate(goodEffect, new Vector3(0f, 4.2f, 0f), Quaternion.identity);
                break;

            case GetScore.Perfect:
                PerfectScore += 1;
                TotalScore += point.perfectScore;
                PerfectScoreText.text = $"{PerfectScore}";
                Instantiate(perfectEffect, new Vector3(0f, 4.2f, 0f), Quaternion.identity);
                break;

            case GetScore.Bad:
                BadScore += 1;
                TotalScore -= point.badScore;
                BadScoreText.text = $"{BadScore}";
                Instantiate(badEffect, new Vector3(0f, 4.2f, 0f), Quaternion.identity);
                break;


            case GetScore.Combo:
                Combo += 1;
                ComboText.text = $"COMBO: x{Combo}";
                break;

            case GetScore.ResetCombo:
                
                if (Combo > maxCombo)
                {
                    maxCombo = Combo;
                }
                Combo = 0;
                ComboText.text = $"COMBO: x{Combo}";
                break;

        }
        CheckTotalScore();
    }

    public void CheckTotalScore()
    {   

        if (TotalScore < 0)
        {
            TotalScore = 0;
        }
        TotalScoreText.text = (TotalScore < 10) ? "0" + TotalScore : TotalScore.ToString();
    }

    public void ShowScore() {
        ServerApi.GetPlayerData((d) => { currencyData = d; }, (e) => { });
        popUp.SetActive(true);
        if (TotalScore < 1000)
        {
            coinsText.text = "20";
            currencyData.coins += int.Parse(coinsText.text);
            currencyData.SaveCoins(currencyData.coins);
        } else if (TotalScore < 10000)
        {
            coinsText.text = "50";
            currencyData.coins += int.Parse(coinsText.text);
            currencyData.SaveCoins(currencyData.coins);
        }
        if (maxCombo < Combo)
        {
            maxCombo = Combo;
        } 
        
        for(int i = 0; i < hide.Count; i++)
        {
            hide[i].SetActive(false);
        }
        Time.timeScale = 0;
        if (TotalScore < 0) {
            TotalScore = 0;
        }
        ShowScoreText.text = TotalScore.ToString();
        maxComboText.text = maxCombo.ToString();
        TotalScoreText.text = (TotalScore < 10) ? "0" + TotalScore : TotalScore.ToString();

    }
    

}
