using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using System;

public class Energy : MonoBehaviour
{
    public static Energy instance;
    [SerializeField] TMP_Text energyText;
    [HideInInspector]
    public int maxEnergy = 10;
    [HideInInspector]
    public int currentEnergy;
    [HideInInspector]
    public int restoreDuration = 20;
    [HideInInspector]
    public DateTime nextEnergyTime;
    [HideInInspector]
    public DateTime lastEnergyTime;
    [HideInInspector]
    public bool isRestoring = false;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        if (!PlayerPrefs.HasKey("currentEnergy"))
        {
            PlayerPrefs.SetInt("currentEnergy", 10);
            UpdateEnergy();
            Load();
            StartCoroutine(RestoreEnergy());
        }
        else
        {
            Load();
            UpdateEnergy();
            StartCoroutine(RestoreEnergy());
        }

    }

    private void Update()
    {
        Load();
        UpdateEnergy();
    }

    public void UseEnergy()
    {
        if(currentEnergy >= 1)
        {
            currentEnergy--;
            UpdateEnergy();
            if (isRestoring == false)
            {
                if(currentEnergy + 1 == maxEnergy)
                {
                    nextEnergyTime = AddDuration(DateTime.Now, restoreDuration);
                }

                StartCoroutine(RestoreEnergy());
            }
        }
        else
        {
            Debug.Log("Don't have Energy!");
        }
    }

    public IEnumerator RestoreEnergy()
    {
        UpdateEnergyTimer();
        isRestoring = true;

        while(currentEnergy < maxEnergy)
        {
            DateTime currentDateTime = DateTime.Now;
            DateTime nextDateTime = nextEnergyTime;
            bool isEnergyAdding = false;

            while (currentDateTime > nextDateTime)
            {
                if (currentEnergy < maxEnergy)
                {
                    isEnergyAdding = true;
                    currentEnergy++;
                    UpdateEnergy();
                    DateTime timeToAdd = lastEnergyTime > nextDateTime ? lastEnergyTime : nextDateTime;
                    nextDateTime = AddDuration(timeToAdd, restoreDuration);

                }
                else
                {
                    break;
                }
            }

            if (isEnergyAdding == true)
            {
                lastEnergyTime = DateTime.Now;
                nextEnergyTime = nextDateTime;
            }

            UpdateEnergy();
            UpdateEnergyTimer();
            Save();
            yield return null; 
        }

        isRestoring = false;
    }

    public DateTime AddDuration(DateTime dateTime, int duration)
    {
        return dateTime.AddSeconds(duration);
    }

    public DateTime StringToDate(string datetime)
    {
        if (String.IsNullOrEmpty(datetime))
        {
            return DateTime.Now;
        } else
        {
            return DateTime.Parse(datetime);
        }
    }

    public void UpdateEnergyTimer()
    {
        TimeSpan time = nextEnergyTime - DateTime.Now;
    }

    public void UpdateEnergy()
    {
        energyText.text = currentEnergy.ToString();
    }

    public void Load()
    {
        currentEnergy = PlayerPrefs.GetInt("currentEnergy");
        nextEnergyTime = StringToDate(PlayerPrefs.GetString("nextEnergyTime"));
        lastEnergyTime = StringToDate(PlayerPrefs.GetString("lastEnergyTime"));
        
    }

    public void Save()
    {
        PlayerPrefs.SetInt("currentEnergy", currentEnergy);
        PlayerPrefs.SetString("nextEnergyTime", nextEnergyTime.ToString());
        PlayerPrefs.SetString("lastEnergyTime", lastEnergyTime.ToString());
    }

    public void Reset()
    {
        currentEnergy = 10;
        UpdateEnergy();
        Save();
    }
}
